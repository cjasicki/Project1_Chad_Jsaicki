<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Technician.aspx.cs" Inherits="Project1_Chad_Jsaicki.Technician" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tech. Maint.</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHRate" runat="server" Font-Bold="True" style="z-index: 1; left: 39px; top: 464px; position: absolute" Text="* Hourly Rate:"></asp:Label>
            <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 433px; top: 565px; position: absolute; height: 50px; width: 111px" Text="Clear" Enabled="False" />
            <asp:Button ID="btnCancel" runat="server" Enabled="False" style="z-index: 1; left: 162px; top: 566px; position: absolute; absolute; height: 50px;width: 110px" Text="Cancel" />
            <asp:Button ID="btnAccept" runat="server" Enabled="False" style="z-index: 1; left: 33px; top: 566px; position: absolute; absolute; height: 50px;width: 110px" Text="Accept" />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 29px; top: 111px; position: absolute; height: 50px; width: 256px;" Text="Return to MainMenu" Font-Bold="True" Font-Size="Large" />
            <asp:Button ID="btnReturn0" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 29px; top: 111px; position: absolute; height: 50px; width: 256px; bottom: 541px;" Text="Return to MainMenu" Font-Bold="True" Font-Size="Large" />
            <asp:Button ID="btnRemove" runat="server" Enabled="False" style="z-index: 1; left: 291px; top: 567px; position: absolute; width: 110px; right: 653px; height: 50px; margin-top: 0px" Text="Remove" />
            <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 385px; top: 179px; position: absolute" Text="New Technician" />
            <asp:Label ID="lblLName" runat="server" Font-Bold="True" style="z-index: 1; left: 49px; top: 307px; position: absolute" Text="* Last Name:"></asp:Label>
            <asp:Label ID="lblReqFields" runat="server" ForeColor="Red" style="z-index: 1; left: 22px; top: 513px; position: absolute; width: 261px" Text="* indicate required fields"></asp:Label>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 18px; top: 625px; position: absolute; margin-top: 0px" Text="(Error Message)"></asp:Label>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="XX-Large" style="z-index: 1; left: 118px; top: 35px; position: absolute; margin-top: 6px; margin-bottom: 0px" Text="Technician Maintenance"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" Font-Bold="True" style="z-index: 1; left: 91px; top: 428px; position: absolute; height: 22px" Text="* Phone:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 173px; top: 429px; position: absolute"></asp:TextBox>
            <asp:Label ID="lblDept" runat="server" Font-Bold="True" style="z-index: 1; left: 58px; top: 387px; position: absolute; right: 899px" Text="Department:"></asp:Label>
            <asp:Label ID="Label5" runat="server" Font-Bold="True" style="z-index: 1; left: 43px; top: 268px; position: absolute; height: 22px; width: 129px; margin-top: 0px" Text="Middle Initial:"></asp:Label>
            <asp:Label ID="Label6" runat="server" Font-Bold="True" style="z-index: 1; left: 46px; top: 230px; position: absolute" Text="* First Name:"></asp:Label>
            <asp:Label ID="lblTech" runat="server" Font-Bold="True" style="z-index: 1; left: 62px; top: 183px; position: absolute; right: 894px" Text="Technician:"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" Font-Bold="True" style="z-index: 1; left: 105px; top: 346px; position: absolute" Text="EMail:"></asp:Label>
            <asp:TextBox ID="txtFName" runat="server" style="z-index: 1; left: 171px; top: 230px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtMInitial" runat="server" style="z-index: 1; left: 170px; top: 267px; position: absolute; width: 40px"></asp:TextBox>
            <asp:TextBox ID="txtLName" runat="server" style="z-index: 1; left: 171px; top: 307px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEMail" runat="server" style="z-index: 1; left: 171px; top: 345px; position: absolute; width: 274px"></asp:TextBox>
            <asp:TextBox ID="txtDept" runat="server" style="z-index: 1; left: 172px; top: 389px; position: absolute; width: 110px; margin-top: 0px"></asp:TextBox>
            <asp:TextBox ID="txtRate" runat="server" style="z-index: 1; left: 172px; top: 465px; position: absolute; width: 106px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; left: 171px; top: 184px; position: absolute; width: 194px">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
