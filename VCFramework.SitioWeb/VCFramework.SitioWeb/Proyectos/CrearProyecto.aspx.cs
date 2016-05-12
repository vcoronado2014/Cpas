using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Web;
using System.Net.Mail;

namespace VCFramework.SitioWeb.Proyectos
{
    public partial class CrearProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["nuevo"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["editar"] != null)
                {

                    hidId.Value = Request.QueryString["id"];
                    Session["PRO_ID"] = int.Parse(Request.QueryString["id"].ToString());
                    //recuperar usuario
                    if (int.Parse(Request.QueryString["id"].ToString()) >= 0)
                    {
                        if (Request.QueryString["editar"].ToString() == "true")
                        {
                            litOperacion.Text = "Modificando ";
                            Recuperar(int.Parse(Request.QueryString["id"].ToString()));
                            btnGuardar.Text = "Modificar";
                            btnLimpiar.ClientVisible = false;
                        }
                        else if (Request.QueryString["nuevo"].ToString() == "true")
                        {
                            litOperacion.Text = "Creando ";
                            CargarDatosNuevo();

                        }
                        else
                        {
                            litOperacion.Text = "Usted va a eliminar este ";
                            Recuperar(int.Parse(Request.QueryString["id"].ToString()));
                            BloquearTodo();
                        }
                    }

                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }

