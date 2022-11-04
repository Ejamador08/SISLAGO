<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageArticulo.aspx.cs" Inherits="SistemaISLAGO.Catálogos.PageArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(function () {
            $('#<%=FileUploadArticulo.ClientID%>').on("change", function () {
                var files = !!this.files ? this.files : [];
                if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

                if (/^image/.test(files[0].type)) { // only image file
                    var reader = new FileReader(); // instance of the FileReader
                    reader.readAsDataURL(files[0]); // read the local file

                    reader.onloadend = function () { // set image data as background of div

                        $('#<%=Preview.ClientID%>').attr('src', this.result);
                    }
                }
            });
        });
    </script>
    <asp:MultiView ID="MVArticulo" runat="server">
        <asp:View ID="VistaListadoArt" runat="server">

            <div class="col-md-12">
                <div class="col-md-8"></div>
                <div class="col-md-2">
                    <asp:Button ID="btninactivos" OnClick="btninactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Artículos Inactivos" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnnuevo" OnClick="btnnuevo_Click" class="btn btn-success pull-right" runat="server" Text="Agregar Artículo" />
                </div>
            </div>

            <!-- ARTICLE NAV -->
            <div class="tab-pane" style="background-color: #311b92; color: white; border-radius: 5px;">
                <center>
                    <h1><span class="glyphicon glyphicon-bell"></span>Listado Artículos Disponibles <span class="glyphicon glyphicon-bell"></span></h1>
                </center>
            </div>

            <!-- Buscador de Articulos-->
            <div class="col-md-12">
                <br />
                <br />
                <div class="input-group">
                    <asp:TextBox ID="txtBuscar" placeHolder="Ingresa el artículo que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnBuscarActivos" OnClick="btnBuscarActivos_Click" CssClass="btn btn-primary" runat="server" Text="Buscar" ValidationGroup="agregar" />
                    </span>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Bold="true" ControlToValidate="txtBuscar" ValidationGroup="agregar" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                <br />
                <br />
            </div>
            <br />
            <hr />

            <!-- VISTA DE DATOS EN LA GRID-->
            <asp:GridView ID="GridViewArticulo"
                CssClass="table table-bordered" AllowPaging="true" OnRowCommand="GridViewArticulo_RowCommand" OnDataBound="GridViewArticulo_DataBound" PageSize="7"
                runat="server" DataKeyNames="IDArticuloS" AutoGenerateColumns="false">
                <HeaderStyle BackColor="#6c9ed7" />
                <Columns>
                    <asp:BoundField HeaderText="Artículo" DataField="NombreArticulos" />
                    <%--<asp:BoundField HeaderText="Estado" DataField="Estado" />--%>
                    <asp:BoundField HeaderText="Proveedor" DataField="NombreProveedor" />
                    <asp:BoundField HeaderText="Categoría" DataField="NombreCategoria" />
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" CommandName="cmdEditar" CssClass="btn btn-info" runat="server" Text="Editar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dar de Baja">
                        <ItemTemplate>
                            <%--OnClientClick="return confirm('Esta Seguro de Eliminar el Artículo');"--%>
                            <asp:Button ID="btnEliminar" CommandName="cmdEliminar" CssClass="btn btn-danger" runat="server" Text="Dar de Baja" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <div class="row" style="margin-top: 20px;">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-1" style="text-align: right;">
                            <h3>
                                <asp:Label ID="lblPaginaMedidas" runat="server" Text="Página:" CssClass="label label-info"></asp:Label>
                            </h3>
                        </div>
                        <div class="col-lg-1" style="text-align: left;">
                            <br />
                            <asp:DropDownList ID="DropArto" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropArto_SelectedIndexChanged1" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-lg-2" style="text-align: right;">
                            <h3>
                                <asp:Label ID="lblArtoPageOf" CssClass="label label-warning" runat="server"></asp:Label></h3>
                        </div>
                        <div class="col-lg-4"></div>
                    </div>
                </PagerTemplate>
            </asp:GridView>
        </asp:View>

        <asp:View ID="VistaEdicionArt" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <h1 class="abc text-success" style="font-size: 50px;">Nuevo Artículo</h1>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnIrlista" OnClick="btnIrlista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Artículos" />
                            </div>
                        </div>
                        <hr />
                        <div class="col-md-12">
                            <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <hr />
                        </div>
                        <div class="row">
                            <!-- fila 1 -->
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <%--<label>Código</label>--%>
                                        <asp:TextBox ID="txtCodigo" CssClass="form-control" Visible="false" Enabled="false" runat="server"></asp:TextBox>
                                        <label>Nombre</label>
                                        <%--onkeypress="return SoloTexto(event)" onsubmit="return Validaciones(this)" ValidationGroup="Guardar"--%>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNombre" runat="server" ErrorMessage="Solo se Permiten Letras" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="[A-Za-z | ]*" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="Validation" runat="server" ControlToValidate="txtNombre" ErrorMessage="* El Nombre Es Necesario" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Descripción</label>
                                        <asp:TextBox ID="txtdescripcion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar Artículo" ValidationGroup="Guardar" />
                                    <br />
                                    <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" Visible="false" CssClass="btn btn-warning" runat="server" Text="Actualizar Artículo" />
                                </div>
                            </div>

                            <!-- fila 2 -->
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Fecha Ingreso</label>
                                        <asp:TextBox ID="txtfingreso" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:ImageButton ID="ImgCalendario" OnClick="ImgCalendario_Click" runat="server" ImageUrl="~/Content/img/Calendario.png" />
                                        <asp:Calendar ID="CIngreso" OnSelectionChanged="CIngreso_SelectionChanged" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                        </asp:Calendar>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Fecha Vencimiento</label>
                                        <asp:TextBox ID="txtfvencimiento" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:ImageButton ID="imgfvencim" OnClick="imgfvencim_Click" runat="server" ImageUrl="~/Content/img/Calendario.png" />
                                        <asp:Calendar ID="CVencimiento" OnSelectionChanged="CVencimiento_SelectionChanged" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                        </asp:Calendar>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Unidad de Medida</label>
                                        <asp:TextBox ID="txtmedida" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btncanactu" OnClick="btncanactu_Click" Visible="false" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                </div>
                            </div>

                            <!-- fila 3 -->
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Precio Compra</label>
                                        <asp:TextBox ID="txtpcompra" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Precio Venta</label>
                                        <asp:TextBox ID="txtpventa" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Impuesto</label>
                                        <asp:TextBox ID="txtimpuesto" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>

                            <!-- fila 4 -->
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>

                            <!-- fila 5 -->
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Proveedor</label>
                                        <asp:DropDownList ID="DropProveedor" CssClass="selectpicker form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Categoría</label>
                                        <asp:DropDownList ID="DropCategoria" CssClass="selectpicker form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-3">
                                        </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-2">                                    
                                </div>
                            </div>

                            <!-- fila 6 -->
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>

                            <!-- fila 7 -->
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Imagen</label>
                                        <br />
                                        <asp:Image ID="Preview" Width="40%" Height="50%" ImageUrl="~/Content/img/Artículos/ArticleDefault.png" runat="server" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:FileUpload ID="FileUploadArticulo" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Estado</label><br />
                                        <asp:CheckBox ID="chkEstado" Checked="true" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-3"></div>
                            </div>

                            <!-- fila 8 -->
                            <div class="col-md-12">
                                <div class="col-md-2"></div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnVerCombo" Visible="false" CssClass="btn btn-warning" runat="server" Text="Ver Combo" Enabled="false" />
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>

        <asp:View ID="VistaInactivos" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Artículos Dados de Baja</h1></center>
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btnactivos" OnClick="btnactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Artículos Activos" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnnew" OnClick="btnnew_Click" CssClass="btn btn-success" runat="server" Text="Agregar Artículo" />
                            </div>
                        <div class="col-md-12">
                            <br />
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtbuscainactivos" placeHolder="Ingresa el artículo que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnbuscainactivos" CssClass="btn btn-warning" OnClick="btnbuscainactivos_Click"  runat="server" Text="Buscar" ValidationGroup="agregar" />
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Bold="true" ControlToValidate="txtbuscainactivos" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </div>

                        <asp:GridView ID="GvInactivos" OnRowCommand="GvInactivos_RowCommand" OnDataBound="GvInactivos_DataBound" DataKeyNames="IDArticulos" CssClass="table table-bordered"
                            AutoGenerateColumns="false" AllowPaging="true" PageSize="5" runat="server">
                            <HeaderStyle BackColor="#6c9ed7" />
                            <Columns>
                                <asp:BoundField HeaderText="Artículo" DataField="NombreArticulos" />
                                <asp:BoundField HeaderText="Categoría" DataField="NombreCategoria" />
                                <asp:BoundField HeaderText="Proveedor" DataField="NombreProveedor" />
                                <asp:TemplateField HeaderText="Restaurar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnrestaurar" CommandName="cmdrestaurar" CssClass="btn btn-info" runat="server" Text="Restaurar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-lg-4"></div>
                                    <div class="col-lg-1">
                                        <h3>
                                            <asp:Label ID="lblinicioinac" runat="server" Text="Página:" CssClass="label label-info"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:DropDownList ID="dropinactivos" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="dropinactivos_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2">
                                        <h3>
                                            <asp:Label ID="lblfininactivos" CssClass="label label-warning" runat="server"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col-lg-4"></div>
                                </div>
                            </PagerTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>
