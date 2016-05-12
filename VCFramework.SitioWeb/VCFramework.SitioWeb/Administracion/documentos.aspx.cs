using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Web;
using System.Net.Mail;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class documentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;

                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                    Session["USU_ID"] = usu.AutentificacionUsuario.Id;

                }
                else
                {
                    //retorno
                    Response.Redirect("~/default.aspx");
                }
            }
            else
            {
                //retorno
                Response.Redirect("~/default.aspx");
            }
        }
        const string UploadDirectory = "~/Repositorio/";
        const string UploadDirectoryImg = "~/img/";
        protected void UploadControl_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string randomFile = Path.GetRandomFileName();
            string nomArchivo = randomFile + " " + e.UploadedFile.FileName.Replace("_", " ");

            string resultFileName = Path.ChangeExtension(nomArchivo, resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            string fechaSubida = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            string urlExtension = "";
            switch(resultExtension)
            {
                case ".jpg":
                case ".jpeg":
                    urlExtension = UploadDirectoryImg + "jpeg.png";
                    break;
                case ".gif":
                    urlExtension = UploadDirectoryImg + "gif.png";
                    break;
                case ".png":
                    urlExtension = UploadDirectoryImg + "png.png";
                    break;
                case ".doc":
                case ".docx":
                    urlExtension = UploadDirectoryImg + "word.png";
                    break;
                case ".xls":
                case ".xlsx":
                    urlExtension = UploadDirectoryImg + "excel.png";
                    break;
                case ".pdf":
                    urlExtension = UploadDirectoryImg + "pdf.png";
                    break;
            }

            e.UploadedFile.SaveAs(resultFilePath);

            //if (File.Exists(resultFileName))
            //UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5);

            string name = e.UploadedFile.FileName;
            string url = ResolveClientUrl(resultFileUrl);
            long sizeInKilobytes = e.UploadedFile.ContentLength / 1024;
            string sizeText = sizeInKilobytes.ToString() + " KB";
            GuardarArchivo(nomArchivo, resultFileUrl, sizeInKilobytes, fechaSubida, urlExtension);
            e.CallbackData = name + "|" + url + "|" + sizeText;
        }
        private void GuardarArchivo(string nombreArchivo, string url, long tamano, string fechaSubida, string urlExtension)
        {
            VCFramework.Entidad.Documentos documento = new Entidad.Documentos();
            documento.Borrado = false;
            documento.Eliminado = 0;
            documento.InstId = int.Parse(Session["INST_ID"].ToString());
            documento.Modificado = false;
            documento.NombreArchivo = nombreArchivo;
            documento.Nuevo = true;
            documento.Tamano = Convert.ToInt32(tamano);
            documento.Url = url;
            documento.UsuId = int.Parse(Session["USU_ID"].ToString());
            documento.FechaSubida = fechaSubida;
            documento.Extension = urlExtension;
            VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
            if (fac.Insertar<VCFramework.Entidad.Documentos>(documento) > 0)
            {
                //ahora enviamos correo
                if (NegocioMySQL.Utiles.ENVIA_DOCUMENTOS(documento.InstId) == "1")
                {
                    List<UsuariosCorreos> correos = UsuariosCorreos.ListaUsuariosCorreosPorInstId(documento.InstId);
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
                        UsuarioFuncional usu = new UsuarioFuncional();

                        if (Session["USUARIO_AUTENTICADO"] != null)
                        {
                            usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                        }
                        string mensaje = documento.NombreArchivo;
                        //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                        //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeAgregarDocumento(usu.Institucion.Nombre, mensaje, listaCorreos, true);
                        //cr.Enviar(mnsj);
                        var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usu.Institucion.Nombre, mensaje, listaCorreos, true));
                    }
                }
            }

        }
        private void EnviarCorreo(string nombreInstitucion, string mensaje, List<string> listaCorreos, bool esNuevo)
        {
            NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
            MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeAgregarDocumento(nombreInstitucion, mensaje, listaCorreos, esNuevo);
            cr.Enviar(mnsj);
        }
        private void ModificarArchivo(int id)
        {
            if (id > 0)
            {

                UsuarioFuncional usu = new UsuarioFuncional();

                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                }

                #region eliminar documento
                Entidad.Documentos doc = NegocioMySQL.Documentos.ObtenerDocumentoId(id);

                if (usu.AutentificacionUsuario.Id == doc.UsuId)
                {

                    if (doc != null && doc.Id > 0)
                    {

                        doc.Modificado = true;
                        doc.Nuevo = false;
                        doc.Borrado = false;
                        doc.Eliminado = 1;
                        VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                        if (fac.Update<VCFramework.Entidad.Documentos>(doc) > 0)
                        {
                            //ahora enviamos correo
                            if (NegocioMySQL.Utiles.ENVIA_DOCUMENTOS(doc.InstId) == "1")
                            {
                                List<UsuariosCorreos> correos = UsuariosCorreos.ListaUsuariosCorreosPorInstId(doc.InstId);
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
                                   
                                    string mensaje = doc.NombreArchivo;
                                    //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                                    //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeAgregarDocumento(usu.Institucion.Nombre, mensaje, listaCorreos, false);
                                    //cr.Enviar(mnsj);
                                    var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usu.Institucion.Nombre, mensaje, listaCorreos, false));
                                }
                            }
                        }
                    }
                }
                else
                {
                    
                }
                #endregion
            }
        }
        protected void grillaDocumentos_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters != "")
            {
                if (e.Parameters.Contains("eliminar"))
                {
                    string[] param = e.Parameters.Split('|');
                    int id = int.Parse(param[1]);
                    ModificarArchivo(id);
                }
                ODSLISTADO.DataBind();
                grillaDocumentos.DataBind();
            }
        }

        protected void grillaDocumentos_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Tamano")
            {
                e.Cell.Text = e.CellValue.ToString() + " Kb.";
            }
        }
    }

}