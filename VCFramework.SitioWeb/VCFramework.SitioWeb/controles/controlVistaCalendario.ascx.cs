using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.controles
{
    public partial class controlVistaCalendario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string UsuId {
            get
            { return lblUsuId.Text; }
            set { lblUsuId.Text = value; } }

    }
}