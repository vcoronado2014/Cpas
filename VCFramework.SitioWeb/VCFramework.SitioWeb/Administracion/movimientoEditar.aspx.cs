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
    public partial class movimientoEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["nuevo"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["editar"] != null)
                {

                    hidId.Value = Request.QueryString["id"];

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
            cmbTipoMovimiento.ClientEnabled = false;
            txtNumeroComprobante.ClientEnabled = false;
            txtMonto.ClientEnabled = false;
            memDetalle.ClientEnabled = false;
            lblNombreArchivoSubido.ClientEnabled = false;
            upload.Enabled = false;
            btnEliminar.ClientVisible = true;
            btnGuardar.ClientVisible = false;
            btnLimpiar.ClientVisible = false;
        }
        private void Limpiar()
        {
            CargarDatosNuevo();
            cmbTipoMovimiento.SelectedIndex = -1;
            txtNumeroComprobante.Text = string.Empty;
            txtMonto.Text = string.Empty;
            memDetalle.Text = string.Empty;
            lblNombreArchivoSubido.Text = string.Empty;
            hidId.Value = "0";

        }
        private void EstiloMensaje(EstiloMensaje estilo, string mensaje)
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

                EntidadFuniconal.IngresoEgresoFuncional entidad = VCFramework.NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorId(id);
                if (entidad != null)
                {
                    Entidad.IngresoEgreso entidadEli = new Entidad.IngresoEgreso();
                    entidadEli = entidad;
                    entidadEli.Borrado = false;
                    entidadEli.Nuevo = false;
                    entidadEli.Modificado = true;
                    entidadEli.Eliminado = 1;
                    VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                    if (fac.Update<VCFramework.Entidad.IngresoEgreso>(entidadEli) > 0)
                    {
                        EstiloMensaje(Administracion.EstiloMensaje.Ok, "Movimiento Eliminado con éxito");
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
                EntidadFuniconal.IngresoEgresoFuncional entidad = VCFramework.NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorId(id);
                if (entidad != null)
                {
                    try
                    {
                        cmbTipoMovimiento.ClientEnabled = false;
                        lblFechaMovimiento.Text = entidad.FechaMovimiento.ToShortDateString();
                        cmbTipoMovimiento.Value = entidad.TipoMovimiento.ToString();
                        txtNumeroComprobante.Text = entidad.NumeroComprobante.ToString();
                        memDetalle.Text = entidad.Detalle;
                        txtMonto.Text = entidad.Monto.ToString();
                        if (entidad.UrlDocumento != null && entidad.UrlDocumento.Length > 0)
                        {
                            lblNombreArchivoSubido.Text = entidad.UrlDocumento;
                        }

                    }
                    catch(Exception ex)
                    {
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
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
            }

            Entidad.IngresoEgreso entidad = new Entidad.IngresoEgreso();
            entidad.Borrado = false;
            entidad.Detalle = memDetalle.Text;
            entidad.Eliminado = 0;
            entidad.FechaMovimiento = DateTime.Now;
            entidad.InstId = usu.AutentificacionUsuario.InstId;
            entidad.Modificado = false;
            if (txtMonto.Text != string.Empty)
                entidad.Monto = int.Parse(txtMonto.Text);
            else
                entidad.Monto = 0;
            entidad.Nuevo = true;
            entidad.NumeroComprobante = txtNumeroComprobante.Text;
            entidad.TipoMovimiento = int.Parse(cmbTipoMovimiento.Value.ToString());
            entidad.UrlDocumento = nombreArchivo;
            entidad.UsuId = usu.AutentificacionUsuario.Id;

            NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

            if (fac.Insertar<Entidad.IngresoEgreso>(entidad) > 0)
            {

                if (NegocioMySQL.Utiles.ENVIA_RENDICIONES(entidad.InstId) == "1")
                {
                    //ahora enviamos correo
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
                        string mensaje = "Monto: " + entidad.Monto.ToString() + ", N° Comprobante: " + entidad.NumeroComprobante;
                        //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                        //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCrearRendicion(usu.Institucion.Nombre, mensaje, listaCorreos, true);
                        //cr.Enviar(mnsj);
                        var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usu.Institucion.Nombre, mensaje, listaCorreos, true));
                    }
                }
                EstiloMensaje(Administracion.EstiloMensaje.Ok, "Registro insertado con éxito");
                //limpiamos
                Limpiar();
            }
            else
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al insertar el movimiento");
            }
        }
        private void EnviarCorreo(string nombreInstitucion, string mensaje, List<string> listaCorreos, bool esNuevo)
        {
            NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
            MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCrearRendicion(nombreInstitucion, mensaje, listaCorreos, esNuevo);
            cr.Enviar(mnsj);
        }
        private void Modificar(EntidadFuniconal.IngresoEgresoFuncional obj, string nombreArchivo)
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

                Entidad.IngresoEgreso entidad = new Entidad.IngresoEgreso();
                entidad.Borrado = false;
                entidad.Detalle = memDetalle.Text;
                entidad.Eliminado = 0;
                entidad.FechaMovimiento = DateTime.Now;
                entidad.Id = obj.Id;
                entidad.InstId = obj.InstId;
                entidad.Modificado = true;
                if (txtMonto.Text != string.Empty)
                    entidad.Monto = int.Parse(txtMonto.Text);
                else
                    entidad.Monto = 0;
                entidad.Nuevo = false;
                entidad.NumeroComprobante = txtNumeroComprobante.Text;
                entidad.TipoMovimiento = int.Parse(cmbTipoMovimiento.Value.ToString());
                entidad.UrlDocumento = nombreArchivo;
                entidad.UsuId = obj.UsuId;

                NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

                if (fac.Update<Entidad.IngresoEgreso>(entidad) > 0)
                {
                    if (NegocioMySQL.Utiles.ENVIA_RENDICIONES(entidad.InstId) == "1")
                    {
                        //ahora enviamos correo
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
                            string mensaje = "Monto: " + entidad.Monto.ToString() + ", N° Comprobante: " + entidad.NumeroComprobante;
                            //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                            //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCrearRendicion(usu.Institucion.Nombre, mensaje, listaCorreos, false);
                            //cr.Enviar(mnsj);
                            var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usu.Institucion.Nombre, mensaje, listaCorreos, false));
                        }
                    }
                    EstiloMensaje(Administracion.EstiloMensaje.Ok, "Modificado con éxito");
                    Recuperar(id);
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al guardar el movimiento");
                }
            }
        }
        protected void pnlGeneral_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter.Contains("subir"))
            {
                string[] param = e.Parameter.Split('|');
                lblNombreArchivoSubido.Text = param[1];

            }
            else if (e.Parameter.Contains("guardar"))
            {
                string[] param = e.Parameter.Split('|');
                
                try
                {

                    EntidadFuniconal.IngresoEgresoFuncional obj = VCFramework.NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorId(int.Parse(hidId.Value.ToString()));
                    Modificar(obj, param[1]);
                }
                catch(Exception ex)
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
                catch(Exception ex)
                {
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
                }


            }
           
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoEgreso.aspx");
        }
        const string UploadDirectory = "~/Boletas/";
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
    }
}