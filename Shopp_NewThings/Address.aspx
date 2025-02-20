<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppNewThings.Master" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="Shopp_NewThings.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="checkout__form m-4 ">
                <asp:LinkButton ID="lnkbAddNewAddress" runat="server" OnClick="lnkbAddNewAddress_Click">Add New Adress</asp:LinkButton>
                <asp:LinkButton ID="lnkbAddYourAddress" runat="server" OnClick="lnkbAddYourAddress_Click">Add Your Adress</asp:LinkButton>
                <h4>Billing Details</h4>
        <div class="row ">
            <div class="col-lg-8 col-md-3" id="addYourAddress" runat="server">
                <h5>Your Address</h5>
                 Select:<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                   <asp:ListItem ></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-8 col-md-3" id="addNewAddress" runat="server">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Fist Name<span>*</span></p>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Last Name<span>*</span></p>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Country<span>*</span></p>
                            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">

                        <div class="checkout__input">
                            <p>Address<span>*</span></p>
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="Street Address" class="checkout__input__add" CssClass="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Land Marks<span>*</span></p>
                            <asp:TextBox ID="TextBox4" runat="server" placeholder="Apartment, suite, unite ect (optinal)" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Town/City<span>*</span></p>
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Country/State<span>*</span></p>
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Postcode / ZIP<span>*</span></p>
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Phone<span>*</span></p>
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="checkout__input">
                            <p>Email<span>*</span></p>
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4  " runat="server" id="divPriceDetails">
                <div class="bg-light border" style="border-radius:5px 5px;">
                    <div class="m-2">
                             <h5 class="proNameViewCart" runat="server" id="h5NoItems"></h5>
                        <asp:Repeater ID="rptrProductDetails" runat="server">
                            <ItemTemplate>
                                <div>
                                    <label>Name</label>
                                    <span class="float-right priceGray" id="span1" runat="server"><%#Eval("PName") %></span>
                                </div>
                                <div>
                                    <label>Price</label>
                                    <span class="float-right priceGreen" id="span2" runat="server"><%#Eval("PPrice","{0:0,00}") %></span>
                                </div>
                                <div>
                                    <label>SelPrice</label>
                                    <span class="float-right priceGreen" id="span3" runat="server"><%#Eval("PSelPrice","{0:c00}") %></span>
                                </div>
                                <div  style="border-bottom:2px solid #eaeaec">
                                    <label>Discount</label>
                                    <span class="float-right priceGreen" id="span4" runat="server"><%#string.Format ("{0}",Convert.ToUInt64(Eval("PPrice")) - Convert.ToUInt64(Eval("PSelPrice"))) %> OFF</span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div style="border-bottom: 2px solid #eaeaec;" class="m-2">
                        <h5 class="proNameViewCart">PRICE DETAILS</h5>
                        <div>
                            <label>Cart Total</label>
                            <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                        </div>
                        <div>
                            <label>Cart Discount</label>
                            <span class="float-right priceGreen" id="spanDiscount" runat="server"></span>
                        </div>
                    </div>
                    <div class="m-2">
                        <div class="proPriceView">
                            <label>Total</label>
                            <span class="float-right" id="spanTotal" runat="server"></span>
                        </div>
                        <div>
                            <asp:Button ID="btnBuyNow" CssClass="buyNowBtn" runat="server" Text="Process to Pyment Method" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
                    
    </div>
</asp:Content>
