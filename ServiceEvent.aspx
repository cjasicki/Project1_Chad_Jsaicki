<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEvent.aspx.cs" Inherits="Project1_Chad_Jsaicki.ServiceEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 29px; top: 111px; position: absolute; height: 50px; width: 256px; bottom: 541px;" Text="Return to MainMenu" Font-Bold="True" Font-Size="Large" />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="XX-Large" style="z-index: 1; left: 118px; top: 35px; position: absolute; margin-top: 6px; margin-bottom: 0px" Text="Service Event Entry"></asp:Label>
            <asp:Label ID="lblClient" runat="server" style="z-index: 1; left: 39px; top: 217px; position: absolute" Text="* Client:"></asp:Label>
            <asp:Button ID="btnClear" runat="server" Font-Bold="True" style="z-index: 1; left: 215px; top: 384px; position: absolute; width: 125px" Text="Clear" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 31px; top: 444px; position: absolute" Text="(Error Message)"></asp:Label>
            <asp:Label ID="lblReqFields" runat="server" ForeColor="Red" style="z-index: 1; left: 54px; top: 338px; position: absolute; width: 261px" Text="* indicate required fields"></asp:Label>
            <asp:Button ID="btnNext" runat="server" Font-Bold="True" style="z-index: 1; left: 57px; top: 386px; position: absolute; width: 124px; right: 873px" Text="Next" />
            <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 15px; top: 177px; position: absolute; width: 115px" Text="Event Date:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 118px; top: 284px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtContact" runat="server" style="z-index: 1; left: 118px; top: 252px; position: absolute"></asp:TextBox>
            <asp:DropDownList ID="ddClient" runat="server" style="z-index: 1; left: 117px; top: 216px; position: absolute; height: 20px; width: 164px">
            </asp:DropDownList>
            <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 36px; top: 286px; position: absolute; height: 22px" Text="* Phone:"></asp:Label>
            <asp:Label ID="lblContact" runat="server" style="z-index: 1; left: 26px; top: 253px; position: absolute; margin-top: 0px" Text="* Contact:"></asp:Label>
        </div>
    </form>
</body>
</html>
