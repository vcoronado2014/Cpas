using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Web;
using System.Net.Mail;
using System.Text;
using DevExpress.Spreadsheet;
using System.Threading;
using VCFramework.Negocio.Factory;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class cargaMasiva : System.Web.UI.Page
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                UsuarioFuncional usu = new UsuarioFuncional();
                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    if (usu != null && usu.AutentificacionUsuario.Id > 0)
                    {
                        Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                        Session["ID_USUARIO_SUBE"] = usu.AutentificacionUsuario.Id;
                        Session["ID_REGION_SUBE"] = usu.Region.Id;
                        Session["ID_COMUNA_SUBE"] = usu.Comuna.Id;
                    }
                    else
                    {
                        Response.Redirect("~/default.aspx"); 
                    }
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }
        const string UploadDirectory = "~/Excel/";
        protected void upload_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string randomFile = Path.GetRandomFileName();
            string nomArchivo = randomFile + " " + e.UploadedFile.FileName.Replace("_", " ");

            string resultFileName = Path.ChangeExtension(nomArchivo, resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);


            e.UploadedFile.SaveAs(resultFilePath);

            //if (File.Exists(resultFileName))
            //UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5);

            string name = e.UploadedFile.FileName;
            string url = ResolveClientUrl(resultFileUrl);
            long sizeInKilobytes = e.UploadedFile.ContentLength / 1024;
            string sizeText = sizeInKilobytes.ToString() + " KB";
            //GuardarArchivo(nomArchivo, resultFileUrl, sizeInKilobytes, fechaSubida, urlExtension);
            e.CallbackData = resultFileUrl + "|" + url + "|" + sizeText;
            //abrir y procesar el archivo

        }

        protected void pnlGeneral_Callback(object sender, CallbackEventArgsBase e)
        {
            if (e.Parameter.Contains("subir"))
            {
                string[] param = e.Parameter.Split('|');
                lblNombreArchivoSubido.Text = param[1];
                //verificar validez del archivostring 
                string path = param[1];
                string[] archivo = param[1].Split('/');
                /* path */
                string pathUrl = archivo[archivo.Length -1];
                //string[] arrPath = path.Split('/');
                
                string pathFisico = Request.PhysicalApplicationPath + @"Excel\" + pathUrl ;

                Excel1.Open(pathFisico);

                
                int idInstSube = int.Parse(Session["INST_ID"].ToString());
                int idUsuSube = int.Parse(Session["ID_USUARIO_SUBE"].ToString());
                int idRegSube = int.Parse(Session["ID_REGION_SUBE"].ToString());
                int idComSube = int.Parse(Session["ID_COMUNA_SUBE"].ToString());

                

                try
                {
                    VCFramework.SitioWeb.ItemError respuesta = ExcelAEntidad(Excel1, idInstSube, idRegSube, idComSube); 
                    StringBuilder sb = new StringBuilder();
                    if (respuesta != null)
                    {
                        sb.AppendFormat("Se ha realizado el proceso de carga de Usuarios desde el archivo {0}", param[1]);
                        sb.Append("\r\n");
                        sb.AppendFormat("Se procesaron {0} usuarios de forma exitosa.", respuesta.CantidadFilasProcesadas.ToString());
                        if (respuesta.DetalleErrores != null && respuesta.DetalleErrores.Count > 0)
                        {
                            sb.Append("\r\n");
                            sb.Append("Errores:");
                            sb.Append("\r\n");
                            foreach (string s in respuesta.DetalleErrores)
                            {
                                sb.Append(s);
                                sb.Append("\r\n");
                            }

                        }

                    }
                    vistaMensaje1.MostrarMensaje(SitioWeb.EstiloMensaje.Ok, true, false, sb.ToString(), string.Empty);
                }
                catch (Exception ex)
                {
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                    vistaMensaje1.MostrarMensaje(SitioWeb.EstiloMensaje.Error, true, false, ex.Message, string.Empty);
                }

            }
        }
        Worksheet worksheet;
        private ItemError ExcelAEntidad(DevExpress.Web.ASPxSpreadsheet.ASPxSpreadsheet excel, int idInst, int idRegion, int idComuna)
        {
            List<ItemExcel> procesar = new List<ItemExcel>();
            List<ItemError> retorno = new List<ItemError>();
            ItemError err = new ItemError();
            err.DetalleErrores = new List<string>();

            //recorremos los elementos del excel
            worksheet = excel.Document.Worksheets[0];

            #region construccion de los elementos y validacion
            for(int i=0; i<worksheet.Rows.LastUsedIndex; i++)
            {
                //Row fila = worksheet.Rows[i];
                if (i > 0)
                {
                    bool filaValida = true;
                    CellValue celdaRut = worksheet.GetCellValue(0, i);
                    CellValue celdaNombres = worksheet.GetCellValue(1, i);
                    CellValue celdaApPaterno = worksheet.GetCellValue(2, i);
                    CellValue celdaApMaterno = worksheet.GetCellValue(3, i);
                    CellValue celdaUser = worksheet.GetCellValue(4, i);
                    CellValue celdaTelefono = worksheet.GetCellValue(5, i);
                    CellValue celdaCorreo = worksheet.GetCellValue(6, i);
                    CellValue celdaCurso = worksheet.GetCellValue(7, i);
                    int idCurso = 0;
                    //lo primero
                    if (celdaRut.ToString().Length > 0)
                    {
                        //si estan todos vacios es un registro en blanco
                        if (celdaRut.ToString().Length > 0  && celdaNombres.ToString().Length > 0 && celdaApPaterno.ToString().Length > 0 && 
                            celdaCorreo.ToString().Length > 0 && celdaUser.ToString().Length > 0)
                        {
                            //todo correcto
                            if (VCFramework.NegocioMySQL.Utiles.validarRut(celdaRut.TextValue) == false)
                            {
                                err.DetalleErrores.Add("Rut inválido " + celdaRut.TextValue + " en la fila " + i.ToString());
                                filaValida = false;
                            }
                            //valida si usuario existe
                            List<Entidad.AutentificacionUsuario> listaUs = VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuariosPorInstId(idInst);
                            if (listaUs.Exists(p => p.NombreUsuario == celdaUser.TextValue))
                            {
                                err.DetalleErrores.Add("El nombre de Usuario " + celdaUser.TextValue + " ya existe, revisar  en la fila " + i.ToString());
                                filaValida = false;
                            }
                            //falta validar correo electronico
                            //VALIDACIÓN DEL CURSO
                            if (celdaCurso.ToString().Length > 0)
                            {
                                //buscamos el curso en el sistema
                                Entidad.Curso curso = VCFramework.NegocioMySQL.Curso.ObtenerCursoPorNombre(idInst, celdaCurso.TextValue);
                                if (curso != null && curso.Id > 0)
                                    idCurso = curso.Id;
                                else
                                {
                                    err.DetalleErrores.Add("Curso inválido " + celdaCurso.TextValue + " en la fila " + i.ToString());
                                    filaValida = false;
                                }

                            }
                            
                            if (filaValida)
                            {
                                ItemExcel excelN = new ItemExcel();
                                if (celdaApMaterno.TextValue != null)
                                    excelN.ApellidoMaterno = celdaApMaterno.TextValue;
                                else
                                    excelN.ApellidoMaterno = "";

                                excelN.ApellidoPaterno = celdaApPaterno.TextValue;
                                excelN.Correo = celdaCorreo.TextValue;
                                excelN.Direccion = "";
                                excelN.IdComuna = idComuna;
                                excelN.IdRegion = idRegion;
                                excelN.Nombres = celdaNombres.TextValue;
                                excelN.NombreUsuario = celdaUser.TextValue;
                                if (celdaTelefono.ToString().Length > 0)
                                    excelN.Telefono = celdaTelefono.ToString();
                                else
                                    excelN.Telefono = "";
                                excelN.Rut = celdaRut.TextValue;
                                excelN.IdCurso = idCurso;
                                procesar.Add(excelN);
                                //err.CantidadFilasProcesadas++;
                            }
                            else
                            {
                                //err.CantidadFilasError++;
                            }
                        }
                        else
                        {
                            //celda en blanco

                        }
                    }
                    else
                    {
                        //celda vacía en el rut, no considerar

                    }
                }
            }
            #endregion

            #region procesamiento
            if (procesar.Count > 0)
            {
                foreach (ItemExcel item in procesar)
                {
                    string clave = "";
                    clave = item.Rut.Replace(".", "");
                    clave = item.Rut.Replace("-", "");
                    //supongamos 125353061
                    //dejamos todo el rut para ahorrarnos problemas
                    //clave = clave.Substring(clave.Length - 4, clave.Length - 1).ToString();
                    VCFramework.Entidad.AutentificacionUsuario aus = new Entidad.AutentificacionUsuario();
                    aus.Borrado = false;
                    aus.Eliminado = 0;
                    aus.EsVigente = 1;
                    aus.InstId = idInst;
                    aus.Modificado = false;
                    aus.NombreUsuario = item.NombreUsuario;
                    aus.Nuevo = true;
                    aus.Password = NegocioMySQL.Utiles.Encriptar(clave);
                    aus.RolId = 9;
                    aus.CorreoElectronico = item.Correo;
                    if (idRegion > 0 && idComuna > 0)
                    {
                        Factory fac = new Factory();
                        if (fac.Insertar<VCFramework.Entidad.AutentificacionUsuario>(aus, setCns) > 0)
                        {
                            Entidad.AutentificacionUsuario usuarioGuardado = VCFramework.NegocioMySQL.AutentificacionUsuario.ObtenerUsuario(aus.NombreUsuario, NegocioMySQL.Utiles.DesEncriptar(aus.Password));
                            if (usuarioGuardado != null && usuarioGuardado.Id > 0)
                            {
                                VCFramework.Entidad.Persona persona = new VCFramework.Entidad.Persona();
                                persona.ApellidoMaterno = item.ApellidoMaterno;
                                persona.ApellidoPaterno = item.ApellidoPaterno;
                                persona.Borrado = false;
                                persona.ComId = idComuna;
                                persona.DireccionCompleta = "";
                                persona.Eliminado = 0;
                                persona.InstId = idInst;
                                persona.Modificado = false;
                                persona.Nombres = item.Nombres;
                                persona.Nuevo = true;
                                persona.PaisId = 0;
                                persona.RegId = idRegion;
                                persona.Rut = item.Rut;
                                persona.Telefonos = item.Telefono;
                                persona.UsuId = usuarioGuardado.Id;

                                if (fac.Insertar<VCFramework.Entidad.Persona>(persona, setCns) > 0)
                                {

                                    //guardamos el curso
                                    if (item.IdCurso > 0)
                                    {
                                        Entidad.CursoApoderado cursoAp = new Entidad.CursoApoderado();
                                        cursoAp.CurId = item.IdCurso;
                                        cursoAp.InstId = idInst;
                                        cursoAp.UsuId = usuarioGuardado.Id;
                                        VCFramework.NegocioMySQL.CursoApoderado.Insertar(cursoAp);
                                    }

                                    //todo ok
                                    if (VCFramework.NegocioMySQL.Utiles.ENVIA_CORREO_CREACION_MASIVA() == "1")
                                    {
                                        //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                                        //System.Net.Mail.MailMessage sms = VCFramework.NegocioMySQL.Utiles.ConstruyeMensajeCreacionMasiva(item.NombreUsuario, clave, item.Correo);
                                        //cr.Enviar(sms);
                                        //MANEJO DE TAREAS PARA INDEPENDIZAR ESTE PROCESO
                                        var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(item.NombreUsuario, clave, item.Correo));

                                    }
                                    err.CantidadFilasProcesadas++;
                                }
                                else
                                {
                                    err.DetalleErrores.Add("Error al insertar Persona.");

                                }
                            }
                        }
                        else
                        {
                            err.DetalleErrores.Add("Error al insertar Usuario.");
                        }
                    }
                }
            }
            #endregion

            return err;
        }
        private void EnviarCorreo(string nombreUsuario, string clave, string correo)
        {
            NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
            System.Net.Mail.MailMessage sms = VCFramework.NegocioMySQL.Utiles.ConstruyeMensajeCreacionMasiva(nombreUsuario, clave, correo);
            cr.Enviar(sms);
        }
    }
}