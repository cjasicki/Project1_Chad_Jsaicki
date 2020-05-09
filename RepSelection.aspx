<%@ Page Title="" Language="C#" MasterPageFile="~/MySite1.Master" AutoEventWireup="true" CodeBehind="RepSelection.aspx.cs" Inherits="Project1_Chad_Jsaicki.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Button ID="btnMain" CssClass="B1" runat="server" OnClick="btnMain_Click" style="z-index: 1; left:auto; top:auto; position:center" Text="Main Menu" />
    <asp:Button ID="btnRun" CssClass="B1" runat="server" style="z-index: 1; left:auto; top:auto; position:center" Text="Run Report" OnClick="btnRun_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
      <asp:Label ID="lblform" runat="server" Text="Please select report to run "></asp:Label>
    <asp:DropDownList ID="lstReport" runat="server" OnSelectedIndexChanged="lstReport_SelectedIndexChanged" style="z-index: 1; left:auto; top:auto; position:center; width:auto;" CssClass="ddl">
    </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblerr" runat="server" CssClass="R1"></asp:Label>
              
        </div>

</asp:Content>
