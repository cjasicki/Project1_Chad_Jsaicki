<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemEntry.aspx.cs" Inherits="Project1_Chad_Jsaicki.ProblemEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 234px; top: 435px; position: absolute; width: 151px; height: 39px" Text="Clear" OnClick="btnClear_Click" />
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 24px; top: 227px; position: absolute" Text="* Problem:"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 63px; top: 436px; position: absolute; height: 39px; width: 149px; bottom: 545px" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblTic" runat="server" style="z-index: 1; left: 43px; top: 110px; position: absolute; height: 23px" Text="Ticket #:"></asp:Label>
            <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 24px; top: 148px; position: absolute" Text="Problem #:"></asp:Label>
            <asp:Label ID="lblProduct" runat="server" style="z-index: 1; left: 30px; top: 189px; position: absolute; height: 18px" Text="* Product:"></asp:Label>
            <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 56px; top: 347px; position: absolute" Text="*Tech:"></asp:Label>
            <asp:Label ID="lblTicketNum" runat="server" style="z-index: 1; left: 126px; top: 112px; position: absolute; bottom: 886px" Text="Label"></asp:Label>
            <asp:Label ID="lblProblemNum" runat="server" style="z-index: 1; left: 127px; top: 150px; position: absolute; height: 21px;" Text="1"></asp:Label>
            <asp:DropDownList ID="drpProd" runat="server" style="z-index: 1; left: 125px; top: 185px; position: absolute; width: 137px">
            </asp:DropDownList>
            <asp:DropDownList ID="drpTech" runat="server" style="z-index: 1; left: 123px; top: 346px; position: absolute; width: 195px">
            </asp:DropDownList>
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Overline="False" Font-Size="XX-Large" Font-Underline="True" ForeColor="Red" style="z-index: 1; left: 186px; top: 35px; position: absolute; height: 71px; width: 410px" Text="Problem Entry"></asp:Label>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 73px; top: 577px; position: absolute; width: 298px" Text="Error"></asp:Label>
            <asp:TextBox ID="txtProblem1" runat="server" style="z-index: 1; left: 125px; top: 229px; position: absolute; height: 96px; width: 441px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 64px; position: absolute; height: 42px; width: 320px; top: 491px; right: 1272px; margin-bottom: 0px" Text="Return to Service" />
        </div>
    </form>
</body>
</html>
