<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Shopp_NewThings.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Add Product</h2>
            <hr />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                        <asp:TextBox ID="txtPName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtPName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
                        <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Selling Price"></asp:Label>
                        <asp:TextBox ID="txtSelPrice" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtSelPrice"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="MainCategory"></asp:Label>
                        <asp:DropDownList ID="ddlMainCategory" OnSelectedIndexChanged="ddlMainCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlMainCategory" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label16" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
                        <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlCategory" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Brand"></asp:Label>
                        <asp:DropDownList ID="ddlBrands" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlBrands" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Labe22" runat="server" CssClass="col-md-2 control-label" Text="Sub Category"></asp:Label>
                        <asp:DropDownList ID="ddlSubCategory" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlSubCategory" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label19" runat="server" CssClass="col-md-2 control-label" Text="Gender"></asp:Label>
                        <asp:DropDownList ID="ddlGender" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlGender" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Label ID="Label7" runat="server" CssClass="col-md-2 control-label" Text="Size"></asp:Label>
                <asp:CheckBoxList ID="ckblSize" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                <hr />
                <div class="row">
                    <div class="col-md-3">

                        <asp:Label ID="Label20" runat="server" CssClass="col-md-2 control-label" Text="Quantity"></asp:Label>
                        <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtSelPrice"></asp:RequiredFieldValidator>

                        <%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="cblSize" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label8" runat="server" CssClass="col-md-2 control-label" Text="Descriptions"></asp:Label>
                        <asp:TextBox ID="txtDesc" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label9" runat="server" CssClass="col-md-2 control-label" Text="Product Details"></asp:Label>
                        <asp:TextBox ID="txtPDetails" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtPDetails"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label10" runat="server" CssClass="col-md-2 control-label" Text="Material and Care"></asp:Label>
                        <asp:TextBox ID="txtMatCare" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtMatCare"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <hr />
                <div class="row">
                    
                    <div class="col-md-3">
                        <asp:Label ID="Label24" runat="server" CssClass="col-md-2 control-label" Text="RetunDays"></asp:Label>
                        <asp:TextBox ID="txtRetun30Days" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtRetun30Days"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label25" runat="server" CssClass="col-md-2 control-label" Text="Data and Time"></asp:Label>
                        <asp:TextBox ID="txtDeliveryDataTime" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtDeliveryDataTime"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                          <asp:RadioButton ID="rbFreeDelivery" runat="server" Text="Free Delivery" GroupName="Delivery" OnCheckedChanged="rbFreeDelivery_CheckedChanged" AutoPostBack="true" /><br />
  <asp:RadioButton ID="rbCashOnDelivery" runat="server" Text="Cash On Delivery" GroupName="Delivery" OnCheckedChanged="rbCashOnDelivery_CheckedChanged" AutoPostBack="true" />
                      
       </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCashOnDelivery" CssClass="form-control" runat="server" placeholder="Enter Cash On Delivery"></asp:TextBox>
                    </div>
                </div>
                <asp:Label ID="Label22" runat="server" CssClass="col-md-2 control-label" Text="Images"></asp:Label>
                <hr />
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label11" runat="server" CssClass="col-md-2 control-label" Text="Upload Image1"></asp:Label>
                        <asp:FileUpload ID="fuImg01" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg01"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label12" runat="server" CssClass="col-md-2 control-label" Text="Upload Image2"></asp:Label>
                        <asp:FileUpload ID="fuImg02" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg02"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="Label13" runat="server" CssClass="col-md-2 control-label" Text="Upload Image3"></asp:Label>
                        <asp:FileUpload ID="fuImg03" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg03"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label14" runat="server" CssClass="col-md-2 control-label" Text="Upload Image4"></asp:Label>
                        <asp:FileUpload ID="fuImg04" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg04"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label15" runat="server" CssClass="col-md-2 control-label" Text="Upload Image5"></asp:Label>
                        <asp:FileUpload ID="fuImg05" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg05"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label21" runat="server" CssClass="col-md-2 control-label" Text="Delivery In Time"></asp:Label>
                        <asp:CheckBox ID="cbDIN" runat="server" />
                    </div>

                    <div class="col-md-3 ">
                        <asp:Label ID="Label18" runat="server" CssClass="col-md-2 control-label" Text="COD"></asp:Label>
                        <asp:CheckBox ID="cbCOD" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                    </div>
                </div>

                <asp:Label ID="Label23" runat="server" CssClass="col-md-2 control-label" Text="Select Options"></asp:Label>
                <hr />
                <div class="row ">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
