﻿<%@ Page Title="Report_Page" Language="C#" MasterPageFile="~/MySite1.Master" AutoEventWireup="true" CodeBehind="RepDisplay.aspx.cs" Inherits="Project1_Chad_Jsaicki.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblDisplay" CssClass="lbl1" runat="server" Text="Report Page"></asp:Label><br /><br />
    <asp:Button ID="Button1" runat="server" CssClass="B1" OnClick="btnMain_Click" style="z-index: 1; left: auto; top: auto; position:center; width: 152px" Text="Main Menu" />
    <asp:Button ID="Button2" runat="server" CssClass="B1" OnClick="btnReturn_Click" style="z-index: 1;left: auto; top: auto; position:center; width: 152px" Text="Return to Reports" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <asp:GridView ID="gvReport" runat="server" style="z-index: 1; left: auto; top: auto; position:center; height:auto; width:auto"
                GridLines="None"
    AllowPaging="true"
    CssClass="mGrid"
    PagerStyle-CssClass="pgr"
    AlternatingRowStyle-CssClass="alt">
    </asp:GridView>
        </div>
</asp:Content>