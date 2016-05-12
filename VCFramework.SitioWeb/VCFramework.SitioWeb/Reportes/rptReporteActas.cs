using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace VCFramework.SitioWeb.Reportes
{
    public partial class rptReporteActas : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReporteActas()
        {
            InitializeComponent();
        }

        private void rptReporteActas_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
