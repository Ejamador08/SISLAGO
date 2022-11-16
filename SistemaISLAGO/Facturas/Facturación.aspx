<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturación.aspx.cs" Inherits="SistemaISLAGO.Facturas.Facturación" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Multi vistas para realizar la Facturación -->
    <asp:MultiView ID="MVFacturacion" runat="server">
        <!-- Vista Factura -->
        <asp:View ID="ViewFactura" runat="server">
            <div class="container" style="margin-top: 50px;">
                <center>
                    <h1 style="font-family: Arial, sans-serif;">Facturación de Artículos</h1>
                </center>
                <h4>Información de la Factura</h4>
                <hr />
                <!-- Primer Fila de Cajas de texto -->
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Fecha</label>
                            <asp:TextBox ID="txtfecha" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <center>
                            <label>Nombre del Cliente</label></center>
                        <asp:TextBox ID="txtcliente" CssClass="form-control" runat="server" ValidationGroup="Pagar"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="* Nombre Requerido" ControlToValidate="txtcliente" ValidationGroup="Pagar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="* solo se permiten letras" ValidationGroup="Pagar" ControlToValidate="txtcliente"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Nº de Factura</label>
                            <asp:TextBox ID="txtcodigo" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                <!-- Segunda fila de cajas de texto -->
                <div class="row">
                    <div class="col-md-6">
                        <label style="margin-left: 25px;">Artículo</label>
                        <div class="col-md-12">
                            <div class="col-md-10">
                                <asp:TextBox ID="txtarticulo" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" CssClass="Validation" ErrorMessage="* Artículo Requerido" ValidationGroup="Guardar" ControlToValidate="txtarticulo"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnagreararticulofactura" OnClick="btnagreararticulofactura_Click" CssClass="btn btn-info" runat="server" Text="..."
                                    Height="29px" Width="40px" />
                            </div>
                            <asp:HiddenField ID="HiddenFieldArticulo" runat="server" />
                            <asp:HiddenField ID="HiddenFieldBodega" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Precio: C$</label>
                            <asp:TextBox ID="txtprecio" Width="50%" ReadOnly="true" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Nº Existencia</label>
                            <asp:TextBox ID="txtExistencia" Width="50%" ReadOnly="true" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Cantidad</label>
                            <asp:TextBox ID="txtCantidad" Width="50%" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCantidad" ValidationExpression="[(0-9) | -]*" Display="Dynamic" CssClass="Validation" runat="server" ErrorMessage="* Solo Números se permiten" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" CssClass="Validation" ErrorMessage="* Cantidad Requerida" ValidationGroup="Guardar" ControlToValidate="txtCantidad"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <%--Tercera fila - Vacia--%>
                <div class="col-md-12">
                    <br />
                    <br />
                </div>
                <%--Cuarta fila de cajas de textos--%>
                <div class="col-md-12">
                    <div class="col-md-2">
                        <label>Descuento</label>
                        <asp:CheckBox ID="CheckDescuento" Checked="false" CssClass="form-control" runat="server" />
                    </div>
                    <div class="col-md-2">
                        <br />
                        <asp:DropDownList ID="DropDescuento" CssClass="form-control" runat="server">
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                        <h3>%</h3>
                    </div>
                    <div class="col-md-2">
                        <label>Garantía</label>
                        <asp:CheckBox ID="CheckGarantia" Checked="false" CssClass="form-control" runat="server" />
                    </div>
                    <div class="col-md-5">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success pull-right" runat="server"
                                Text="Agregar Artículo" ValidationGroup="Guardar" />
                        </div>
                    </div>
                </div>
                <%-- Quinta fila - Vacia--%>
                <div class="col-md-12">
                    <br />
                    <br />
                </div>
                <%--Detalle de factura - grid  de agregados--%>
                <center>
                    <h1><i class="glyphicon glyphicon-list">Detalle de la Factura</i></h1>
                </center>
                <asp:GridView ID="GridViewDetalle" CssClass="table table-bordered" AutoGenerateColumns="False" 
                OnRowCommand="GridViewDetalle_RowCommand" DataKeyNames="ID_DetalleTemp" OnRowDataBound="GridViewDetalle_RowDataBound"
                runat="server">
                <HeaderStyle BackColor="#6c9ed7" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="Nombre_Articulo" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                    <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />
                    <%--revisar que la garantia se muestre tambien en la grilla y a factura--%>
                    <%--y que el evetno de aumentar o disminuir funccione correctamente--%>
                    <asp:TemplateField HeaderText="Garantía">
                        <ItemTemplate>
                            <%#Eval ("Garantia") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button class="btn btn-danger" ID="btnEliminar" CommandName="Eliminar" runat="server" Text="Quitar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disminuir Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdisminuir" CssClass="form-control" TextMode="Number" min="1" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="15%" HorizontalAlign="Center"  VerticalAlign="Middle"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disminuir">
                        <ItemTemplate>
                            <asp:Button ID="btndisminuir" CommandName="restar" CssClass="btn btn-success" runat="server" Text="Disminuir" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <br />
                <br />
                <h1 style="margin-left: 40%;">Detalle de la venta</h1>
                <hr />
                <div class="col-md-12">
                    <br />
                    <br />
                </div>
                <asp:UpdatePanel ID="UDPago" runat="server">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <br />
                                <asp:Label ID="lblconversion" runat="server" CssClass="pull-right"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <br />
                                <label class="pull-right">Cambio del Dolar:</label>
                            </div>
                            <div class="col-md-2">
                                <asp:CheckBox ID="CBDolar" AutoPostBack="true" OnCheckedChanged="CBDolar_CheckedChanged" CssClass="form-control pull-right" runat="server" />
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtCambioDolar" Enabled="false" PlaceHolder="Valor del Dolar" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtCambioDolar" Display="Dynamic" CssClass="Validation" runat="server" ErrorMessage="* Solo Números se permiten" ValidationExpression="[(0-9) | -]*"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtdolarrecibido" Enabled="false" PlaceHolder="Cantidad de Dolares" TabIndex="7" AutoPostBack="true" OnTextChanged="txtdolarrecibido_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtdolarrecibido" Display="Dynamic" CssClass="Validation" runat="server" ErrorMessage="* Solo Números se permiten" ValidationExpression="[(0-9) | -]*"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-10">
                                <br />
                                <label class="pull-right">Córdobas:</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtcordobasrecibido" PlaceHolder="Cantidad de Córdobas" AutoPostBack="true" OnTextChanged="txtcordobasrecibido_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtcordobasrecibido" Display="Dynamic" CssClass="Validation" runat="server" ErrorMessage="* Solo Números se permiten" ValidationExpression="[(0-9) | -]*"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-10">
                                <br />
                                <label class="pull-right">Descuento Aplicado:</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtdescapli" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-10">
                                <br />
                                <label class="pull-right">Total Recibido C$:</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtrecibidototal" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-10">
                                <br />
                                <label class="pull-right">Total A Pagar C$:</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txttotalventa" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <br />
                                <asp:Label ID="lblAlert" CssClass="pull-right" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <br />
                                <label class="pull-right">Vuelto:</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtVuelto" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-5"></div>
                            <div class="col-md-3"></div>
                            <div class="col-md-1"></div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-md-12">
                    <br />
                    <br />
                </div>

                <div class="col-md-12">
                    <br />
                    <br />
                </div>

                <div class="col-md-12">
                    <div class="col-md-3"></div>
                    <div class="col-md-2">
                        <asp:Button ID="btnRealizarfactura" OnClick="btnRealizarfactura_Click" CssClass="btn btn-warning" runat="server" Text="Realizar Venta" ValidationGroup="facturar" /><%--ValidationGroup="Pagar"--%>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server"
                            Text="Cancelar Venta" />
                    </div>
                    <div class="col-md-3"></div>
                </div>

            </div>







        </asp:View>

        <asp:View ID="VArticulosFact" runat="server">
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <hr />
                    <asp:GridView ID="GridViewArticuloFactura" OnRowCommand="GridViewArticuloFactura_RowCommand" HorizontalAlign="Center" OnDataBound="GridViewArticuloFactura_DataBound"
                        DataKeyNames="IDArticulos" AutoGenerateColumns="False" runat="server" AllowPaging="true" PageSize="5">
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle BackColor="YellowGreen" />
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" CommandName="agregar" Height="40px" ImageUrl="~/Content/img/Iconos/check.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Artículo" DataField="NombreArticulos" />
                        </Columns>
                        <PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-2" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="lblinicio" CssClass="label label-info" runat="server" Text="Pagina:"></asp:Label>
                                    </h5>
                                </div>
                                <div class="col-lg-2" style="text-align: right;">
                                    <asp:DropDownList ID="DropArticuloFactura" Width="70px" OnSelectedIndexChanged="DropArticuloFactura_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-lg-8" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblfin" CssClass="label label-warning" runat="server"></asp:Label>
                                    </h3>
                                </div>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                    <hr />
                </div>
                <div class="col-lg-2"></div>
            </div>
        </asp:View>

    </asp:MultiView>


</asp:Content>
