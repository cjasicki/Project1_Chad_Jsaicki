<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Project1_Chad_Jsaicki.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Project4.css"  type="text/css" />
    <title>Main Menu</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnTechnician" runat="server" style="z-index: 1; left: 177px; top: 372px; position: absolute; width: 135px; margin-top: 8px; height: 45px;" Text="Technician" OnClick="btnTechnician_Click" Font-Bold="True" />
        <p>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="XX-Large" style="z-index: 1; left: 156px; top: 134px; position: absolute; margin-top: 0px; margin-bottom: 1px" Text="Main Menu"></asp:Label>
            </p>
            <asp:Button ID="btnProblem" runat="server" style="z-index: 1; left: 181px; top: 263px; position: absolute; width: 128px; margin-bottom: 0px; height: 45px; bottom: 340px;" Text="Problem List" Font-Bold="True" OnClick="btnProblem_Click" />
            <asp:Button ID="btnReport" runat="server" style="z-index: 1; left: 179px; top: 321px; position: absolute; width: 131px; height: 45px;" Text="Report" Font-Bold="True" OnClick="btnReport_Click" />
        </div>
        <asp:Button ID="btnServiceEvent" runat="server" OnClick="btnServiceEvent_Click" style="z-index: 1; left: 181px; top: 204px; position: absolute; width: 129px; margin-bottom: 0px; height: 45px;" Text="Service Event" Font-Bold="True" />
    </form>
</body>
</html>
