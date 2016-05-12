using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VCFramework.SitioWeb
{
    public class LogicLogin
    {
        public static bool ValidarUsuario(string userName, string password)
        {

            return VCFramework.NegocioMySQL.AutentificacionUsuario.ValidarUsuario(userName, password);
        }
        public static UsuarioFuncional ObtenerUsuario(string userName, string password)
        {
            UsuarioFuncional retorno = new UsuarioFuncional();
            retorno.AutentificacionUsuario = new Entidad.AutentificacionUsuario();
            retorno.Rol = new Entidad.Rol();
            retorno.AutentificacionUsuario = VCFramework.NegocioMySQL.AutentificacionUsuario.ObtenerUsuario(userName, password);
            if (retorno.AutentificacionUsuario != null && retorno.AutentificacionUsuario.Id > 0)
                retorno.Rol = NegocioMySQL.Rol.ObtenerRolDelUsuario(retorno.AutentificacionUsuario.RolId);
            if (retorno.AutentificacionUsuario.InstId > 0)
                retorno.Institucion = NegocioMySQL.Institucion.ObtenerInstitucionPorId(retorno.AutentificacionUsuario.InstId);
            if (retorno.AutentificacionUsuario.Id > 0)
                retorno.Persona = NegocioMySQL.Persona.ObtenerPersonaPorUsuId(retorno.AutentificacionUsuario.Id);
            if (retorno.Persona != null)
                retorno.Region = NegocioMySQL.Region.ObtenerRegionPorId(retorno.Persona.RegId);
            if (retorno.Persona != null)
                retorno.Comuna = NegocioMySQL.Comuna.ObtenerComunaPorId(retorno.Persona.ComId);

            return retorno;
        }
        public static UsuarioFuncional ObtenerUsuario(int id)
        {
            
            UsuarioFuncional retorno = new UsuarioFuncional();
            if (id > 0)
            {
                retorno.AutentificacionUsuario = new Entidad.AutentificacionUsuario();
                retorno.Rol = new Entidad.Rol();
                retorno.AutentificacionUsuario = VCFramework.NegocioMySQL.AutentificacionUsuario.ObtenerUsuario(id);
                if (retorno.AutentificacionUsuario != null && retorno.AutentificacionUsuario.Id > 0)
                    retorno.Rol = NegocioMySQL.Rol.ObtenerRolDelUsuario(retorno.AutentificacionUsuario.RolId);
                if (retorno.AutentificacionUsuario.InstId > 0)
                    retorno.Institucion = NegocioMySQL.Institucion.ObtenerInstitucionPorId(retorno.AutentificacionUsuario.InstId);
                if (retorno.AutentificacionUsuario.Id > 0)
                    retorno.Persona = NegocioMySQL.Persona.ObtenerPersonaPorUsuId(retorno.AutentificacionUsuario.Id);
                if (retorno.Persona != null)
                    retorno.Region = NegocioMySQL.Region.ObtenerRegionPorId(retorno.Persona.RegId);
                if (retorno.Persona != null)
                    retorno.Comuna = NegocioMySQL.Comuna.ObtenerComunaPorId(retorno.Persona.ComId);
            }
            return retorno;
        }
        public static List<UsuarioFuncional> ListarUsuariosFuncional()
        {
            List<UsuarioFuncional> retorno = new List<UsuarioFuncional>();

            List<VCFramework.Entidad.AutentificacionUsuario> usuarios = VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios();
            if (usuarios != null && usuarios.Count > 0)
            {
                foreach(VCFramework.Entidad.AutentificacionUsuario usu in usuarios)
                {
                    UsuarioFuncional uf = new UsuarioFuncional();
                    uf.AutentificacionUsuario = new Entidad.AutentificacionUsuario();
                    uf.AutentificacionUsuario = usu;

                    uf.Institucion = new Entidad.Institucion();
                    uf.Institucion = VCFramework.NegocioMySQL.Institucion.ObtenerInstitucionPorId(usu.InstId);

                    uf.Rol = new Entidad.Rol();
                    uf.Rol = VCFramework.NegocioMySQL.Rol.ListarRoles().Find(p => p.Id == usu.RolId);

                    uf.Persona = new Entidad.Persona();
                    uf.Persona = VCFramework.NegocioMySQL.Persona.ObtenerPersonaPorUsuId(usu.Id);

                    uf.Region = new Entidad.Region();
                    if (uf.Persona != null)
                        uf.Region = VCFramework.NegocioMySQL.Region.ObtenerRegionPorId(uf.Persona.RegId);

                    uf.Comuna = new Entidad.Comuna();
                    if (uf.Persona != null)
                        uf.Comuna = VCFramework.NegocioMySQL.Comuna.ObtenerComunaPorId(uf.Persona.ComId);

                    retorno.Add(uf);
                }
            }

            return retorno;
        }

        public static List<UsuarioFuncional> ListarUsuariosFuncionalLista(int idUsuLogueado)
        {
            List<UsuarioFuncional> retorno = new List<UsuarioFuncional>();

            List<VCFramework.Entidad.AutentificacionUsuario> usuarios = VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios();
            if (usuarios != null && usuarios.Count > 0)
            {
                foreach (VCFramework.Entidad.AutentificacionUsuario usu in usuarios)
                {
                    if (usu.Id != idUsuLogueado)
                    {
                        UsuarioFuncional uf = new UsuarioFuncional();
                        uf.AutentificacionUsuario = new Entidad.AutentificacionUsuario();
                        uf.AutentificacionUsuario = usu;

                        uf.Institucion = new Entidad.Institucion();
                        uf.Institucion = VCFramework.NegocioMySQL.Institucion.ObtenerInstitucionPorId(usu.InstId);

                        uf.Rol = new Entidad.Rol();
                        uf.Rol = VCFramework.NegocioMySQL.Rol.ListarRoles().Find(p => p.Id == usu.RolId);

                        uf.Persona = new Entidad.Persona();
                        uf.Persona = VCFramework.NegocioMySQL.Persona.ObtenerPersonaPorUsuId(usu.Id);

                        uf.Region = new Entidad.Region();
                        if (uf.Persona != null)
                            uf.Region = VCFramework.NegocioMySQL.Region.ObtenerRegionPorId(uf.Persona.RegId);

                        uf.Comuna = new Entidad.Comuna();
                        if (uf.Persona != null)
                            uf.Comuna = VCFramework.NegocioMySQL.Comuna.ObtenerComunaPorId(uf.Persona.ComId);

                        retorno.Add(uf);
                    }
                }
            }

            return retorno;
        }

        public static List<UsuarioEnvoltorio> ListarUsuariosEnvoltorioConRol(int instId)
        {
            List<UsuarioEnvoltorio> retorno = new List<UsuarioEnvoltorio>();

            List<UsuarioFuncional> lista = new List<UsuarioFuncional>();

            if (instId > 3)
                lista = ListarUsuariosFuncional(instId);
            else
                lista = ListarUsuariosFuncional();
            if (lista != null && lista.Count > 0)
            {
                foreach (UsuarioFuncional usd in lista)
                {
                    UsuarioEnvoltorio us = new UsuarioEnvoltorio();
                    us.Id = usd.AutentificacionUsuario.Id;
                    us.NombreUsuario = usd.AutentificacionUsuario.NombreUsuario;
                    us.Rol = usd.Rol.Nombre;
                    if (usd.Persona != null)
                    {
                        us.NombreCompleto = usd.Persona.Nombres + " " + usd.Persona.ApellidoPaterno + " " + usd.Persona.ApellidoMaterno + " (" + us.Rol + ")" ;
                    }
                    if (usd.Rol != null)
                        us.Rol = usd.Rol.Nombre;

                    retorno.Add(us);
                }
            }
            return retorno;

        }
        public static List<UsuarioEnvoltorio> ListarUsuariosEnvoltorio(int instId)
        {
            List<UsuarioEnvoltorio> retorno = new List<UsuarioEnvoltorio>();

            List<UsuarioFuncional> lista = new List<UsuarioFuncional>();

            if (instId > 3)
                lista = ListarUsuariosFuncional(instId);
            else
                lista = ListarUsuariosFuncional();
            if (lista != null && lista.Count > 0)
            {
                foreach (UsuarioFuncional usd in lista)
                {
                    UsuarioEnvoltorio us = new UsuarioEnvoltorio();
                    us.Id = usd.AutentificacionUsuario.Id;
                    us.NombreUsuario = usd.AutentificacionUsuario.NombreUsuario;
                    if (usd.Persona != null)
                    {
                        us.NombreCompleto = usd.Persona.Nombres + " " + usd.Persona.ApellidoPaterno + " " + usd.Persona.ApellidoMaterno;
                    }
                    if (usd.Rol != null)
                        us.Rol = usd.Rol.Nombre;

                    retorno.Add(us);
                }
            }
            return retorno;

        }

        public static List<UsuarioEnvoltorio> ListarUsuariosEnvoltorioLista(int instId, int usuId)
        {
            List<UsuarioEnvoltorio> retorno = new List<UsuarioEnvoltorio>();

            List<UsuarioFuncional> lista = new List<UsuarioFuncional>();

            if (instId > 3)
                lista = ListarUsuariosFuncional(instId).FindAll(p=>p.AutentificacionUsuario.Id != usuId);
            else
                lista = ListarUsuariosFuncional().FindAll(p => p.AutentificacionUsuario.Id != usuId);
            if (lista != null && lista.Count > 0)
            {
                foreach (UsuarioFuncional usd in lista)
                {
                    UsuarioEnvoltorio us = new UsuarioEnvoltorio();
                    us.Id = usd.AutentificacionUsuario.Id;
                    us.NombreUsuario = usd.AutentificacionUsuario.NombreUsuario;
                    if (usd.Persona != null)
                    {
                        us.NombreCompleto = usd.Persona.Nombres + " " + usd.Persona.ApellidoPaterno + " " + usd.Persona.ApellidoMaterno;
                    }
                    if (usd.Rol != null)
                        us.Rol = usd.Rol.Nombre;

                    retorno.Add(us);
                }
            }
            if (retorno != null && retorno.Count > 0)
            {
                UsuarioEnvoltorio usS = new UsuarioEnvoltorio();
                usS.Id = 0;
                usS.NombreCompleto = "Seleccione";
                usS.NombreUsuario = "Seleccione";
                usS.Rol = "No Determinado";
                retorno.Insert(0, usS);
            }
            return retorno;

        }

        public static List<UsuarioEnvoltorio> ListarUsuariosEnvoltorioLista(int instId, int usuId, int triId)
        {
            List<UsuarioEnvoltorio> retorno = new List<UsuarioEnvoltorio>();

            List<UsuarioFuncional> lista = new List<UsuarioFuncional>();

            List<Entidad.ResponsableTricel> responsables = NegocioMySQL.ResponsableTricel.ObtenerResponsables(triId);

            if (instId > 3)
                lista = ListarUsuariosFuncional(instId).FindAll(p => p.AutentificacionUsuario.Id != usuId);
            else
                lista = ListarUsuariosFuncional().FindAll(p => p.AutentificacionUsuario.Id != usuId);
            if (lista != null && lista.Count > 0)
            {
                foreach (UsuarioFuncional usd in lista)
                {
                    if (!responsables.Exists(p => p.UsuId == usd.AutentificacionUsuario.Id))
                    {
                        UsuarioEnvoltorio us = new UsuarioEnvoltorio();
                        us.Id = usd.AutentificacionUsuario.Id;
                        us.NombreUsuario = usd.AutentificacionUsuario.NombreUsuario;
                        if (usd.Persona != null)
                        {
                            us.NombreCompleto = usd.Persona.Nombres + " " + usd.Persona.ApellidoPaterno + " " + usd.Persona.ApellidoMaterno;
                        }
                        if (usd.Rol != null)
                            us.Rol = usd.Rol.Nombre;

                        retorno.Add(us);
                    }
                }
            }
            if (retorno != null && retorno.Count > 0)
            {
                UsuarioEnvoltorio usS = new UsuarioEnvoltorio();
                usS.Id = 0;
                usS.NombreCompleto = "Seleccione";
                usS.NombreUsuario = "Seleccione";
                usS.Rol = "No Determinado";
                retorno.Insert(0, usS);
            }
            return retorno;

        }
        public static List<UsuarioFuncional> ListarUsuariosFuncional(int instId)
        {
            List<UsuarioFuncional> retorno = new List<UsuarioFuncional>();

            List<VCFramework.Entidad.AutentificacionUsuario> usuarios = VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuariosPorInstId(instId);
            if (usuarios != null && usuarios.Count > 0)
            {
                foreach (VCFramework.Entidad.AutentificacionUsuario usu in usuarios)
                {
                    UsuarioFuncional uf = new UsuarioFuncional();
                    uf.AutentificacionUsuario = new Entidad.AutentificacionUsuario();
                    uf.AutentificacionUsuario = usu;

                    uf.Institucion = new Entidad.Institucion();
                    uf.Institucion = VCFramework.NegocioMySQL.Institucion.ObtenerInstitucionPorId(usu.InstId);

                    uf.Rol = new Entidad.Rol();
                    uf.Rol = VCFramework.NegocioMySQL.Rol.ListarRoles().Find(p => p.Id == usu.RolId);

                    uf.Persona = new Entidad.Persona();
                    uf.Persona = VCFramework.NegocioMySQL.Persona.ObtenerPersonaPorUsuId(usu.Id);

                    uf.Region = new Entidad.Region();
                    if (uf.Persona != null)
                        uf.Region = VCFramework.NegocioMySQL.Region.ObtenerRegionPorId(uf.Persona.RegId);

                    uf.Comuna = new Entidad.Comuna();
                    if (uf.Persona != null)
                        uf.Comuna = VCFramework.NegocioMySQL.Comuna.ObtenerComunaPorId(uf.Persona.ComId);

                    retorno.Add(uf);
                }
            }

            return retorno;
        }
    }
    public class UsuarioFuncional
    {
        public VCFramework.Entidad.AutentificacionUsuario AutentificacionUsuario { get; set; }
        public VCFramework.Entidad.Rol Rol { get; set; }

        public VCFramework.Entidad.Institucion Institucion { get; set; }

        public VCFramework.Entidad.Persona Persona { get; set;  }

        public VCFramework.Entidad.Region Region { get; set; }

        public VCFramework.Entidad.Comuna Comuna { get; set; }

    }
    public class UsuarioEnvoltorio
    {
        public int Id { get; set;  }

        public string NombreUsuario { get; set; }

        public string NombreCompleto { get; set; }
        public string Rol { get; set; }

    }
    public class NotificacionRetorno
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }

        public string Detalle { get; set; }

        public string Url { get; set; }
    }
}