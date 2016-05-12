using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.DinamicHTML
{
    public class Encabezado
    {
        public int UsaImagenSuperior { get; set; }
        public string UrlImagenSuperior { get; set; }

        public string TituloEncabezado { get; set; }

        public string SubtiTuloEncabezado { get; set; }

        public int InstId { get; set; }
        public static Encabezado Obtener(int idInstitucion)
        {
            Encabezado retorno = new Encabezado();
            retorno.InstId = idInstitucion;

            if (idInstitucion == 0)
            {
                //valores por defecto 
                retorno.UsaImagenSuperior = 1;
                retorno.UrlImagenSuperior = "~/img/encabezadoCPASN.png";
                retorno.TituloEncabezado = "CPAS";
                retorno.SubtiTuloEncabezado = "Centro de Padres y Apoderados";

            }
            else
            {
                List<Encabezado> lista = ListarEncabezado(idInstitucion);
                if (lista != null && lista.Count > 0)
                {
                    Encabezado enc = lista[0];
                    retorno.SubtiTuloEncabezado = enc.SubtiTuloEncabezado;
                    retorno.TituloEncabezado = enc.TituloEncabezado;
                    retorno.UrlImagenSuperior = enc.UrlImagenSuperior;
                    retorno.UsaImagenSuperior = enc.UsaImagenSuperior;
                    
                }
                else
                {
                    //valores desde la base de datos
                    retorno.UsaImagenSuperior = 1;
                    retorno.UrlImagenSuperior = "~/img/encabezadoCPASN.png";
                    retorno.TituloEncabezado = "CPAS";
                    retorno.SubtiTuloEncabezado = "Centro de Padres y Apoderados";
                }
            }
            return retorno;

        }
        public static List<Encabezado> ListarEncabezado(int idIstitucion)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            VCFramework.NegocioMySQL.FiltroGenerico filtro = new NegocioMySQL.FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = idIstitucion.ToString();
            List<object> lista = fac.Leer<Encabezado>(filtro);
            List<Encabezado> lista2 = new List<Encabezado>();
            if (lista != null)
            {
                lista2 = lista.Cast<Encabezado>().ToList();
            }
            return lista2;
        } 

        public static Encabezado Obtener(VCFramework.Entidad.AutentificacionUsuario aus, VCFramework.Entidad.Institucion inst)
        {
            Encabezado retorno = new Encabezado();

            if (inst.Id == 0)
            {
                //valores por defecto 
                retorno.UsaImagenSuperior = 1;
                retorno.UrlImagenSuperior = "~/img/encabezadoCPASN.png";
                retorno.TituloEncabezado = "CPAS";
                retorno.SubtiTuloEncabezado = "Centro de Padres y Apoderados";

            }
            else
            {
                //valores desde la base de datos

                retorno.UsaImagenSuperior = 1;
                retorno.UrlImagenSuperior = "~/img/encabezadoCPASN.png";
                retorno.TituloEncabezado = "CPAS";
                retorno.SubtiTuloEncabezado = "Centro de Padres y Apoderados";
            }
            return retorno;

        }


    }
}
