using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VCFramework.Negocio.Factory;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class cursoEditar : System.Web.UI.Page
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["id"] != null && Request.QueryString["nuevo"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["editar"] != null)
                {

                    //CargarRoles();
                    //hidId.Value = Request.QueryString["id"];

                    //recuperar usuario
                    if (int.Parse(Request.QueryString["id"].ToString()) >= 0)
                    {

                        if (Request.QueryString["editar"].ToString() == "true")
                        {
                            //litOperacion.Text = "Modificando ";
                            //RecuperarUsuario(int.Parse(Request.QueryString["id"].ToString()));
                            //btnGuardar.Text = "Modificar";
                            //btnLimpiar.ClientVisible = false;
                        }
                        else if (Request.QueryString["nuevo"].ToString() == "true")
                        {
                            //litOperacion.Text = "Creando ";
                            //CargarDatosNuevo();

                        }
                        else
                        {
                            //litOperacion.Text = "Usted va a eliminar a este ";
                            //RecuperarUsuario(int.Parse(Request.QueryString["id"].ToString()));
                            //BloquearTodo();
                        }
                    }

                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }

        }

        protected void pnlGeneral_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter.Contains("guardar"))
            {
                string[] param = e.Parameter.Split(';');
                if (param.Length == 4)
                {
                    try
                    {
                        //int idInst = int.Parse(param[1]);
                        //int idReg = int.Parse(param[2]);
                        //int idCom = int.Parse(param[3]);
                        //UsuarioFuncional usu = LogicLogin.ObtenerUsuario(int.Parse(hidId.Value.ToString()));
                        //ModificarUsuario(usu, idInst, idReg, idCom);
                    }
                    catch (Exception ex)
                    {
                        //VCFramework.NegocioMySQL.Utiles.Log(ex);
                        //EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
                    }
                }
                else
                {
                    //EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
                }
            }
            else if (e.Parameter.Contains("rut"))
            {
                //string[] param = e.Parameter.Split(';');
                //if (!validarRut(param[1]))
                //{
                //    txtRut.Text = string.Empty;
                //    lblMensajeRut.Text = "Rut inválido";
                //    txtRut.Focus();
                //}
                //else
                //    txtNombres.Focus();
            }
            else if (e.Parameter.Contains("usuario"))
            {
                string[] param = e.Parameter.Split(';');
                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    UsuarioFuncional usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    if (Request.QueryString["nuevo"] == "true")
                    {
                        //if (VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios().Find(p => p.NombreUsuario == param[1].ToString()) != null)
                        //{
                        //    txtUsername.Text = string.Empty;
                        //    lblMensajeUsuario.Text = "Este usuario ya existe ingrese otro.";
                        //    txtUsername.Focus();
                        //}
                        //else
                        //    txtRut.Focus();

                    }
                }
            }
            else if (e.Parameter.Contains("limpiar"))
            {
                //Limpiar();
            }
            else if (e.Parameter.Contains("eliminar"))
            {
                //Limpiar();
                //EliminarUsuario(int.Parse(hidId.Value.ToString()));
            }
            else
            {
                //nuevo registro
                //string[] param = e.Parameter.Split(';');
                //if (param.Length == 4)
                //{
                //    try
                //    {
                //        int idInst = int.Parse(param[1]);
                //        int idReg = int.Parse(param[2]);
                //        int idCom = int.Parse(param[3]);
                //        InsertarUsuario(idInst, idReg, idCom);
                //    }
                //    catch (Exception ex)
                //    {
                //        VCFramework.NegocioMySQL.Utiles.Log(ex);
                //        EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
                //    }
                //}
                //else
                //    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");

            }
        }
    }
}