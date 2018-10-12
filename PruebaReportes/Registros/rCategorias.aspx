<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCategorias.aspx.cs" Inherits="PruebaReportes.Registros.rCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <label for="TextBoxCategoriaID">ID</label>
    <div class="form-row">
        <div class="form-group col-md-1">
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxCategoriaID" runat="server" placeholder="ID"></asp:TextBox>
        </div>
        <div class="btn-group-col-md-1">
            <asp:Button class="btn btn-primary" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxDescripcion">Descripcion</label>
            <asp:TextBox class="form-control" ID="TextBoxDescripcion" runat="server" placeholder="Descripcion" autocomplete="off" ControlToValidate="TextBoxNombre"></asp:TextBox>
        </div>
        
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxPresupuesto">Presupuesto</label> 
            <asp:TextBox class="form-control" ID="TextBoxPresupuesto" TextMode="Number" runat="server" placeholder="Presupuesto" autocomplete="off"></asp:TextBox>
        </div>
    </div>
    <div class="btn-block">
        <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click"/>
        <asp:Button class="btn btn-success" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click"/>
        <asp:Button class="btn btn-danger" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click"/>
    </div>
</asp:Content>
