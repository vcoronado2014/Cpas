<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditorArticulos.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.EditorArticulos" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.accordion.js"></script>

    <script type="text/javascript">
        $(document).foundation();
    </script>
    <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-settings padding-right-15"></i>Administración de Artículos</span>
    </div>
    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                <h4>¿Desea Agregar otro Artículo?</h4>

                <div class="row">
                    <div class="medium-9 columns">
                        <p>Presione nuevo y será redirigido a la página de creación</p>
                    </div>
                    <div class="medium-3 columns">
                        <a href="usuarioEditar.aspx?eliminar=false&editar=false&nuevo=true&id=0" class="radius button right">Nuevo</a>
                    </div>
                </div>
            </div>

        </div>
    </div>   
    <div class="medium-12 columns">
        <dx1:ASPxGridView ID="grillaArticulos" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%" ClientInstanceName="grid" KeyFieldName="Id">
            <%--<Settings ShowVerticalScrollBar="true" VerticalScrollableHeight="0" />--%>
            <Settings ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
            <SettingsBehavior AllowSort="False" />
            <Columns>
                <dx:GridViewDataTextColumn FieldName="Id" Visible="False" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Visible" Visible="False" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UsaImagen" Visible="False" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UrlImagen" VisibleIndex="4" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Fecha" Visible="False" VisibleIndex="5">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UsaFecha" Visible="False" VisibleIndex="6">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UsaTitulo" Visible="False" VisibleIndex="7">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Titulo" VisibleIndex="8" Width="30%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Contenido" VisibleIndex="9" Width="55%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Eliminado" Visible="False" VisibleIndex="10">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="InstId" Visible="False" VisibleIndex="11">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0" Width="15%">
                    <DataItemTemplate>
                        <asp:HyperLink ID="hlInicio" runat="server" CssClass="item" NavigateUrl='<%# Eval("Id", "usuarioEditar.aspx?editar=true&eliminar=false&nuevo=false&id={0}")%>'>
                                        <span data-tooltip aria-haspopup="true" class="has-tip" title="Editar">
                                                                                <i class="foundicon-edit" ></i></span>
                        

                        </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="item" NavigateUrl='<%# Eval("Id", "usuarioEditar.aspx?eliminar=true&editar=false&nuevo=false&id={0}")%>' data-tooltip aria-haspopup="true" class="has-tip" title="Eliminar">
                                        <i class="foundicon-trash"></i>
                        
                        </asp:HyperLink>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
            </Columns>
            <Styles>
                <Header BackColor="#D8D8D8" Font-Bold="True" ForeColor="#222222" Wrap="True">
                    <Paddings Padding="1%" />
                    <BackgroundImage Repeat="NoRepeat" />
                </Header>
                <GroupRow BackColor="#D8D8D8">
                </GroupRow>
                <GroupPanel BackColor="#D8D8D8">
                </GroupPanel>
                <HeaderPanel BackColor="#D8D8D8" ForeColor="#222222" Wrap="True">
                    <Paddings Padding="0px" />
                </HeaderPanel>
                <HeaderFilterItem BackColor="#D8D8D8">
                </HeaderFilterItem>
            </Styles>
            <Border BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px" />
        </dx1:ASPxGridView>


        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListarArticulos" TypeName="VCFramework.DinamicHTML.Articulo">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="3" Name="idIstitucion" SessionField="INST_ID" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipoArticulo" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
        </div>
    </asp:Content>
