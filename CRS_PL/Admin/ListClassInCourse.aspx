﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ListClassInCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListClassInCourse" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
    <asp:Label ID="categoryID" Text="Course Category" runat ="server" CssClass="h4"></asp:Label>
    <asp:DropDownList ID="categoryListID" runat ="server" OnSelectedIndexChanged="categoryListID_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" > </asp:DropDownList>
    <br />
    <br />
    <br />

    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>
