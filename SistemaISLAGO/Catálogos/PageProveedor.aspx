<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageProveedor.aspx.cs" Inherits="SistemaISLAGO.Catálogos.PageProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MVProveedor" runat="server">
        <asp:View ID="VistaListadoPro" runat="server">
            <!-- SUPPLIER NAV -->
            <div class="tab-pane" style="background-color: #311b92; color: white; border-radius: 5px;">
                <center>
                    <h1><span class="glyphicon glyphicon-bell"></span>Listado Contactos de Proveedores <span class="glyphicon glyphicon-bell"></span></h1>
                </center>
            </div>
            <br />
            <br />
        </asp:View>
        <asp:View ID="VistaEdicionPro" runat="server">

        </asp:View>
    </asp:MultiView>
</asp:Content>
