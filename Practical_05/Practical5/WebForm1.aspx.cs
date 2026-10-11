using System;

namespace Practical5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CalAcademic(object sender, EventArgs e)
        {
            DateTime sldt = Calendar1.SelectedDate;

            lblselectedDt.Text =
                "Selected Date: " + sldt.ToString("dd-MM-yyyy");

            // Store selected date in Session
            Session["LeaveDate"] = sldt;
        }

        protected void btnapplyLeave(object sender, EventArgs e)
        {
            // Check if date is selected
            if (Calendar1.SelectedDate == DateTime.MinValue)
            {
                lblselectedDt.Text = "Please select a date first.";
                return;
            }

            // Store selected date
            Session["LeaveDate"] = Calendar1.SelectedDate;

            // Redirect to second page
            Response.Redirect("LeavePage.aspx");
        }
    }
}