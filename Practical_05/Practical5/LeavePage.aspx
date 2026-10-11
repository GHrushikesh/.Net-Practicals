<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="LeavePage.aspx.cs"
    Inherits="Practical5.LeavePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Application</title>
</head>

<body>
    <form id="form1" runat="server">

        <div>

            <h3>LEAVE APPLICATION</h3>

            Employee ID:
            <asp:TextBox
                ID="TextBox1"
                runat="server">
            </asp:TextBox>

            <br />
            <br />

            Leave Date:
            <asp:Label
                ID="lblLeaveDT"
                runat="server">
            </asp:Label>

            <br />
            <br />

            Leave Type:

            <asp:DropDownList
                ID="DropDownList1"
                runat="server">

                <asp:ListItem>Personal Leave</asp:ListItem>
                <asp:ListItem>Medical Leave</asp:ListItem>
                <asp:ListItem>Emergency Leave</asp:ListItem>

            </asp:DropDownList>

            <br />
            <br />

            Reason:

            <asp:TextBox
                ID="TextBox2"
                runat="server"
                Height="66px"
                Width="227px"
                TextMode="MultiLine">
            </asp:TextBox>

            <br />
            <br />

        </div>

        <p>
            Remember Name:

            <asp:CheckBox
                ID="CheckBox1"
                runat="server"
                Text="Remember My Name" />
        </p>

        <p>
            <asp:Button
                ID="Button1"
                runat="server"
                Text="Submit Leave"
                OnClick="Button1_Click" />
        </p>

        <asp:Label
            ID="lblMessage"
            runat="server">
        </asp:Label>

    </form>
</body>
</html>