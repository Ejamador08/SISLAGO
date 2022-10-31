<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageArticulo.aspx.cs" Inherits="SistemaISLAGO.Catálogos.PageArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MVArticulo" runat="server">
        <asp:View ID="VistaListado" runat="server">

        </asp:View>
        <asp:View ID="VistaEdicion" runat="server"></asp:View>
    </asp:MultiView>
</asp:Content>
