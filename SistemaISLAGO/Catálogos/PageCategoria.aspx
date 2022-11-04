<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageCategoria.aspx.cs" Inherits="SistemaISLAGO.Catálogos.PageCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MVCategorias" runat="server">
        <asp:View ID="VistaListadoCat" runat="server">
            <!-- CATEGORY NAV -->
            <div class="tab-pane" style="background-color: #311b92; color: white; border-radius: 5px;">
                <center>
                    <h1><span class="glyphicon glyphicon-bell"></span>Listado Categorías Habilitadas <span class="glyphicon glyphicon-bell"></span></h1>
                </center>
            </div>
            <br />
            <br />
        </asp:View>
        <asp:View ID="VistaEdiciónCat" runat="server">

        </asp:View>
    </asp:MultiView>
</asp:Content>
