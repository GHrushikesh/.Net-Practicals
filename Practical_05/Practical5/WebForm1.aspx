<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs"
    Inherits="Practical5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Date Selection</title>
</head>

<body>
    <form id="form1" runat="server">

        <div>

            <h2>Select Leave Date</h2>

            <asp:Calendar
                ID="Calendar1"
                runat="server"
                OnSelectionChanged="CalAcademic" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
                
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                
                <SelectedDayStyle
                    BackColor="#333399"
                    ForeColor="White" />

                <TodayDayStyle
                    BackColor="#999999" ForeColor="White" />

                <TitleStyle
                    BackColor="#333399"
                    ForeColor="White"
                    Font-Bold="True" BorderStyle="Solid" Font-Size="12pt" Height="12pt" />

            </asp:Calendar>

            <br />

            <asp:Label
                ID="lblselectedDt"
                runat="server"
                ForeColor="Blue">
            </asp:Label>

            <br />
            <br />

            <asp:Button
                ID="btnApplyLeave"
                runat="server"
                Text="Apply Leave"
                OnClick="btnapplyLeave" />

        </div>

    </form>
</body>
</html>