using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Drawing;

namespace VCFramework.SitioWeb.controles
{
    public partial class VerticalAppointment : System.Web.UI.UserControl
    {
        VerticalAppointmentTemplateContainer Container { get { return (VerticalAppointmentTemplateContainer)Parent; } }
        VerticalAppointmentTemplateItems Items { get { return Container.Items; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblHeader.Text = GetHeaderText();
            this.lblSubject.Text = Container.AppointmentViewInfo.Appointment.Subject;
            this.lblLocation.Text = Container.AppointmentViewInfo.Appointment.Location;
            this.lblDescription.Text = Container.AppointmentViewInfo.Appointment.Description;

            LayoutAppointmentImages();
        }

        string GetHeaderText()
        {
            string start = Container.AppointmentViewInfo.AppointmentInterval.Start.ToShortTimeString();
            string end = Container.AppointmentViewInfo.Appointment.End.ToShortTimeString();
            return String.Format("{0} - {1}", start, end);
        }
        void LayoutAppointmentImages()
        {
            int count = Items.Images.Count;
            for (int i = 0; i < count; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();
                AddImage(cell, Items.Images[i]);
                row.Cells.Add(cell);
                //imageContainer.Rows.Add(row);
            }
        }
        void AddImage(HtmlTableCell targetCell, AppointmentImageItem imageItem)
        {
            Image image = new Image();
            imageItem.ImageProperties.AssignToControl(image, false);
            targetCell.Controls.Add(image);
        }
    }
}