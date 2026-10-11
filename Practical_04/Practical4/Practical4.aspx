```aspx
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practical4.aspx.cs" Inherits="Practical4.Practical4" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Event Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server"
                Text="Online Event Registration"
                Font-Bold="True" Font-Size="X-Large" />
            <br /><br />

            <asp:Label ID="lblFullName" runat="server"
                AssociatedControlID="txtFullName"
                Text="Full Name" Font-Bold="True" />
            <asp:TextBox ID="txtFullName" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                runat="server" ControlToValidate="txtFullName"
                ErrorMessage="Full Name is required"
                Display="Dynamic" ForeColor="Red" />
            <br /><br />

            <asp:Label ID="lblEmail" runat="server"
                AssociatedControlID="txtEmail"
                Text="Email ID" Font-Bold="True" />
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Email is required"
                Display="Dynamic" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                runat="server" ControlToValidate="txtEmail"
                ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w+$"
                ErrorMessage="Invalid email"
                Display="Dynamic" ForeColor="Red" />
            <br /><br />

            <asp:Label ID="lblContact" runat="server"
                AssociatedControlID="txtContact"
                Text="Contact No" Font-Bold="True" />
            <asp:TextBox ID="txtContact" runat="server"
                TextMode="Phone" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                runat="server" ControlToValidate="txtContact"
                ErrorMessage="Contact number is required"
                Display="Dynamic" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                runat="server" ControlToValidate="txtContact"
                ValidationExpression="^[0-9]{10}$"
                ErrorMessage="Contact number must contain 10 digits"
                Display="Dynamic" ForeColor="Red" />
            <br /><br />

            <asp:Label ID="lblCollege" runat="server"
                AssociatedControlID="txtCollege"
                Text="College" Font-Bold="True" />
            <asp:TextBox ID="txtCollege" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                runat="server" ControlToValidate="txtCollege"
                ErrorMessage="College is required"
                Display="Dynamic" ForeColor="Red" />
            <br /><br />

            <asp:Label ID="lblDepartment" runat="server"
                Text="Department" Font-Bold="True" Font-Size="Larger" />
            <br />
            <asp:RadioButtonList ID="rblDepartment" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Text="Computer" Value="Computer" />
                <asp:ListItem Text="Mechanical" Value="Mechanical" />
                <asp:ListItem Text="Chemical" Value="Chemical" />
                <asp:ListItem Text="Civil" Value="Civil" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                runat="server" ControlToValidate="rblDepartment"
                ErrorMessage="Please select a department"
                Display="Dynamic" ForeColor="Red" />
            <br />

            <asp:Label ID="lblGender" runat="server"
                Text="Gender" Font-Bold="True" Font-Size="Larger" />
            <br />
            <asp:RadioButtonList ID="rblGender" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Text="Male" Value="Male" />
                <asp:ListItem Text="Female" Value="Female" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                runat="server" ControlToValidate="rblGender"
                ErrorMessage="Please select gender"
                Display="Dynamic" ForeColor="Red" />
            <br />

            <asp:Label ID="lblSkills" runat="server"
                Text="Skills" Font-Bold="True" Font-Size="Larger" />
            <br />
            <asp:CheckBoxList ID="cblSkills" runat="server"
                RepeatDirection="Horizontal">
                <asp:ListItem Text="C#" Value="C#" />
                <asp:ListItem Text="Python" Value="Python" />
                <asp:ListItem Text="AI" Value="AI" />
            </asp:CheckBoxList>
            <asp:CustomValidator ID="CustomValidatorSkills"
                runat="server"
                ErrorMessage="Please select at least one skill"
                Display="Dynamic"
                OnServerValidate="CustomValidatorSkills_ServerValidate"
                ForeColor="Red" />
            <br /><br />

            <asp:Label ID="lblAddress" runat="server"
                AssociatedControlID="txtAddress"
                Text="Address" Font-Bold="True" Font-Size="Larger" />
            <br />
            <asp:TextBox ID="txtAddress" runat="server"
                TextMode="MultiLine" Width="286px" Height="60px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                runat="server" ControlToValidate="txtAddress"
                ErrorMessage="Address is required"
                Display="Dynamic" ForeColor="Red" />
            <br /><br />

            <asp:CheckBox ID="chkTerms" runat="server"
                Text="I accept terms and conditions" />
            <asp:CustomValidator ID="CustomValidatorTerms"
                runat="server"
                ErrorMessage="Please accept terms and conditions"
                Display="Dynamic"
                OnServerValidate="CustomValidatorTerms_ServerValidate"
                ForeColor="Red" />
            <br /><br />

            <asp:Button ID="btnSubmit" runat="server"
                Text="Submit"
                OnClick="btnSubmit_Click" />

            <br /><br />

            <asp:Label ID="lblResult" runat="server"
                ForeColor="Green" />
        </div>
    </form>
</body>
</html>
```