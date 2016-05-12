using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Tricel
{
    public partial class CrearLista : System.Web.UI.Page
    {
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
                
                if (Request.QueryString["id"] != null && Request.QueryString["nuevo"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["editar"] != null && Request.QueryString["TRI_ID"] != null)
                {

                    hidId.Value = Request.QueryString["id"];
                    Session["TRI_ID"] = int.Parse(Request.QueryString["TRI_ID"].ToString());
                    CargarCombos();
                    ////recuperar usuario
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
                            //CargarDatosNuevo();

                        }
                        else
                        {
                            litOperacion.Text = "Usted va a eliminar esta ";
                            Recuperar(int.Parse(Request.QueryString["id"].ToString()));
                            btnEliminar.ClientEnabled = true;
                            BloquearTodo();
                        }
                    }
                }

            }
            else
            {
                //Response.Redirect("~/default.aspx");
            }

        }
        private void BloquearTodo()
        {
            //pnlGeneral.Enabled = false;
            dtFechainicio.ClientEnabled = false;
            dtFechaTermino.ClientEnabled = false;
            txtNombreProyecto.ClientEnabled = false;
            memObjetivo.ClientEnabled = false;
            memBeneficios.ClientEnabled = false;
            memDescripcion.ClientEnabled = false;
            cmbPresidente.ClientEnabled = false;
            cmbVicepresidente.ClientEnabled = false;
            cmbTesorero.ClientEnabled = false;
            cmbSecretario.ClientEnabled = false;
            cmbOtro1.ClientEnabled = false;
            cmbOtro2.ClientEnabled = false;
            cmbOtro3.ClientEnabled = false;
            cmbOtro4.ClientEnabled = false;
            cmbOtro6.ClientEnabled = false;
            cmbOtro7.ClientEnabled = false;
            btnEliminar.ClientVisible = true;
            btnGuardar.ClientVisible = false;
            btnLimpiar.ClientVisible = false;
        }
        public void CargarCombos()
        {
            int instId = int.Parse(Session["INST_ID"].ToString());
            int usuId = int.Parse(Session["USU_ID"].ToString());
            int triId = int.Parse(Session["TRI_ID"].ToString());
            List<UsuarioEnvoltorio> lista = LogicLogin.ListarUsuariosEnvoltorioLista(instId, usuId, triId);
            cmbPresidente.DataSource = lista;
            cmbPresidente.DataBind();
            cmbVicepresidente.DataSource = lista;
            cmbVicepresidente.DataBind();
            cmbSecretario.DataSource = lista;
            cmbSecretario.DataBind();
            cmbTesorero.DataSource = lista;
            cmbTesorero.DataBind();
            cmbOtro1.DataSource = lista;
            cmbOtro1.DataBind();
            cmbOtro2.DataSource = lista;
            cmbOtro2.DataBind();
            cmbOtro3.DataSource = lista;
            cmbOtro3.DataBind();
            cmbOtro4.DataSource = lista;
            cmbOtro4.DataBind();
            cmbOtro6.DataSource = lista;
            cmbOtro6.DataBind();
            cmbOtro7.DataSource = lista;
            cmbOtro7.DataBind();
            

        }
        private void Insertar()
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
            }

            Entidad.ListaTricel entidad = new Entidad.ListaTricel();
            entidad.Borrado = false;
            entidad.Eliminado = 0;

            entidad.Modificado = false;
            entidad.Beneficios = memBeneficios.Text;

            entidad.Nuevo = true;
            entidad.Descripcion = memDescripcion.Text;


            entidad.InstId = usu.AutentificacionUsuario.InstId;
            entidad.Nombre = txtNombreProyecto.Text;

            entidad.Objetivo = memObjetivo.Text;
            entidad.RptId = usu.AutentificacionUsuario.Id;
            entidad.Rol = "Administrador";
            entidad.TriId = int.Parse(Session["TRI_ID"].ToString());
            entidad.UsuId = usu.AutentificacionUsuario.Id;
            entidad.FechaInicio = dtFechainicio.Date;
            entidad.FechaTermino = dtFechaTermino.Date;

            List<Entidad.ListaTricel> proyectos = NegocioMySQL.ListaTricel.ObtenerListaPorNombreInstId(entidad.Nombre, entidad.InstId);
            if (proyectos != null && proyectos.Count > 0)
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Este nombre de Lista ya existe, no se puede crear.");
                return;
            }

            List<Entidad.Tricel> tricel = NegocioMySQL.Tricel.ObtenerTricelPorId(entidad.TriId);
            if (dtFechainicio.Date < tricel[0].FechaInicio)
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "La fecha de Inicio de la lista no puede ser menor a la del Tricel.");
                return;
            }
            if (dtFechaTermino.Date > tricel[0].FechaTermino)
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "La fecha de término de la lista no puede ser mayor a la del Tricel.");
                return;
            }
            //aca hay que trabajar con la lista de archivos

            NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
            int ID_LISTA = fac.Insertar<Entidad.ListaTricel>(entidad);

            if (ID_LISTA > 0)
            {
                //GUARDAMOS LOS USUARIOS
                if (cmbPresidente.Value != null && int.Parse(cmbPresidente.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuarioPresidente = new Entidad.UsuarioLista();
                    usuarioPresidente.LtrId = ID_LISTA;
                    usuarioPresidente.Rol = "Presidente";
                    usuarioPresidente.UsuId = int.Parse(cmbPresidente.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuarioPresidente);
                }
                if (cmbVicepresidente.Value != null && int.Parse(cmbVicepresidente.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Vicepresidente";
                    usuario.UsuId = int.Parse(cmbVicepresidente.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbSecretario.Value != null && int.Parse(cmbSecretario.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Secretario";
                    usuario.UsuId = int.Parse(cmbSecretario.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbTesorero.Value != null && int.Parse(cmbTesorero.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Tesorero";
                    usuario.UsuId = int.Parse(cmbTesorero.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbOtro1.Value != null && int.Parse(cmbOtro1.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Otro1";
                    usuario.UsuId = int.Parse(cmbOtro1.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbOtro2.Value != null && int.Parse(cmbOtro2.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Otro2";
                    usuario.UsuId = int.Parse(cmbOtro2.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbOtro3.Value != null && int.Parse(cmbOtro3.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Otro3";
                    usuario.UsuId = int.Parse(cmbOtro3.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbOtro4.Value != null && int.Parse(cmbOtro4.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Otro4";
                    usuario.UsuId = int.Parse(cmbOtro4.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbOtro6.Value != null && int.Parse(cmbOtro6.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Otro6";
                    usuario.UsuId = int.Parse(cmbOtro6.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                if (cmbOtro7.Value != null && int.Parse(cmbOtro7.Value.ToString()) > 0)
                {
                    Entidad.UsuarioLista usuario = new Entidad.UsuarioLista();
                    usuario.LtrId = ID_LISTA;
                    usuario.Rol = "Otro7";
                    usuario.UsuId = int.Parse(cmbOtro7.Value.ToString());
                    fac.Insertar<Entidad.UsuarioLista>(usuario);
                }
                EstiloMensaje(Administracion.EstiloMensaje.Ok, "Registro insertado con éxito");
                //limpiamos
                //guardamos en el calendario
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
                //ponemos tipo 5 para poder eliminarflo despues
                calendario.Tipo = 5;
                #endregion
                Limpiar();
            }
            else
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al insertar la lista");
            }

        }

        private void Modificar(Entidad.ListaTricel obj)
        {
            int id = int.Parse(hidId.Value);
            if (id > 0)
            {
                UsuarioFuncional usu = new UsuarioFuncional();

                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                }


                Entidad.ListaTricel entidad = new Entidad.ListaTricel();
                entidad.Borrado = false;

                entidad.Eliminado = 0;
                entidad.Beneficios = memBeneficios.Text;
                entidad.Descripcion = memDescripcion.Text;

                entidad.Nombre = obj.Nombre;

                entidad.Objetivo = memObjetivo.Text;
                entidad.Rol = "Administrador";
                entidad.Id = obj.Id;
                entidad.RptId = usu.AutentificacionUsuario.Id;
                entidad.UsuId = usu.AutentificacionUsuario.Id;
                entidad.InstId = obj.InstId;
                entidad.Modificado = true;
                entidad.TriId = obj.TriId;
                entidad.FechaInicio = dtFechainicio.Date;
                entidad.FechaTermino = dtFechaTermino.Date;

                entidad.Nuevo = false;

                List<Entidad.ListaTricel> proyectos = NegocioMySQL.ListaTricel.ObtenerListaPorNombreInstId(entidad.Nombre, entidad.InstId);
                if (proyectos != null && proyectos.Count > 0)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Este nombre de Lista ya existe, no se puede crear.");
                    return;
                }

                List<Entidad.Tricel> tricel = NegocioMySQL.Tricel.ObtenerTricelPorId(obj.TriId);

                if (dtFechainicio.Date < tricel[0].FechaInicio)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "La fecha de Inicio de la lista no puede ser menor a la del Tricel.");
                    return;
                }
                if (dtFechaTermino.Date > tricel[0].FechaTermino)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "La fecha de término de la lista no puede ser mayor a la del Tricel.");
                    return;
                }
                NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

                if (fac.Update<Entidad.ListaTricel>(entidad) > 0)
                {

                    //guardamos los usuarios de la lista
                    #region presidente
                    if (cmbPresidente.Value != null && cmbPresidente.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbPresidente.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Presidente", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Presidente";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Presidente", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region vicepresidente
                    if (cmbVicepresidente.Value != null && cmbVicepresidente.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbVicepresidente.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Vicepresidente", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Vicepresidente";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Vicepresidente", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region tesorero
                    if (cmbTesorero.Value != null && cmbTesorero.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbTesorero.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Tesorero", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Tesorero";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Tesorero", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region secretario
                    if (cmbSecretario.Value != null && cmbSecretario.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbSecretario.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Secretario", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Secretario";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Secretario", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region otro1
                    if (cmbOtro1.Value != null && cmbOtro1.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbOtro1.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro1", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Otro1";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro1", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region otro2
                    if (cmbOtro2.Value != null && cmbOtro2.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbOtro2.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro2", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Otro2";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro2", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region otro3
                    if (cmbOtro3.Value != null && cmbOtro3.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbOtro3.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro3", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Otro3";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro3", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region otro4
                    if (cmbOtro4.Value != null && cmbOtro4.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbOtro4.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro4", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Otro4";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro4", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region otro6
                    if (cmbOtro6.Value != null && cmbOtro6.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbOtro6.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro6", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Otro6";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro6", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region otro7
                    if (cmbOtro7.Value != null && cmbOtro7.Value.ToString() != "0")
                    {
                        //se debe modificar
                        int idUs = int.Parse(cmbOtro7.Value.ToString());
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro7", id);
                        if (us.Id > 0)
                        {
                            us.UsuId = idUs;
                            fac.Update<Entidad.UsuarioLista>(us);
                        }
                        else
                        {
                            //es nuevo
                            us.LtrId = id;
                            us.Rol = "Otro7";
                            us.UsuId = idUs;
                            fac.Insertar<Entidad.UsuarioLista>(us);
                        }
                    }
                    else
                    {
                        //se debe eliminar
                        Entidad.UsuarioLista us = NegocioMySQL.UsuarioLista.ObtenerIdLtr("Otro7", id);
                        if (us.UsuId > 0)
                            fac.Delete<Entidad.UsuarioLista>(us);

                    }
                    #endregion

                    #region modificar calendario
                    //primero lo buscamos
                    List<Entidad.Calendario> listaCal = NegocioMySQL.Calendario.ObtenerCalendarioPorInstId(entidad.InstId);
                    Entidad.Calendario cal = new Entidad.Calendario();
                    if (listaCal != null && listaCal.Count > 0)
                    {
                        cal = listaCal.Find(p => p.Detalle == entidad.Nombre && p.Tipo == 5);

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

                    EstiloMensaje(Administracion.EstiloMensaje.Ok, "Modificado con éxito");
                    Recuperar(id);
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al guardar el movimiento");
                }
            }
        }
        private void Limpiar()
        {
            txtNombreProyecto.Text = string.Empty;
            memObjetivo.Text = string.Empty;
            memDescripcion.Text = string.Empty;
            memBeneficios.Text = string.Empty;
            cmbPresidente.SelectedIndex = 0;
            cmbVicepresidente.SelectedIndex = 0;
            cmbSecretario.SelectedIndex = 0;
            cmbTesorero.SelectedIndex = 0;
            cmbOtro1.SelectedIndex = 0;
            cmbOtro2.SelectedIndex = 0;
            cmbOtro3.SelectedIndex = 0;
            cmbOtro4.SelectedIndex = 0;
            cmbOtro6.SelectedIndex = 0;
            cmbOtro7.SelectedIndex = 0;
            dtFechainicio.Text = string.Empty;
            dtFechaTermino.Text = string.Empty;
            hidId.Value = "0";

        }
        private void Recuperar(int id)
        {

            if (id > 0)
            {
                Entidad.ListaTricel entidad = VCFramework.NegocioMySQL.ListaTricel.ObtenerListaTricelPorId(id)[0];
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

                        txtNombreProyecto.Text = entidad.Nombre;
                        memObjetivo.Text = entidad.Objetivo;
                        memDescripcion.Text = entidad.Descripcion;
                        memBeneficios.Text = entidad.Beneficios;
                        dtFechainicio.Date = entidad.FechaInicio;
                        dtFechaTermino.Date = entidad.FechaTermino;
                        //obtencion de los  USUARIOS DE LA LISTA
                        List<Entidad.UsuarioLista> usuariosLista = NegocioMySQL.UsuarioLista.Obtener(id);

                        List<Entidad.Tricel> tricel = NegocioMySQL.Tricel.ObtenerTricelPorId(entidad.TriId);
                        //infromación del tricel
                        if (tricel != null && tricel.Count == 1)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendFormat("Esta lista pertenece al Tricel {0}, el cual tiene como fechas topes {1} y {2}", tricel[0].Nombre, tricel[0].FechaInicio.ToShortDateString(), tricel[0].FechaTermino.ToShortDateString());
                            litInfoTricel.Text = sb.ToString();
                        }

                        if (usuariosLista != null && usuariosLista.Count > 0)
                        {
                            foreach(Entidad.UsuarioLista us in usuariosLista)
                            {
                                if (us.Rol == "Presidente")
                                {
                                    cmbPresidente.Value = us.UsuId.ToString();
                                }
                                if (us.Rol == "Vicepresidente")
                                    cmbVicepresidente.Value = us.UsuId.ToString();
                                if (us.Rol == "Secretario")
                                    cmbSecretario.Value = us.UsuId.ToString();
                                if (us.Rol == "Tesorero")
                                    cmbTesorero.Value = us.UsuId.ToString();
                                if (us.Rol == "Otro1")
                                    cmbOtro1.Value = us.UsuId.ToString();
                                if (us.Rol == "Otro2")
                                    cmbOtro2.Value = us.UsuId.ToString();
                                if (us.Rol == "Otro3")
                                    cmbOtro3.Value = us.UsuId.ToString();
                                if (us.Rol == "Otro4")
                                    cmbOtro4.Value = us.UsuId.ToString();
                                if (us.Rol == "Otro6")
                                    cmbOtro6.Value = us.UsuId.ToString();
                                if (us.Rol == "Otro7")
                                    cmbOtro7.Value = us.UsuId.ToString();
                            }
                        }

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
        protected void pnlGeneral_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter.Contains("guardar"))
            {
                string[] param = e.Parameter.Split('|');

                try
                {

                    Entidad.ListaTricel obj = VCFramework.NegocioMySQL.ListaTricel.ObtenerListaTricelPorId(int.Parse(hidId.Value.ToString()))[0];
                    Modificar(obj);
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
                    Insertar();
                }
                catch (Exception ex)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, contacte al administrador. " + ex.Message);
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                }


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

                Entidad.ListaTricel entidad = VCFramework.NegocioMySQL.ListaTricel.ObtenerListaTricelPorId(id)[0];
                if (entidad != null)
                {
                    Entidad.ListaTricel entidadEli = new Entidad.ListaTricel();
                    entidadEli = entidad;
                    entidadEli.Borrado = false;
                    entidadEli.Nuevo = false;
                    entidadEli.Modificado = true;
                    entidadEli.Eliminado = 1;
                    VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                    if (fac.Update<VCFramework.Entidad.ListaTricel>(entidadEli) > 0)
                    {
                        #region modificar calendario
                        //primero lo buscamos
                        List<Entidad.Calendario> listaCal = NegocioMySQL.Calendario.ObtenerCalendarioPorInstId(entidadEli.InstId);
                        Entidad.Calendario cal = new Entidad.Calendario();
                        if (listaCal != null && listaCal.Count > 0)
                        {
                            cal = listaCal.Find(p => p.Detalle == entidadEli.Nombre && p.Tipo == 5);

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

                        EstiloMensaje(Administracion.EstiloMensaje.Ok, "Listado Eliminado con éxito");
                        //ahora los botones
                        btnEliminar.ClientVisible = false;
                    }

                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }
    }
}