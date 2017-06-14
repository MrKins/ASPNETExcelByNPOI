<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelImportExport.aspx.cs" Inherits="ASPNETExcelByNPOI.ExcelImportExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:FileUpload ID="excelUpload" runat="server" class="btn btn-primary" Style="background-color: white; color: black" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnImport" runat="server" Text="导入" CssClass="btn btn-primary" OnClick="btnImport_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-warning" OnClick="btnExport_Click" />
        </div>
    </div>

</asp:Content>
