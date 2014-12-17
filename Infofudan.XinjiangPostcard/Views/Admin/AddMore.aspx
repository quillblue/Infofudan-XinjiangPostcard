<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminMaster.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleHolder" runat="server">
    导入新明信片
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <%using(Html.BeginForm("Upload","Admin",FormMethod.Post,new {enctype="multipart/form-data"}))
      {%>
        <input type="file" name="file" />
        <input type="submit" value="Submit" />
    <%} %>
</asp:Content>
