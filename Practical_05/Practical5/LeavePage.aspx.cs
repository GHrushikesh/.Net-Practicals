using System;

namespace Practical5
{
    public partial class LeavePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LeaveDate"] != null)
                {
                    DateTime leaveDate =
                        (DateTime)Session["LeaveDate"];

                    lblLeaveDT.Text =
                        leaveDate.ToString("dd-MM-yyyy");
                }
                else
                {
                    lblLeaveDT.Text = "No date selected.";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string employeeId = TextBox1.Text;
            string leaveType = DropDownList1.SelectedValue;
            string reason = TextBox2.Text;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Please enter Employee ID.";

                return;
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Please enter reason.";

                return;
            }

            lblMessage.ForeColor =
                System.Drawing.Color.Green;

            lblMessage.Text =
                "Leave submitted successfully!";
        }
    }
}x