        private void BloquearTodo()
        {
            txtNombreProyecto.ClientEnabled = false;
            memObjetivo.ClientEnabled = false;
            memDescripcion.ClientEnabled = false;
            memBeneficios.ClientEnabled = false;
            txtCosto.ClientEnabled = false;
            dtFechainicio.ClientEnabled = false;
            dtFechaTermino.ClientEnabled = false;
            chkEnviaCorreo.ClientEnabled = false;
            chkNotificaPopup.ClientEnabled = false;
            grillaDocumentos.Enabled = false;
            lblNombreArchivoSubido.ClientEnabled = false;
            upload.Enabled = false;
            btnEliminar.ClientVisible = true;
            btnGuardar.ClientVisible = false;
            btnLimpiar.ClientVisible = false;
        }
        private void Limpiar()
        {
            CargarDatosNuevo();
            txtNombreProyecto.Text = string.Empty;
            memObjetivo.Text = string.Empty;
            memDescripcion.Text = string.Empty;
            memBeneficios.Text = string.Empty;
            txtCosto.Text = string.Empty;
            dtFechainicio.Text = string.Empty;
            dtFechaTermino.Text = string.Empty;
            chkEnviaCorreo.Checked = false;
            chkNotificaPopup.Checked = false;

            //hay que limpiar la grilla
            Session["LISTA_SESION"] = null;
            ODSLISTADO.DataBind();
            grillaDocumentos.DataBind();

            lblNombreArchivoSubido.Text = string.Empty;
            hidId.Value = "0";

        }
        private void EstiloMensaje(Administracion.EstiloMensaje estilo, string mensaje)
        {
            switch (estilo)
            {
                case Administracion.EstiloMensaje.Ok:
                    litMensaje.Font.Size = 12;
                    litMensaje.Font.Bold = true;
                    litMensaje.Text = mensaje;
                    break;
                case Administracion.EstiloMensaje.Advertencia:
                    litMensaje.Font.Size = 13;
                    litMensaje.Font.Bold = true;
                    litMensaje.ForeColor = System.Drawing.Color.Blue;
                    litMensaje.Text = mensaje;
                    break;
                case Administracion.EstiloMensaje.Error:
                    litMensaje.Font.Size = 13;
                    litMensaje.Font.Bold = true;
                    litMensaje.ForeColor = System.Drawing.Color.Red;
                    litMensaje.Text = mensaje;
                    break;
            }
        }
        private void Eliminar(int id)
        {

            if (id > 0)
            {
                UsuarioFuncional usuActual = new UsuarioFuncional();

                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usuActual = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                }

                Entidad.Proyectos entidad = VCFramework.NegocioMySQL.Proyectos.ObtenerProyectosPorId(id)[0];
                if (entidad != null)
                {
                    Entidad.Proyectos entidadEli = new Entidad.Proyectos();
                    entidadEli = entidad;
                    entidadEli.Borrado = false;
                    entidadEli.Nuevo = false;
                    entidadEli.Modificado = true;
                    entidadEli.Eliminado = 1;
                    VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                    if (fac.Update<VCFramework.Entidad.Proyectos>(entidadEli) > 0)
                    {
                        //modificamos al calendario
                        #region modificar calendario
                        //primero lo buscamos
                        List<Entidad.Calendario> listaCal = NegocioMySQL.Calendario.ObtenerCalendarioPorInstId(entidadEli.InstId);
                        Entidad.Calendario cal = new Entidad.Calendario();
                        if (listaCal != null && listaCal.Count > 0)
                        {
                            cal = listaCal.Find(p => p.Detalle == entidadEli.Nombre && p.Tipo == 1);

                        }
                        if (cal != null && cal.Id > 0)
                        {

                            Entidad.Calendario calendario = new Entidad.Calendario();
                            cal.Eliminado = entidadEli.Eliminado;
                            cal.Nuevo = false;
                            cal.Modificado = true;
                            cal.Borrado = false;
                            fac.Update<Entidad.Calendario>(cal);
                        }
                        #endregion
                        List<Entidad.ArchivosProyecto> archivos = NegocioMySQL.ArchivosProyecto.ObtenerArchivosPorProyectoId(id, null);
                        if (archivos != null)
                        {
                            foreach(Entidad.ArchivosProyecto arc in archivos)
                            {
                                arc.Borrado = false;
                                arc.Eliminado = 1;
                                arc.Nuevo = false;
                                arc.Modificado = true;
                                fac.Update<Entidad.ArchivosProyecto>(arc);



                            }
                        }


                        EstiloMensaje(Administracion.EstiloMensaje.Ok, "Proyecto Eliminado con éxito");
                        //ahora los botones
                        btnEliminar.ClientVisible = false;
                    }

                }
            }
        }
        private void Recuperar(int id)
        {
            if (id > 0)
            {
                Entidad.Proyectos entidad = VCFramework.NegocioMySQL.Proyectos.ObtenerProyectosPorId(id)[0];
                if (entidad != null)
                {
                    try
                    {
                        txtNombreProyecto.ClientEnabled = false;
                        UsuarioFuncional usu = new UsuarioFuncional();

                        if (Session["USUARIO_AUTENTICADO"] != null)
                        {
                            usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                        }
                        lblFechaMovimiento.Text = entidad.FechaCreacion.ToShortDateString();
                        lblInstitucion.Text = usu.Institucion.Nombre;
                        lblUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                        txtNombreProyecto.Text = entidad.Nombre;
                        memObjetivo.Text = entidad.Objetivo;
                        memDescripcion.Text = entidad.Descripcion;
                        memBeneficios.Text = entidad.Beneficios;
                        txtCosto.Text = entidad.Costo.ToString();
                        dtFechainicio.Date = entidad.FechaInicio;
                        dtFechaTermino.Date = entidad.FechaTermino;
                        if (entidad.EnviaCorreo == 1)
                            chkEnviaCorreo.Checked = true;
                        if (entidad.NotificaPopup == 1)
                            chkNotificaPopup.Checked = true;

                    }
                    catch (Exception ex)
                    {
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
                        EstiloMensaje(Administracion.EstiloMensaje.Error, ex.Message);
                    }
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "NO ENCONTRADO");
                }

            }
        }
        private void CargarDatosNuevo()
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
            }
            //asignamos
            if (usu.Institucion != null && usu.Institucion.Id > 0)
            {

                if (usu.Rol != null)
                {
                    lblFechaMovimiento.Text = DateTime.Now.ToShortDateString();
                    lblInstitucion.Text = usu.Institucion.Nombre;
                    lblUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Usuario no cuenta con Rol válido");
                }
            }
            else
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Institución no válida");
            }
        }
        private void Insertar(string nombreArchivo)
        {
            bool enviaCorreo = false;
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
            }

            Entidad.Proyectos entidad = new Entidad.Proyectos();
            entidad.Borrado = false;
            entidad.Eliminado = 0;
            entidad.FechaCreacion = DateTime.Now;
            entidad.InstId = usu.AutentificacionUsuario.InstId;
            entidad.Modificado = false;
            entidad.Beneficios = memBeneficios.Text;
            
            if (txtCosto.Text != string.Empty)
                entidad.Costo = int.Parse(txtCosto.Text);
            else
                entidad.Costo = 0;
            entidad.Nuevo = true;
            entidad.Descripcion = memDescripcion.Text;
            if (chkEnviaCorreo.Checked)
            {
                entidad.EnviaCorreo = 1;
                enviaCorreo = true;
            }
            entidad.EsVigente = 1;
            entidad.FechaInicio = dtFechainicio.Date;
            entidad.FechaTermino = dtFechaTermino.Date;
            entidad.FueAprobado = 0;
            entidad.InstId = usu.AutentificacionUsuario.InstId;
            entidad.Nombre = txtNombreProyecto.Text;
            if (chkNotificaPopup.Checked)
                entidad.NotificaPopup = 1;
            entidad.Objetivo = memObjetivo.Text;
            entidad.UsuIdCreador = usu.AutentificacionUsuario.Id;

            //aca hay que trabajar con la lista de archivos
            List<Entidad.Proyectos> proyectos = NegocioMySQL.Proyectos.ObtenerProyectosPorNombreInstId(entidad.Nombre, entidad.InstId);
            if (proyectos != null && proyectos.Count > 0)
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Este nombre de Proyecto ya existe, no se puede crear.");
                return;
            }

            NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

            if (fac.Insertar<Entidad.Proyectos>(entidad) > 0)
            {

                //insertamos al calendario
                #region guardar calendario
                Entidad.Calendario calendario = new Entidad.Calendario();

                calendario.Asunto = entidad.Nombre;
                calendario.Detalle = entidad.Descripcion;
                calendario.Descripcion = entidad.Descripcion;
                calendario.FechaInicio = entidad.FechaInicio;
                calendario.FechaTermino = entidad.FechaTermino;
                calendario.InstId = entidad.InstId;
                calendario.Nuevo = true;
                calendario.Modificado = false;
                calendario.Borrado = false;
                calendario.Titulo = entidad.Nombre;
                calendario.Url = "";
                calendario.Status = 1;
                calendario.Ubicacion = "NO DEFINIDA";
                calendario.Etiqueta = 1;
                calendario.Tipo = 1;
                #endregion

                fac.Insertar<Entidad.Calendario>(calendario);

                if (Session["LISTA_SESION"] != null)
                {
                    List<Entidad.ArchivosProyecto> lista = Session["LISTA_SESION"] as List<Entidad.ArchivosProyecto>;
                    //nos traemos el elemento actual (proyecto)
                    Entidad.Proyectos proyectoGuardado = new Entidad.Proyectos();
                    List<Entidad.Proyectos> listaP = VCFramework.NegocioMySQL.Proyectos.ObtenerProyectosPorInstId(entidad.InstId);
                    if (listaP != null && listaP.Count > 0)
                    {
                        proyectoGuardado = listaP.Find(p => p.FechaInicio == entidad.FechaInicio && p.FechaTermino == entidad.FechaTermino && p.Nombre == entidad.Nombre && p.UsuIdCreador == entidad.UsuIdCreador && p.Objetivo == entidad.Objetivo && p.Descripcion == entidad.Descripcion && p.Beneficios == entidad.Beneficios);
                    }
                    if (proyectoGuardado.Id > 0)
                    {
                        if (lista != null && lista.Count > 0)
                        {
                            foreach(Entidad.ArchivosProyecto arc in lista)
                            {
                                arc.Borrado = false;
                                arc.Eliminado = 0;
                                arc.Modificado = false;
                                arc.Nuevo = true;
                                arc.ProId = proyectoGuardado.Id;
                                fac.Insertar<Entidad.ArchivosProyecto>(arc);
                            }
                        }
                    }

                }
                //ahora enviamos correo
                if (NegocioMySQL.Utiles.ENVIA_PROYECTOS(entidad.InstId) == "1")
                {
                    if (enviaCorreo)
                    {
                        List<UsuariosCorreos> correos = UsuariosCorreos.ListaUsuariosCorreosPorInstId(entidad.InstId);
                        List<string> listaCorreos = new List<string>();
                        if (correos != null && correos.Count > 0)
                        {
                            foreach (UsuariosCorreos us in correos)
                            {
                                listaCorreos.Add(us.Correo);
                            }
                        }
                        if (listaCorreos != null && listaCorreos.Count > 0)
                        {
                            //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                            //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCrearProyecto(usu.Institucion.Nombre, entidad.Nombre, listaCorreos, true);
                            //cr.Enviar(mnsj);
                            var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usu.Institucion.Nombre, entidad.Nombre, listaCorreos, true));
                        }
                    }
                }
                EstiloMensaje(Administracion.EstiloMensaje.Ok, "Registro insertado con éxito");
                //limpiamos
                Limpiar();
            }
            else
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al insertar el proyecto");
            }
            Session["LISTA_SESION"] = null;
        }
        private void Modificar(Entidad.Proyectos obj, string nombreArchivo)
        {
            int id = int.Parse(hidId.Value);
            if (id > 0)
            {
                bool enviaCorreo = false;
                UsuarioFuncional usu = new UsuarioFuncional();

                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                }


                Entidad.Proyectos entidad = new Entidad.Proyectos();
                entidad.Borrado = false;
                //entidad.Detalle = memDetalle.Text;
                entidad.FechaCreacion = obj.FechaCreacion;
                entidad.Eliminado = 0;
                entidad.Beneficios = memBeneficios.Text;
                entidad.Costo = int.Parse(txtCosto.Text);
                entidad.Descripcion = memDescripcion.Text;
                if (chkEnviaCorreo.Checked)
                {
                    entidad.EnviaCorreo = 1;
                    enviaCorreo = true;
                }
                entidad.EsVigente = 1;
                entidad.FechaInicio = dtFechainicio.Date;
                entidad.FechaTermino = dtFechaTermino.Date;
                entidad.FueAprobado = 0;
                entidad.Nombre = obj.Nombre;
                if (chkNotificaPopup.Checked)
                    entidad.NotificaPopup = 1;
                entidad.Objetivo = memObjetivo.Text;
                entidad.UsuIdCreador = obj.UsuIdCreador;
                entidad.Id = obj.Id;
                entidad.InstId = obj.InstId;
                entidad.Modificado = true;

                entidad.Nuevo = false;

                List<Entidad.Proyectos> proyectos = NegocioMySQL.Proyectos.ObtenerProyectosPorNombreInstId(entidad.Nombre, entidad.InstId);
                if (proyectos != null && proyectos.Count > 0)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Este nombre de Proyecto ya existe, no se puede crear.");
                    return;
                }

                NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

                if (fac.Update<Entidad.Proyectos>(entidad) > 0)
                {

                    //modificamos al calendario
                    #region modificar calendario
                    //primero lo buscamos
                    List<Entidad.Calendario> listaCal = NegocioMySQL.Calendario.ObtenerCalendarioPorInstId(entidad.InstId);
                    Entidad.Calendario cal = new Entidad.Calendario();
                    if (listaCal != null && listaCal.Count > 0)
                    {
                        cal = listaCal.Find(p => p.Detalle == entidad.Nombre);

                    }
                    if (cal != null && cal.Id > 0)
                    {
                        cal.Detalle = entidad.Descripcion;
                        cal.Asunto = entidad.Nombre;
                        cal.FechaInicio = entidad.FechaInicio;
                        cal.FechaTermino = entidad.FechaTermino;
                        cal.InstId = entidad.InstId;
                        cal.Nuevo = false;
                        cal.Modificado = true;
                        cal.Borrado = false;
                        cal.Titulo = entidad.Nombre;
                        fac.Update<Entidad.Calendario>(cal);
                        
                    }
                    #endregion


                    if (NegocioMySQL.Utiles.ENVIA_PROYECTOS(entidad.InstId) == "1")
                    {
                        //ahora enviamos correo
                        if (enviaCorreo)
                        {
                            List<UsuariosCorreos> correos = UsuariosCorreos.ListaUsuariosCorreosPorInstId(entidad.InstId);
                            List<string> listaCorreos = new List<string>();
                            if (correos != null && correos.Count > 0)
                            {
                                foreach (UsuariosCorreos us in correos)
                                {
                                    listaCorreos.Add(us.Correo);
                                }
                            }
                            if (listaCorreos != null && listaCorreos.Count > 0)
                            {
                                //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                                //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCrearProyecto(usu.Institucion.Nombre, entidad.Nombre, listaCorreos, false);
                                //cr.Enviar(mnsj);
                                var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usu.Institucion.Nombre, entidad.Nombre, listaCorreos, false));
                            }
                        }
                    }
                    ODSLISTADO.DataBind();
                    grillaDocumentos.DataBind();
                    EstiloMensaje(Administracion.EstiloMensaje.Ok, "Modificado con éxito");
                    Recuperar(id);
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al guardar el movimiento");
                }
            }
        }
        private void EnviarCorreo(string nombreInstitucion, string mensaje, List<string> listaCorreos, bool esNuevo)
        {
            NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
            MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCrearProyecto(nombreInstitucion, mensaje, listaCorreos, esNuevo);
            cr.Enviar(mnsj);
        }
        protected void pnlGeneral_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter.Contains("subir"))
            {
                string[] param = e.Parameter.Split('|');
                lblNombreArchivoSubido.Text = param[1];
                if (int.Parse(Request.QueryString["id"].ToString()) > 0)
                {
                    int proId = int.Parse(hidId.Value.ToString());
                    Entidad.ArchivosProyecto arc = new Entidad.ArchivosProyecto();
                    arc.RutaArchivo = param[1];
                    arc.ProId = proId;
                    arc.Nuevo = true;
                    arc.Modificado = false;
                    arc.Borrado = false;
                    NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                    fac.Insertar<Entidad.ArchivosProyecto>(arc);
                    ODSLISTADO.DataBind();
                    grillaDocumentos.DataBind();

                }
                else
                {
                    if (Session["LISTA_SESION"] == null)
                    {
                        List<Entidad.ArchivosProyecto> archivos = new List<Entidad.ArchivosProyecto>();
                        Entidad.ArchivosProyecto arc = new Entidad.ArchivosProyecto();
                        arc.RutaArchivo = param[1];
                        archivos.Add(arc);

                        Session["LISTA_SESION"] = archivos;
                    }
                    else
                    {
                        List<Entidad.ArchivosProyecto> archivos = Session["LISTA_SESION"] as List<Entidad.ArchivosProyecto>;
                        Entidad.ArchivosProyecto arc = new Entidad.ArchivosProyecto();
                        arc.RutaArchivo = param[1];
                        archivos.Add(arc);

                        Session["LISTA_SESION"] = archivos;
                    }
                    ODSLISTADO.DataBind();
                    grillaDocumentos.DataBind();
                }

            }
            else if (e.Parameter.Contains("guardar"))
            {
                string[] param = e.Parameter.Split('|');

                try
                {

                    Entidad.Proyectos obj = VCFramework.NegocioMySQL.Proyectos.ObtenerProyectosPorId(int.Parse(hidId.Value.ToString()))[0];
                    Modificar(obj, param[1]);
                }
                catch (Exception ex)
                {
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede guardar!");
                }

            }
            else if (e.Parameter.Contains("eliminar"))
            {
                //Limpiar();
                Eliminar(int.Parse(hidId.Value.ToString()));
            }
            else if (e.Parameter.Contains("limpiar"))
            {
                Limpiar();
            }
            else
            {
                //nuevo registro
                string[] param = e.Parameter.Split('|');

                try
                {
                    Insertar(param[1]);
                }
                catch (Exception ex)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, contacte al administrador. " + ex.Message);
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                }


            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
        const string UploadDirectory = "~/ArchivosProyectos/";
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
        }

        protected void grillaDocumentos_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

            if (e.Parameters != "")
            {

                if (e.Parameters.Contains("eliminar"))
                {
                    string[] param = e.Parameters.Split('|');
                    int id = int.Parse(param[1]);
                    Entidad.ArchivosProyecto archivo = NegocioMySQL.ArchivosProyecto.ObtenerArchivoPorId(id)[0];
                    if (archivo != null)
                    {
                        archivo.Borrado = false;
                        archivo.Nuevo = false;
                        archivo.Modificado = true;
                        archivo.Eliminado = 1;
                        NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                        fac.Update<Entidad.ArchivosProyecto>(archivo);
                    }
                }
                ODSLISTADO.DataBind();
                grillaDocumentos.DataBind();
            }
        }

        protected void grillaDocumentos_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "RutaArchivo")
            {
                e.Cell.Text = e.CellValue.ToString().Replace("~/ArchivosProyectos/", "");

            }
        }
    }
 
}