<%@ Page Title="SistemaISLAGO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaISLAGO._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="container">
        <section class="flex-container">
            <form action="" class="formulario__venta">
                <div class="parrafo__principal">
                    <h3 class="principal__text">Nueva venta</h3>
                </div>
                <div class="first__section">
                    <label for="" class="formlabel1">Fecha</label>
                    <input type="date" class="forminput1" placeholder="XX/XX/XX">
                    <label for="" class="formlabel1">N.Factura</label>
                    <input type="text" class="form__nfactura" placeholder="#000">
                    <label for="" class="formlabel1">Nombre Cliente</label>
                    <input type="text" class="forminput1" placeholder="Client name">
                </div>
                <div class="seccion_numero2">
                    <select name="" id="" class="seleccion__productos">
                        <option value="">~~Seleccione su producto~~</option>
                        <option value="">Cuarton 2x3x5</option>
                        <option value="">Clavador 2x2x6</option>
                    </select>
                    <input type="number"  class="form__cantidad" placeholder="cantidad">
                    <input type="number" min="0" class="form__precio" placeholder="precio">
                    <button type="button" class="btnInsertar">Insertar</button>
                </div>
                <!--tabla nueva venta-->
                <div class="tabla__venta">
                    <div class="seccion_numero3">
                        <table style="width: 100%," class="tblventa">
                            <tr>
                                <!--encabezados-->
                                <th>#</th>
                                <th>Producto</th>
                                <th>cantidad</th>
                                <th>precio unitario</th>
                                <th>subtotal</th>
                                <th>accion</th>
                            </tr>
                            <tr>
                                <td>1</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><button class="btndelete">Eliminar</button></td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><button class="btndelete">Eliminar</button></td>
                            </tr>

                        </table>
                    </div>
                </div>
                <div class="contable__bar">
                    <div class="seccion_numero4">
                        <label for="">Descuento</label>
                        <input type="text" class="input__descuento" placeholder="00,00">
                        <label for="">subtotal</label>
                        <input type="text" class="input__subtotal" placeholder="00,00$">
                    </div>
                    <div class="seccion_numero5">
                        <label for="">%IVA</label>
                        <input type="text" class="input__iva" placeholder="00,00%">
                        <label for="" class="label__total">total</label>
                        <input type="text" class="input__total" placeholder="00,00$">
                        <button class="btnfacturar">Facturar</button>
                        <button class="btnanular">Anular</button>
                    </div>
                </div>
            </form>
        </section>
    </div>--%>

    <%--<div class="container">
        <section class="flex-container">
            <form action="" class="formulario__venta">
                <div class="parrafo__principal">
                    <h3 class="principal__text">Nueva venta</h3>
                </div>
                <div class="first__section">
                    <label for="" class="formlabel1">Fecha</label>
                    <input type="date" class="forminput1" placeholder="XX/XX/XX">
                    <label for="" class="formlabel1">N.Factura</label>
                    <input type="text" class="form__nfactura" placeholder="#000">
                    <label for="" class="formlabel1">Nombre Cliente</label>
                    <input type="text" class="forminput1" placeholder="Client name">
                </div>
                <div class="seccion_numero2">
                    <select name="" id="" class="seleccion__productos">
                        <option value="">~~Seleccione su producto~~</option>
                        <option value="">Cuarton 2x3x5</option>
                        <option value="">Clavador 2x2x6</option>
                    </select>
                    <input type="number" class="form__cantidad" placeholder="cantidad">
                    <input type="number" min="0" class="form__precio" placeholder="precio">
                    <button type="button" class="btnInsertar">Insertar</button>
                </div>
                <!--tabla nueva venta-->
                <div class="tabla__venta">
                    <div class="seccion_numero3">
                        <table style="width: 100%," class="tblventa">
                            <tr>
                                <!--encabezados-->
                                <th>#</th>
                                <th>Producto</th>
                                <th>cantidad</th>
                                <th>precio unitario</th>
                                <th>subtotal</th>
                                <th>accion</th>
                            </tr>
                            <tr>
                                <td>1</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <button class="btndelete">Eliminar</button></td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <button class="btndelete">Eliminar</button></td>
                            </tr>

                        </table>
                    </div>
                </div>
                <div class="contable__bar">
                    <div class="seccion_numero4">
                        <label for="">Descuento</label>
                        <input type="text" class="input__descuento" placeholder="00,00">
                        <label for="">subtotal</label>
                        <input type="text" class="input__subtotal" placeholder="00,00$">
                    </div>
                    <div class="seccion_numero5">
                        <label for="">%IVA</label>
                        <input type="text" class="input__iva" placeholder="00,00%">
                        <label for="" class="label__total">total</label>
                        <input type="text" class="input__total" placeholder="00,00$">
                        <button class="btnfacturar">Facturar</button>
                        <button class="btnanular">Anular</button>
                    </div>
                </div>
            </form>
        </section>
    </div>--%>

     <!-- PRODUCT NAV -->
    <div class="tab-pane" style="background-color: #311b92; color: white; border-radius: 5px;">
        <center><h1><span class="glyphicon glyphicon-bell"></span> Últimas Actividades en Sistema <span class="glyphicon glyphicon-bell"></span></h1></center>
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
                                    <center><div> <%#Eval("NombreArticulos") %></div>
                                    <div class="product-pd">
                                        <%--<div class="glyphicon glyphicon-usd"> <%#Eval("Precio") %></div>--%>
                                        <div class="glyphicon glyphicon-tags"> <%#Eval("NombreProveedor") %></div>
                                    </div>
                                    <div class="product-review">
                                        <div class="star">
                                            <div class="glyphicon glyphicon-star"> <%#Eval("NombreCategoria") %></div>
                                        </div>
                                    </div>
                                    <%--<a class="btn btn-info" href="/Visitantes/DetalleArticulo.aspx?ID=<%#Eval("ID_Articulo") %>">Ver Detalle</a>--%>
                                        </center>
                                    <%--con el otro metodo--%>
                                    <%--<a class="btn btn-info" href="/Visitantes/DetalleArticulo.aspx/<%#Eval("ID_Articulo") %>">Ver Detalle</a>--%>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>

</asp:Content>


