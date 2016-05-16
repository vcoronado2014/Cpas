using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class usuarioEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //grillaCursos.GroupBy(grillaCursos.Columns["Grupo"]);
                //grillaCursos.GroupBy(grillaCursos.Columns["SubGrupo"]);
                if (Request.QueryString["id"] != null && Request.QueryString["nuevo"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["editar"] != null)
                {
                    //CargarInstituciones();
                    //CargarRegiones();
                    CargarRoles();
                    hidId.Value = Request.QueryString["id"];
                    //Session["ID_USU_EDITANDO"] = 0;
                    
                        //recuperar usuario
                    if (int.Parse(Request.QueryString["id"].ToString()) >= 0)
                    {
                        
                        if (Request.QueryString["editar"].ToString() == "true")
                        {
                            litOperacion.Text = "Modificando ";
                            RecuperarUsuario(int.Parse(Request.QueryString["id"].ToString()));
                            btnGuardar.Text = "Modificar";
                            btnLimpiar.ClientVisible = false;
                        }
                        else if (Request.QueryString["nuevo"].ToString() == "true")
                        {
                            litOperacion.Text = "Creando ";
                            //RecuperarUsuario(int.Parse(Request.QueryString["id"].ToString()));
                            CargarDatosNuevo();

                        }
                        else
                        {
                            litOperacion.Text = "Usted va a eliminar a este ";
                            RecuperarUsuario(int.Parse(Request.QueryString["id"].ToString()));
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
        private void Limpiar()
        {
            CargarDatosNuevo();
            txtUsername.Text = string.Empty;
            txtRut.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidoPaterno.Text = string.Empty;
            txtApellidoMaterno.Text = string.Empty;
            cmbRegion.SelectedIndex = -1;
            cmbComuna.Items.Clear();
            txtDireccion.Text = string.Empty;
            cmbRoles.SelectedIndex = 0;
            txtPassword.Text = string.Empty;
            txtPasswordRepita.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            hidId.Value = "0";

        }
        private void InsertarUsuario(int idInst, int idReg, int idCom)
        {

            int idRol = int.Parse(cmbRoles.SelectedValue.ToString());

            VCFramework.Entidad.AutentificacionUsuario aus = new Entidad.AutentificacionUsuario();
            aus.Borrado = false;
            aus.Eliminado = 0;
            aus.EsVigente = 1;
            aus.InstId = idInst;
            aus.Modificado = false;
            aus.NombreUsuario = NegocioMySQL.Utiles.Encriptar(txtUsername.Text);
            aus.Nuevo = true;
            aus.Password = txtPassword.Text;
            aus.RolId = idRol;
            aus.CorreoElectronico = txtCorreo.Text;
            if (idReg > 0 && idCom > 0)
            {
                VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                if (fac.Insertar<VCFramework.Entidad.AutentificacionUsuario>(aus) > 0)
                {
                    Entidad.AutentificacionUsuario usuarioGuardado = VCFramework.NegocioMySQL.AutentificacionUsuario.ObtenerUsuario(aus.NombreUsuario, NegocioMySQL.Utiles.DesEncriptar(aus.Password));
                    if (usuarioGuardado != null && usuarioGuardado.Id > 0)
                    {
                        VCFramework.Entidad.Persona persona = new VCFramework.Entidad.Persona();
                        persona.ApellidoMaterno = txtApellidoMaterno.Text;
                        persona.ApellidoPaterno = txtApellidoPaterno.Text;
                        persona.Borrado = false;
                        persona.ComId = idCom;
                        persona.DireccionCompleta = txtDireccion.Text;
                        persona.Eliminado = 0;
                        persona.InstId = idInst;
                        persona.Modificado = false;
                        persona.Nombres = txtNombres.Text;
                        persona.Nuevo = true;
                        persona.PaisId = 0;
                        persona.RegId = idReg;
                        persona.Rut = txtRut.Text;
                        persona.Telefonos = txtTelefonos.Text;
                        persona.UsuId = usuarioGuardado.Id;

                        if (fac.Insertar<VCFramework.Entidad.Persona>(persona) > 0)
                        {
                            EstiloMensaje(Administracion.EstiloMensaje.Ok, "Registro insertado con éxito");
                            //litMensaje.Text = "Registro insertado con éxito";
                            //limpiamos
                            //obtencion de los  cursos del usuario
                            string[] cursos = cmbCursos.Value.ToString().Split(',');
                            try
                            {
                                if (cursos != null && cursos.Length > 0)
                                {
                                    //estoy modificando por lo tanto elimino todas las que tenga
                                    //y luego las vuelvo a crear
                                    List<Entidad.CursoApoderado> listaP = NegocioMySQL.CursoApoderado.ObtenerCursosDelApoderado(usuarioGuardado.InstId, usuarioGuardado.Id);
                                    if (listaP != null && listaP.Count > 0)
                                    {
                                        foreach (Entidad.CursoApoderado cur in listaP)
                                        {
                                            VCFramework.NegocioMySQL.CursoApoderado.Eliminar(cur);
                                        }
                                    }
                                    //ahora las volvemos a crear
                                    if (cursos.Length > 0 && cursos != null)
                                    {
                                        foreach (string s in cursos)
                                        {
                                            if (s != "")
                                            {
                                                int idCur = int.Parse(s);
                                                Entidad.CursoApoderado cursoAp = new Entidad.CursoApoderado();
                                                cursoAp.CurId = idCur;
                                                cursoAp.InstId = usuarioGuardado.InstId;
                                                cursoAp.UsuId = usuarioGuardado.Id;
                                                VCFramework.NegocioMySQL.CursoApoderado.Insertar(cursoAp);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                VCFramework.NegocioMySQL.Utiles.Log(ex);
                            }
                            Limpiar();
                        }
                        else
                        {
                            EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "Se ha guardado la autentificación, sin embargo la persona no fué guardado.");
                            //litMensaje.Text = "Se ha guardado la autentificación, sin embargo la persona no fué guardado.";
                        }
                    }
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al insertar Autentificación");
                    //litMensaje.Text = "Error al insertar Autentificación";
                }
            }
            else
                EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");

        }
        private void BloquearTodo()
        {
            cmbInstitucion.ClientEnabled = false;
            txtUsername.ClientEnabled = false;
            txtRut.ClientEnabled = false;
            txtNombres.ClientEnabled = false;
            txtApellidoPaterno.ClientEnabled = false;
            txtApellidoMaterno.Enabled = false;
            cmbRegion.ClientEnabled = false;
            cmbComuna.ClientEnabled = false;
            txtDireccion.ClientEnabled = false;
            txtTelefonos.ClientEnabled = false;
            txtCorreo.ClientEnabled = false;
            cmbRoles.Enabled = false;
            txtPassword.ClientEnabled = false;
            txtPasswordRepita.ClientEnabled = false;
            btnEliminar.ClientVisible = true;
            btnGuardar.ClientVisible = false;
            btnLimpiar.ClientVisible = false;
            cmbCursos.ClientEnabled = false;
        }
        private void CargarDatosNuevo()
        {
            UsuarioFuncional usu = new UsuarioFuncional();
            

            //txtUsername.Enabled = false;

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
            }
            //asignamos
            if (usu.Institucion != null && usu.Institucion.Id > 0)
            {

                if (usu.Rol != null)
                {
                    cmbInstitucion.Value = usu.Institucion.Id.ToString();
                    if (!usu.Rol.Nombre.Contains("Super"))
                        cmbInstitucion.ClientEnabled = false;



                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, "Usuario no cuenta con Rol válido");
                    //litMensaje.Text = "Usuario no cuenta con Rol válido";
                }
            }
            else
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Institución no válida");
                //litMensaje.Text = "Institución no válida";
            }
        }
        private void EliminarUsuario(int id)
        {
            
            if (id > 0)
            {
                UsuarioFuncional usuActual = new UsuarioFuncional();

                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usuActual = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                }

                UsuarioFuncional usu = LogicLogin.ObtenerUsuario(id);
                if (usu !=null)
                {
                    if (usu.AutentificacionUsuario.NombreUsuario != usuActual.AutentificacionUsuario.NombreUsuario)
                    {
                        VCFramework.Entidad.AutentificacionUsuario aus = usu.AutentificacionUsuario;
                        aus.EsVigente = 0;
                        aus.Nuevo = false;
                        aus.Modificado = true;
                        aus.Borrado = false;
                        VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                        if (fac.Update<VCFramework.Entidad.AutentificacionUsuario>(aus) > 0)
                        {

                            
                            try
                            {
                               
                                    //estoy modificando por lo tanto elimino todas las que tenga
                                    //y luego las vuelvo a crear
                                    List<Entidad.CursoApoderado> listaP = NegocioMySQL.CursoApoderado.ObtenerCursosDelApoderado(aus.InstId, aus.Id);
                                    if (listaP != null && listaP.Count > 0)
                                    {
                                        foreach (Entidad.CursoApoderado cur in listaP)
                                        {
                                            VCFramework.NegocioMySQL.CursoApoderado.Eliminar(cur);
                                        }
                                    }
                                    
                                
                            }
                            catch (Exception ex)
                            {
                                VCFramework.NegocioMySQL.Utiles.Log(ex);
                            }

                            EstiloMensaje(Administracion.EstiloMensaje.Ok, "Usuario Eliminado con éxito");
                            //ahora los botones
                            btnEliminar.ClientVisible = false;
                        }
                    }
                    else
                    {
                        EstiloMensaje(Administracion.EstiloMensaje.Error, "NO SE PUEDE ELIMINAR USTED MISMO.");
                    }
                }
            }
        }
        protected void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
        private void ModificarUsuario(UsuarioFuncional usu, int idInst, int idReg, int idCom)
        {
            int id = int.Parse(hidId.Value);
            if (id > 0)
            {
                usu.Persona.InstId = idInst;
                usu.Persona.UsuId = usu.AutentificacionUsuario.Id;
                usu.Persona.ApellidoMaterno = txtApellidoMaterno.Text;
                usu.Persona.ApellidoPaterno = txtApellidoPaterno.Text;
                
                usu.Persona.PaisId = 0;
                usu.Persona.RegId = idReg;

                CargarComunasRegion(usu.Persona.RegId);
                

                usu.Persona.ComId = idCom;
                usu.Persona.Rut = txtRut.Text;
                usu.Persona.DireccionCompleta = txtDireccion.Text;
                usu.Persona.Nombres = txtNombres.Text;
                usu.Persona.Telefonos = txtTelefonos.Text;
                

                int idRol = int.Parse(cmbRoles.SelectedValue.ToString());

                usu.AutentificacionUsuario.RolId = idRol;
                usu.AutentificacionUsuario.CorreoElectronico = txtCorreo.Text;

                //captura de los cursos
                string[] cursos = cmbCursos.Value.ToString().Split(',');

                try {
                    if (cursos != null && cursos.Length > 0)
                    {
                        //estoy modificando por lo tanto elimino todas las que tenga
                        //y luego las vuelvo a crear
                        List<Entidad.CursoApoderado> listaP = NegocioMySQL.CursoApoderado.ObtenerCursosDelApoderado(usu.Institucion.Id, usu.AutentificacionUsuario.Id);
                        if (listaP != null && listaP.Count > 0)
                        {
                            foreach (Entidad.CursoApoderado cur in listaP)
                            {
                                VCFramework.NegocioMySQL.CursoApoderado.Eliminar(cur);
                            }
                        }
                        //ahora las volvemos a crear
                        if (cursos.Length > 0 && cursos != null)
                        {
                            foreach (string s in cursos)
                            {
                                if (s != "")
                                {
                                    int idCur = int.Parse(s);
                                    Entidad.CursoApoderado cursoAp = new Entidad.CursoApoderado();
                                    cursoAp.CurId = idCur;
                                    cursoAp.InstId = usu.Institucion.Id;
                                    cursoAp.UsuId = usu.AutentificacionUsuario.Id;
                                    VCFramework.NegocioMySQL.CursoApoderado.Insertar(cursoAp);
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                }

                if (idReg > 0 && idCom > 0)
                {

                    if (VCFramework.NegocioMySQL.AutentificacionUsuario.ModificarAus(usu.AutentificacionUsuario) > 0)
                    {
                        if (VCFramework.NegocioMySQL.Persona.ModificarUsuario(usu.Persona) > 0)
                        {
                            EstiloMensaje(Administracion.EstiloMensaje.Ok, "Modificado con éxito");
                            //litMensaje.Text = "Modificado con éxito";
                            RecuperarUsuario(id);
                        }
                        else
                        {
                            EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al guardar la Persona");
                            //litMensaje.Text = "Error al guardar la Persona";
                        }
                    }
                    else
                    {
                        EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al guardar la autentificación");
                        //litMensaje.Text = "Error al guardar la autentificación";
                    }
                }
                else
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
            }
            else
            {
                EstiloMensaje(Administracion.EstiloMensaje.Error, "Usuario no éxiste, vuelva a intentarlo");
                //litMensaje.Text = "Usuario no éxiste, vuelva a intentarlo";
            }
        }
        
        private void RecuperarUsuario(int id)
        {
            if (id > 0)
            {
                UsuarioFuncional usu = LogicLogin.ObtenerUsuario(id);
                if (usu != null)
                {
                    try
                    {
                        //primero desactivamos los controles de edicion
                        cmbInstitucion.ClientEnabled = false;
                        txtUsername.Enabled = false;
                        //asignamos
                        if (usu.Institucion != null && usu.Institucion.Id > 0)
                            cmbInstitucion.Value = usu.Institucion.Id.ToString();
                        txtUsername.Text = usu.AutentificacionUsuario.NombreUsuario;
                        txtCorreo.Text = usu.AutentificacionUsuario.CorreoElectronico;
                        if (usu.Persona != null)
                        {
                            txtRut.Text = usu.Persona.Rut;
                            txtNombres.Text = usu.Persona.Nombres;
                            txtApellidoPaterno.Text = usu.Persona.ApellidoPaterno;
                            txtApellidoMaterno.Text = usu.Persona.ApellidoMaterno;
                            txtDireccion.Text = usu.Persona.DireccionCompleta;
                            txtTelefonos.Text = usu.Persona.Telefonos;
                        }
                        if (usu.Rol != null && usu.Rol.Id > 0)
                            cmbRoles.SelectedValue = usu.Rol.Id.ToString();
                        if (usu.Region != null && usu.Region.Id > 0)
                        {
                            cmbRegion.Value = usu.Region.Id.ToString();
                            CargarComunasRegion(usu.Region.Id);
                        }
                        if (usu.Comuna != null && usu.Comuna.Id > 0)
                        {
                            cmbComuna.Value = usu.Comuna.Id.ToString();
                        }
                        //obtencion de los  cursos del usuario
                        List<Entidad.CursoApoderado> cursosAp = NegocioMySQL.CursoApoderado.ObtenerCursosDelApoderado(usu.Institucion.Id, id);
                        StringBuilder cursos = new StringBuilder();
                        
                        if (cursosAp != null && cursosAp.Count > 0)
                        {
                            foreach(Entidad.CursoApoderado cur in cursosAp)
                            {
                                //listita.Add(cur.Id.ToString());
                                cursos.Append(cur.CurId.ToString());
                                cursos.Append(",");
                            }

                        }
                        cmbCursos.Value = cursos.ToString();
                    }
                    catch(Exception ex)
                    {
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
                        EstiloMensaje(Administracion.EstiloMensaje.Error, ex.Message);
                        //litMensaje.Text = ex.Message;
                    }
                }
                else
                {
                    //mensaje de error
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "USUARIO NO ENCONTRADO");
                    //litMensaje.Text = "USUARIO NO ENCONTRADO";
                }
            }
        }
        private void CargarRoles()
        {
            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                UsuarioFuncional usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                List<VCFramework.Entidad.Rol> roles = VCFramework.NegocioMySQL.Rol.ListarRoles(usu.Rol.Nombre);
                cmbRoles.Items.Clear();
                cmbRoles.DataSource = roles;
                cmbRoles.DataBind();
            }
        }
        private void CargarComunasRegion(int idRegion)
        {
            List<VCFramework.Entidad.Comuna> comunas = VCFramework.NegocioMySQL.Comuna.ObtenerComunasDeLaRegion(idRegion.ToString());
            cmbComuna.Items.Clear();
            cmbComuna.DataSource = comunas;
            cmbComuna.DataBind();
        }
 
        protected void pnlComunas_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter != null)
            {
                string id = e.Parameter;
                List<Entidad.Comuna> comunas = VCFramework.NegocioMySQL.Comuna.ObtenerComunasDeLaRegion(id);
                cmbComuna.Items.Clear();
                if (comunas != null && comunas.Count > 0)
                {
                    cmbComuna.DataSource = comunas;
                    cmbComuna.DataBind();
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
                    try {
                        int idInst = int.Parse(param[1]);
                        int idReg = int.Parse(param[2]);
                        int idCom = int.Parse(param[3]);
                        UsuarioFuncional usu = LogicLogin.ObtenerUsuario(int.Parse(hidId.Value.ToString()));
                        ModificarUsuario(usu, idInst, idReg, idCom);
                    }
                    catch (Exception ex)
                    {
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
                        EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
                    }
                }
                else
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
            }
            else if (e.Parameter.Contains("rut"))
            {
                string[] param = e.Parameter.Split(';');
                if (!validarRut(param[1]))
                {
                    txtRut.Text = string.Empty;
                    lblMensajeRut.Text = "Rut inválido";
                    txtRut.Focus();
                }
                else
                    txtNombres.Focus();
            }
            else if (e.Parameter.Contains("usuario"))
            {
                string[] param = e.Parameter.Split(';');
                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    UsuarioFuncional usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    if (Request.QueryString["nuevo"] == "true")
                    {
                        if (VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios().Find(p => p.NombreUsuario == param[1].ToString()) != null)
                        {
                            txtUsername.Text = string.Empty;
                            lblMensajeUsuario.Text = "Este usuario ya existe ingrese otro.";
                            txtUsername.Focus();
                        }
                        else
                            txtRut.Focus();

                    }
                }
            }
            else if (e.Parameter.Contains("limpiar"))
            {
                Limpiar();
            }
            else if (e.Parameter.Contains("eliminar"))
            {
                //Limpiar();
                EliminarUsuario(int.Parse(hidId.Value.ToString()));
            }
            else
            {
                //nuevo registro
                string[] param = e.Parameter.Split(';');
                if (param.Length == 4)
                {
                    try {
                        int idInst = int.Parse(param[1]);
                        int idReg = int.Parse(param[2]);
                        int idCom = int.Parse(param[3]);
                        InsertarUsuario(idInst, idReg, idCom);
                    }
                    catch (Exception ex)
                    {
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
                        EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");
                    }
                }
                else
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "No se puede gaurdar!, la región y la comuna son requeridas.");

            }
        }



        protected void txtRut_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            if (e.Value.ToString().Length < 10)
                e.IsValid = false;
            if (!validarRut(e.Value.ToString()))
                e.IsValid = false;
        }
        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception ex)
            {
                VCFramework.NegocioMySQL.Utiles.Log(ex);
            }
            return validacion;
        }

        protected void txtUsername_Validation(object sender, DevExpress.Web.ValidationEventArgs e)
        {
            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                UsuarioFuncional usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                if (Request.QueryString["nuevo"] == "true")
                {
                    if (e.Value == null || e.Value.ToString() == string.Empty)
                        e.IsValid = false;
                    if (VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios().Find(p => p.NombreUsuario == e.Value.ToString()) != null)
                        e.IsValid = false;

                }
            }
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
    }
    public enum EstiloMensaje
    {
        Ok,
        Advertencia,
        Error
    }
}