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
using VCFramework.Negocio.Factory;

namespace VCFramework.SitioWeb.Tricel
{
    public partial class CrearTricel : System.Web.UI.Page
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];

        protected void Page_Load(object sender, EventArgs e)
        {
            #region validacion usuario
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
            #endregion

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["nuevo"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["editar"] != null)
                {

                    hidId.Value = Request.QueryString["id"];
                    Session["TRI_ID"] = int.Parse(Request.QueryString["id"].ToString());
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
            //memDescripcion.ClientEnabled = false;
            //memBeneficios.ClientEnabled = false;
            dtFechainicio.ClientEnabled = false;
            dtFechaTermino.ClientEnabled = false;
            txtResponsables.Enabled = false;
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
            //memDescripcion.Text = string.Empty;
            //memBeneficios.Text = string.Empty;
            dtFechainicio.Text = string.Empty;
            dtFechaTermino.Text = string.Empty;
            txtResponsables.Text = string.Empty;
            //hay que limpiar la grilla
            Session["LISTA_SESION_TRI"] = null;
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

                Entidad.Tricel entidad = VCFramework.NegocioMySQL.Tricel.ObtenerTricelPorId(id)[0];
                if (entidad != null)
                {
                    Entidad.Tricel entidadEli = new Entidad.Tricel();
                    entidadEli = entidad;
                    entidadEli.Borrado = false;
                    entidadEli.Nuevo = false;
                    entidadEli.Modificado = true;
                    entidadEli.Eliminado = 1;
                    Factory fac = new Factory();
                    if (fac.Update<VCFramework.Entidad.Tricel>(entidadEli, setCns) > 0)
                    {
                        //modificamos al calendario
                        #region modificar calendario
                        //primero lo buscamos
                        List<Entidad.Calendario> listaCal = NegocioMySQL.Calendario.ObtenerCalendarioPorInstId(entidadEli.InstId);
                        Entidad.Calendario cal = new Entidad.Calendario();
                        if (listaCal != null && listaCal.Count > 0)
                        {
                            cal = listaCal.Find(p => p.Detalle == entidadEli.Nombre);

                        }
                        if (cal != null && cal.Id > 0)
                        {

                            Entidad.Calendario calendario = new Entidad.Calendario();
                            cal.Eliminado = entidadEli.Eliminado;
                            cal.Nuevo = false;
                            cal.Modificado = true;
                            cal.Borrado = false;
                            fac.Update<Entidad.Calendario>(cal, setCns);
                        }
                        #endregion
                        List<Entidad.ArchivosTricel> archivos = NegocioMySQL.ArchivosTricel.ObtenerArchivosPorTricelId(id, null);
                        if (archivos != null)
                        {
                            foreach (Entidad.ArchivosTricel arc in archivos)
                            {
                                arc.Borrado = false;
                                arc.Eliminado = 1;
                                arc.Nuevo = false;
                                arc.Modificado = true;
                                fac.Update<Entidad.ArchivosTricel>(arc, setCns);



                            }
                        }


                        EstiloMensaje(Administracion.EstiloMensaje.Ok, "Tricel Eliminado con éxito");
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
                Entidad.Tricel entidad = VCFramework.NegocioMySQL.Tricel.ObtenerTricelPorId(id)[0];
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
                        //memDescripcion.Text = entidad.Descripcion;
                        //memBeneficios.Text = entidad.Beneficios;
                        dtFechainicio.Date = entidad.FechaInicio;
                        dtFechaTermino.Date = entidad.FechaTermino;
                        //obtencion de los  responsables
                        List<Entidad.ResponsableTricel> resp = NegocioMySQL.ResponsableTricel.ObtenerResponsables(id);
                        StringBuilder cursos = new StringBuilder();

                        if (resp != null && resp.Count > 0)
                        {
                            foreach (Entidad.ResponsableTricel cur in resp)
                            {
                                //listita.Add(cur.Id.ToString());
                                cursos.Append(cur.UsuId.ToString());
                                cursos.Append(",");
                            }

                        }
                        txtResponsables.Value = cursos.ToString();

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

            Entidad.Tricel entidad = new Entidad.Tricel();
            entidad.Borrado = false;
            entidad.Eliminado = 0;
            entidad.FechaCreacion = DateTime.Now;
            entidad.InstId = usu.AutentificacionUsuario.InstId;
            entidad.Modificado = false;
           // entidad.Beneficios = memBeneficios.Text;

            entidad.Nuevo = true;
            //entidad.Descripcion = memDescripcion.Text;

            entidad.EsVigente = 1;
            entidad.FechaInicio = dtFechainicio.Date;
            entidad.FechaTermino = dtFechaTermino.Date;

            entidad.InstId = usu.AutentificacionUsuario.InstId;
            entidad.Nombre = txtNombreProyecto.Text;

            entidad.Objetivo = memObjetivo.Text;
            entidad.UsuIdCreador = usu.AutentificacionUsuario.Id;

            //aca hay que trabajar con la lista de archivos

            Factory fac = new Factory();
            int ID_TRICEL = fac.Insertar<Entidad.Tricel>(entidad, setCns);

            if (ID_TRICEL > 0)
            {

                //insertamos al calendario
                #region guardar calendario
                Entidad.Calendario calendario = new Entidad.Calendario();

                calendario.Asunto = entidad.Nombre;
                calendario.Detalle = entidad.Nombre;
                calendario.Descripcion = entidad.Objetivo;
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

                fac.Insertar<Entidad.Calendario>(calendario, setCns);

                if (Session["LISTA_SESION_TRI"] != null)
                {
                    List<Entidad.ArchivosTricel> lista = Session["LISTA_SESION_TRI"] as List<Entidad.ArchivosTricel>;
                    //nos traemos el elemento actual (proyecto)
                    //Entidad.Tricel proyectoGuardado = new Entidad.Tricel();
                    //List<Entidad.Tricel> listaP = VCFramework.NegocioMySQL.Tricel.ObtenerTricelPorInstId(entidad.InstId);
                    //if (listaP != null && listaP.Count > 0)
                    //{
                    //    proyectoGuardado = listaP.Find(p => p.FechaInicio == entidad.FechaInicio && p.FechaTermino == entidad.FechaTermino && p.Nombre == entidad.Nombre && p.UsuIdCreador == entidad.UsuIdCreador && p.Objetivo == entidad.Objetivo && p.Descripcion == entidad.Descripcion && p.Beneficios == entidad.Beneficios);
                    //}
                    if (ID_TRICEL > 0)
                    {
                        if (lista != null && lista.Count > 0)
                        {
                            foreach (Entidad.ArchivosTricel arc in lista)
                            {
                                arc.Borrado = false;
                                arc.Eliminado = 0;
                                arc.Modificado = false;
                                arc.Nuevo = true;
                                arc.TriId = ID_TRICEL;
                                fac.Insertar<Entidad.ArchivosTricel>(arc, setCns);
                            }
                        }
                    }

                }
                //los responsables
                #region manejo de los responsables
                string[] responsables = txtResponsables.Value.ToString().Split(',');

                try
                {
                    if (responsables != null && responsables.Length > 0)
                    {
                        List<Entidad.ResponsableTricel> listaP = NegocioMySQL.ResponsableTricel.ObtenerResponsables(ID_TRICEL);
                        if (listaP != null && listaP.Count > 0)
                        {
                            foreach (Entidad.ResponsableTricel cur in listaP)
                            {
                                VCFramework.NegocioMySQL.ResponsableTricel.Eliminar(cur);
                            }
                        }
                    }
                    //ahora las volvemos a crear
                    if (responsables.Length > 0 && responsables != null)
                    {
                        foreach (string s in responsables)
                        {
                            if (s != "")
                            {
                                int idUsu = int.Parse(s);
                                Entidad.ResponsableTricel resp = new Entidad.ResponsableTricel();
                                resp.Eliminado = 0;
                                resp.TriId = ID_TRICEL;
                                resp.UsuId = idUsu;
                                VCFramework.NegocioMySQL.ResponsableTricel.Insertar(resp);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                }

                #endregion


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
            Session["LISTA_SESION_TRI"] = null;
        }
        private void Modificar(Entidad.Tricel obj, string nombreArchivo)
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


                Entidad.Tricel entidad = new Entidad.Tricel();
                entidad.Borrado = false;
                //entidad.Detalle = memDetalle.Text;
                entidad.FechaCreacion = obj.FechaCreacion;
                entidad.Eliminado = 0;
                //entidad.Beneficios = memBeneficios.Text;
                //entidad.Descripcion = memDescripcion.Text;

                entidad.EsVigente = 1;
                entidad.FechaInicio = dtFechainicio.Date;
                entidad.FechaTermino = dtFechaTermino.Date;

                entidad.Nombre = obj.Nombre;

                entidad.Objetivo = memObjetivo.Text;
                entidad.UsuIdCreador = obj.UsuIdCreador;
                entidad.Id = obj.Id;
                entidad.InstId = obj.InstId;
                entidad.Modificado = true;

                entidad.Nuevo = false;

                Factory fac = new Factory();

                if (fac.Update<Entidad.Tricel>(entidad, setCns) > 0)
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
                        cal.Detalle = entidad.Nombre;
                        cal.Asunto = entidad.Nombre;
                        cal.FechaInicio = entidad.FechaInicio;
                        cal.FechaTermino = entidad.FechaTermino;
                        cal.InstId = entidad.InstId;
                        cal.Nuevo = false;
                        cal.Modificado = true;
                        cal.Borrado = false;
                        cal.Titulo = entidad.Nombre;
                        fac.Update<Entidad.Calendario>(cal, setCns);

                    }
                    #endregion
                    //los responsables
                    #region manejo de los responsables
                    string[] responsables = txtResponsables.Value.ToString().Split(',');

                    try
                    {
                        if (responsables != null && responsables.Length > 0)
                        {
                            List<Entidad.ResponsableTricel> listaP = NegocioMySQL.ResponsableTricel.ObtenerResponsables(obj.Id);
                            if (listaP != null && listaP.Count > 0)
                            {
                                foreach (Entidad.ResponsableTricel cur in listaP)
                                {
                                    VCFramework.NegocioMySQL.ResponsableTricel.Eliminar(cur);
                                }
                            }
                        }
                        //ahora las volvemos a crear
                        if (responsables.Length > 0 && responsables != null)
                        {
                            foreach (string s in responsables)
                            {
                                if (s != "")
                                {
                                    int idUsu = int.Parse(s);
                                    Entidad.ResponsableTricel resp = new Entidad.ResponsableTricel();
                                    resp.Eliminado = 0;
                                    resp.TriId = obj.Id;
                                    resp.UsuId = idUsu;
                                    VCFramework.NegocioMySQL.ResponsableTricel.Insertar(resp);
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
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
                    Entidad.ArchivosTricel arc = new Entidad.ArchivosTricel();
                    arc.RutaArchivo = param[1];
                    arc.TriId = proId;
                    arc.Nuevo = true;
                    arc.Modificado = false;
                    arc.Borrado = false;
                    Factory fac = new Factory();
                    fac.Insertar<Entidad.ArchivosTricel>(arc, setCns);
                    ODSLISTADO.DataBind();
                    grillaDocumentos.DataBind();

                }
                else
                {
                    if (Session["LISTA_SESION_TRI"] == null)
                    {
                        List<Entidad.ArchivosTricel> archivos = new List<Entidad.ArchivosTricel>();
                        Entidad.ArchivosTricel arc = new Entidad.ArchivosTricel();
                        arc.RutaArchivo = param[1];
                        archivos.Add(arc);

                        Session["LISTA_SESION_TRI"] = archivos;
                    }
                    else
                    {
                        List<Entidad.ArchivosTricel> archivos = Session["LISTA_SESION_TRI"] as List<Entidad.ArchivosTricel>;
                        Entidad.ArchivosTricel arc = new Entidad.ArchivosTricel();
                        arc.RutaArchivo = param[1];
                        archivos.Add(arc);

                        Session["LISTA_SESION_TRI"] = archivos;
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

                    Entidad.Tricel obj = VCFramework.NegocioMySQL.Tricel.ObtenerTricelPorId(int.Parse(hidId.Value.ToString()))[0];
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
            Response.Redirect("ListadoTricel.aspx");
        }
        const string UploadDirectory = "~/ArchivosTricel/";
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
                    Entidad.ArchivosTricel archivo = NegocioMySQL.ArchivosTricel.ObtenerArchivoPorId(id)[0];
                    if (archivo != null)
                    {
                        archivo.Borrado = false;
                        archivo.Nuevo = false;
                        archivo.Modificado = true;
                        archivo.Eliminado = 1;
                        Factory fac = new Factory();
                        fac.Update<Entidad.ArchivosTricel>(archivo, setCns);
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
                e.Cell.Text = e.CellValue.ToString().Replace("~/ArchivosTricel/", "");

            }
        }
    }
}
