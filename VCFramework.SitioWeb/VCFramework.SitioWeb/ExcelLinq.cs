using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace VCFramework.SitioWeb
{
    //public class ExcelLinq
    //{
    //    public static List<ItemExcel> ToEntidad(string filePath)
    //    {
    //        var book = new ExcelQueryFactory(filePath);
    //        var resultado = (from row in book.Worksheet("Carga Masiva de Apoderados")
    //                         let item = new ItemExcel
    //                         {
    //                             Rut = row["Rut (Requerido)"].Cast<string>(),
    //                             Nombres = row["Nombres (Requerido)"].Cast<string>(),
    //                             ApellidoPaterno = row["Apellido Paterno (Requerido)"].Cast<string>()
    //                         }
    //                         select item).ToList();

    //        book.Dispose();
    //        return resultado;
    //    }
    //}
    public class ItemExcel
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public int IdRegion { get; set; }
        public int IdComuna { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdCurso { get; set;  }

    }
    public class ItemError { 
        public List<string> DetalleErrores { get; set; }
        public int CantidadFilasProcesadas { get; set; }

    }
}