<%@ Page Title="SistemaISLAGO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaISLAGO._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .aki {
            height: 230px;
            width: 200px;
            margin-left:20px;
        }
    </style>

    <!-- Banner dedicado a los artículos - INICIO -->
    <!-- PRODUCT NAV -->
    <div class="tab-pane" style="background-color: #311b92; color: white; border-radius: 5px;">
        <center>
            <h1><span class="glyphicon glyphicon-bell"></span>Artíclos Agregados Recientemente al Sistema<span class="glyphicon glyphicon-bell"></span></h1>
        </center>
    </div>
    <br />
    <br />
    <!-- PRODUCTS -->
    <div class="tab-content">
        <!-- Featured Products -->
        <div role="tabpanel" class="tab-pane fade in active" id="tab_one">
            <div class="row">
                <asp:ListView ID="ListarArticulos" runat="server">
                    <ItemTemplate>
                        <div class="abajo col-md-3 col-sm-6">
                            <div class="product-singleArea">
                                <div class="aki product-img">
                                    <%--<div class="overlay"></div>--%>
                                    <img class="img-responsive primary_image" src="../<%#Eval("Imagen")%>" />
                                </div>
                                <div class="product-details">
                                    <center>
                                        <div><%#Eval("NombreArticulos") %></div>
                                        <div class="product-pd">
                                            <div class="glyphicon glyphicon-tags"><%#Eval("NombreProveedor") %></div>
                                        </div>
                                        <div class="product-review">
                                            <div class="star">
                                                <div class="glyphicon glyphicon-star"><%#Eval("NombreCategoria") %></div>
                                            </div>
                                        </div>
                                    </center>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <!-- Banner dedicado a los artículos - FIN -->


    <!-- Banner dedicado a los aproveedores - INICIO -->

    <!-- Banner dedicado a los aproveedores - FIN -->
</asp:Content>


