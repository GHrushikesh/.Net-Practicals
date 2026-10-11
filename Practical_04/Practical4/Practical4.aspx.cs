```csharp
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical4
{
    public partial class Practical4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode =
                UnobtrusiveValidationMode.None;
        }

        protected void CustomValidatorSkills_ServerValidate(
            object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            foreach (ListItem item in cblSkills.Items)
            {
                if (item.Selected)
                {
                    args.IsValid = true;
                    break;
                }
            }
        }

        protected void CustomValidatorTerms_ServerValidate(
            object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkTerms.Checked;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblResult.Text = "";
                return;
            }

            lblResult.ForeColor = System.Drawing.Color.Green;

            lblResult.Text =
                "<b>Registration Successful!</b><br/><br/>" +
                "<b>Name:</b> " + Server.HtmlEncode(txtFullName.Text) + "<br/>" +
                "<b>Email:</b> " + Server.HtmlEncode(txtEmail.Text) + "<br/>" +
                "<b>Contact No:</b> " + Server.HtmlEncode(txtContact.Text) + "<br/>" +
                "<b>College:</b> " + Server.HtmlEncode(txtCollege.Text) + "<br/>" +
                "<b>Department:</b> " + Server.HtmlEncode(rblDepartment.SelectedValue) + "<br/>" +
                "<b>Gender:</b> " + Server.HtmlEncode(rblGender.SelectedValue) + "<br/>" +
                "<b>Skills:</b> " + Server.HtmlEncode(GetSkills()) + "<br/>" +
                "<b>Address:</b> " + Server.HtmlEncode(txtAddress.Text)
                    .Replace("\r\n", "<br/>")
                    .Replace("\n", "<br/>");
        }

        private string GetSkills()
        {
            string skills = "";

            foreach (ListItem item in cblSkills.Items)
            {
                if (item.Selected)
                {
                    if (skills != "")
                    {
                        skills += ", ";
                    }

                    skills += item.Text;
                }
            }

            return skills;
        }
    }
}
```