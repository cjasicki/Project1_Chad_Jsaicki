<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemList.aspx.cs" Inherits="Project1_Chad_Jsaicki.ProblemList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="XX-Large" style="z-index: 1; left: 226px; top: 40px; position: absolute" Text="Open Problem List"></asp:Label>
        <div>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 45px; top: 88px; position: absolute" Text="Error Label"></asp:Label>
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 44px; top: 126px; position: absolute" Text="Return to Main Menu" />
            <asp:GridView ID="gvProblemList" runat="server" AutoGenerateColumns="true"  style="z-index: 1; left: 23px; top: 188px; position: absolute; height: 152px; width: 753px" OnRowCommand="gvProblemList_RowCommand">
            <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDettCollez" runat="server" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'
                    CommandName="Select" Text="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            
            </asp:GridView>
        </div>
        <asp:TextBox ID="TextBox" runat="server" style="z-index: 1; left: 325px; top: 639px; position: absolute"></asp:TextBox>
    </form>
</body>
</html>
