<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resolution.aspx.cs" Inherits="Project1_Chad_Jsaicki.Resolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Project4.css"  type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" Font-Underline="True" style="z-index: 1; left: 159px; top: 35px; position: absolute" Text="Resolution Entry"></asp:Label>
            <asp:Label ID="lblTechRate" runat="server" style="z-index: 1; top: 428px; position: absolute; left: 468px" Text="Select a Tech"></asp:Label>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 325px; top: 651px; position: absolute" Text="Error" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblTicNum" runat="server" style="z-index: 1; left: 103px; top: 172px; position: absolute" Text="Ticket#:"></asp:Label>
            <asp:TextBox ID="txtRes" runat="server" style="z-index: 1; left: 170px; top: 297px; position: absolute; height: 98px; width: 412px" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="lblProNum" runat="server" style="z-index: 1; left: 83px; top: 213px; position: absolute" Text="Problem#:"></asp:Label>
            <asp:Label ID="lblRes" runat="server" style="z-index: 1; left: 67px; top: 252px; position: absolute" Text="Resolution#:"></asp:Label>
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 53px; top: 296px; position: absolute" Text="* Resolution:"></asp:Label>
            <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 52px; top: 432px; position: absolute" Text="* Technicion:"></asp:Label>
&nbsp;<asp:Label ID="lblHr" runat="server" style="z-index: 1; left: 85px; top: 482px; position: absolute" Text="* Hours:"></asp:Label>
            <asp:Label ID="lblSup" runat="server" style="z-index: 1; left: 76px; top: 524px; position: absolute" Text="Supplies:"></asp:Label>
            <asp:Label ID="lblRD" runat="server" style="z-index: 1; left: 30px; top: 566px; position: absolute" Text="Date Repaired:"></asp:Label>
            <asp:Label ID="lblMile" runat="server" style="z-index: 1; left: 297px; top: 483px; position: absolute" Text="Mileage:"></asp:Label>
            <asp:Label ID="lblMics" runat="server" style="z-index: 1; left: 319px; top: 525px; position: absolute" Text="Misc,:"></asp:Label>
            <asp:Label ID="lblCM" runat="server" style="z-index: 1; left: 490px; top: 480px; position: absolute; margin-bottom: 113px" Text="Cost Miles:"></asp:Label>        
            <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 47px; top: 607px; position: absolute; height: 23px" Text="Date Onsite:"></asp:Label>
            <asp:Label ID="lblReq" runat="server" ForeColor="Black" style="z-index: 1; left: 74px; top: 652px; position: absolute; height: 21px" Text="* Indicates required fields"></asp:Label>
            <asp:TextBox ID="txtMiles" runat="server" style="z-index: 1; left: 390px; top: 481px; position: absolute; width: 50px; height: 18px; " TabIndex="3"></asp:TextBox>
            <asp:TextBox ID="txtMisc" runat="server" style="z-index: 1; left: 388px; top: 522px; position: absolute; width: 50px; height: 18px" TabIndex="6"></asp:TextBox>
            <asp:TextBox ID="txtDateOnsite" runat="server" style="z-index: 1; left: 173px; top: 600px; position: absolute; width: 170px; height: 18px" TextMode="DateTimeLocal" TabIndex="8"></asp:TextBox>
            <asp:TextBox ID="txtSupplies" runat="server" style="z-index: 1; left: 174px; top: 518px; position: absolute; width: 50px; height: 24px" TabIndex="5"></asp:TextBox>
            <asp:TextBox ID="txtDateRep" runat="server" style="z-index: 1; left: 173px; top: 562px; position: absolute; width: 174px; height: 18px" TabIndex="7" TextMode="DateTimeLocal"></asp:TextBox>
            <asp:TextBox ID="txtCostMiles" runat="server" style="z-index: 1; left: 595px; top: 477px; position: absolute; width: 50px; height: 18px" TabIndex="4"></asp:TextBox>
            <asp:Label ID="lblTicketNum" runat="server" style="z-index: 1; left: 181px; top: 172px; position: absolute" Text="Label"></asp:Label>
            <asp:Label ID="lblProblemNum" runat="server" style="z-index: 1; left: 181px; top: 212px; position: absolute" Text="Label"></asp:Label>
            <asp:Label ID="lblResNum" runat="server" style="z-index: 1; left: 181px; top: 251px; position: absolute" Text="Label"></asp:Label>
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" style="z-index: 1; left: 251px; top: 695px; position: absolute; width: 111px; height: 30px" Text="Clear" TabIndex="10" />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" style="z-index: 1; left: 96px; top: 694px; position: absolute; width: 112px; height: 31px; right: 1178px;" Text="Submint" AccessKey="s" TabIndex="9" />
&nbsp;<asp:DropDownList ID="drpTech" runat="server" style="z-index: 1; left: 172px; top: 429px; position: absolute; width: 149px" AutoPostBack="True" OnSelectedIndexChanged="drpTech_SelectedIndexChanged" TabIndex="1">
            </asp:DropDownList>
            <asp:TextBox ID="txtHours" runat="server" AccessKey="h" style="z-index: 1; left: 173px; top: 478px; position: absolute; width: 56px; height: 24px" TabIndex="2"></asp:TextBox>
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 132px; top: 109px; position: absolute; width: 291px; height: 43px" Text="Return to Open Tickets" />
            <asp:Label ID="lbl1" runat="server" style="z-index: 1; left: 343px; top: 186px; position: absolute" Text="Check for No Charge"></asp:Label>
            <asp:Label ID="lblTechRateLable" runat="server" style="z-index: 1; left: 374px; top: 428px; position: absolute" Text="Tech Rate:"></asp:Label>
        </div>
        
        <asp:CheckBox ID="ckb_NoCharge" runat="server" AutoPostBack="True" OnCheckedChanged="ckb_NoCharge_CheckedChanged" style="z-index: 1; left: 391px; top: 210px; position: absolute; height: 32px; width: 159px" />
        
    </form>
</body>
</html>
