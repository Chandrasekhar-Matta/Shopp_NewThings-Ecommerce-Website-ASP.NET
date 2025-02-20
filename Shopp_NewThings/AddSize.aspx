<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSize.aspx.cs" Inherits="Shopp_NewThings.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="form-horizontal">
             <h2>Add Size</h2>
             <hr />
             <div class="form-group">
                 <div class="row">
                     <div class="col-md-3">
                         <asp:Label ID="lblMainCat" runat="server" CssClass="col-md-2 control-label" Text="MainCategory"></asp:Label>
                         <asp:DropDownList ID="ddlMainCategory" OnSelectedIndexChanged="ddlMainCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlMainCategory" InitialValue="0"></asp:RequiredFieldValidator>
                     </div>
                     <div class="col-md-3">
                         <asp:Label ID="lblCat" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
                         <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlCategory" InitialValue="0"></asp:RequiredFieldValidator>
                     </div>


                     <div class="col-md-3">
                         <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Brand"></asp:Label>
                         <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlBrand" InitialValue="0"></asp:RequiredFieldValidator>
                     </div>


                     <div class="col-md-3">
                         <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Sub Category"></asp:Label>
                         <asp:DropDownList ID="ddlSubCat" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCat_SelectedIndexChanged"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlSubCat" InitialValue="0"></asp:RequiredFieldValidator>
                     </div>

                    
                     <div class="col-md-3">
                         <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Gender"></asp:Label>
                         <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlGender" InitialValue="0"></asp:RequiredFieldValidator>
                     </div>

                     <div class="col-md-3">
                         <asp:Label ID="Label7" runat="server" CssClass="col-md-2 control-label" Text="ADD More Sizes"></asp:Label>
                         <asp:TextBox ID="txtSize" runat="server" CssClass="form-control"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtSize"></asp:RequiredFieldValidator>
                     </div>

                     <div class="col-md-6">
                         <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Click and ADD a Size"></asp:Label>
                         <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary form-control" OnClick="btnAdd_Click" />
                     </div>
                 </div>
             </div>
         </div>
        <h1>Size</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Size</div>

            <asp:Repeater ID="rptrSize" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Size</th>
                                <th>Brand</th>
                                <th>MainCategory</th>
                                <th>Category</th>
                                <th>Sub Category</th>
                                <th>Gender</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("SizeID") %></th>
                        <th><%# Eval("SizeName") %></th>
                        <th><%# Eval("BrandID") %></th>
                        <th><%# Eval("MainCategoryID") %></th>
                        <td><%# Eval("CategoryID") %></td>
                        <td><%# Eval("SubCategoryID") %></td>
                        <td><%# Eval("GenderID") %></td>
                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
