<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppNewThings.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="Shopp_NewThings.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script src="js/Main.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <!-- Product Details Section Begin -->
    <section class="product-details spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-md-4">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="product__details__pic">
                                <div class="product__details__pic__item ">
                                    <img class="product__details__pic__item--large  "
                                        src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg01Name") %>" alt="<%#Eval("PImg01Name") %>">
                                </div>

                                <div class="product__details__pic__slider owl-carousel">

                                    <img data-imgbigurl="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg01Name") %>" alt="<%#Eval("PImg01Name") %>"
                                        src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg01Name") %>">

                                    <img data-imgbigurl="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg02Name") %>" alt="<%#Eval("PImg02Name") %>"
                                        src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg02Name") %>">

                                    <img data-imgbigurl="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg03Name") %>" alt="<%#Eval("PImg03Name") %>"
                                        src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg03Name") %>">

                                    <img data-imgbigurl="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg04Name") %>" alt="<%#Eval("PImg04Name") %>"
                                        src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg04Name") %>">

                                    <img data-imgbigurl="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg05Name") %>" alt="<%#Eval("PImg05Name") %>"
                                        src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg05Name") %>">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-lg-4 col-md-6">
                    <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound">
                        <ItemTemplate>
                            <div class="divDet1 pt-2">
                                <h1 class="proNameView"><%#Eval("PName") %></h1>
                                <span class="proOgPriceView"><%#Eval("PPrice","{0:0,00}") %></span><span class="proPriceDiscountView"> <%# string.Format("{0}",Convert.ToInt64(Eval("PPrice"))-Convert.ToInt64(Eval("PSelPrice"))) %> OFF</span>
                                <p class="proPriceView"><%#Eval("PSelPrice","{0:c00}") %></p>
                            </div>
                            <div>
                                <h5 class="h5Size">SIZE</h5>
                                <div>
                                    <asp:RadioButtonList ID="rblSize" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="rblSize" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Select Your Size"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <table>
                                <tr>
                                    <td class="shoping_cart_quantity">
                                        <asp:Button ID="btnMinus" runat="server" CssClass=" qtybtn1" OnClientClick="azalt(this)" Text="-" />
                                        <asp:TextBox ID="txtQuantity" CssClass="txt" Width="40px" runat="server" value="1"></asp:TextBox>
                                        <asp:Button ID="btnPlus" runat="server" CssClass=" qtybtn2" OnClientClick="arttir(this)" Text="+" />
                                    </td>
                                </tr>
                            </table>


                            <div class="divDet1">
                                <asp:Button ID="btnAddToCart" CssClass="mainButton" runat="server" Text="ADD TO CART" OnClick="btnAddToCart_Click" />
                                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                            </div>
                            <div class="divDet1">
                                <h5 class="h5Size">Description</h5>
                                <p>
                                    <%#Eval("PDescription") %>
                                </p>
                                <h5 class="h5Size">Product Details</h5>
                                <p>
                                    <%#Eval("PProductDetails") %>
                                </p>
                                <h5 class="h5Size">Material & Care</h5>
                                <p>
                                    <%#Eval("PMaterialCare") %>
                                </p>
                            </div>
                            <div>
                                
                                <p><%# ((int)Eval("FreeDelivery")==1)?"FreeDelivery":"" %></p>
                                <p><%# ((int)Eval("DeliveryIn")==1)?"Delivery IN Time":"" %></p>
                                <p>Retuns: <%#Eval("Ret30Days")%>Days</p>
                                <p><%# ((int)Eval("COD")==1)?"Cash on Delivery:":"" %> <%#Eval("CashOnDelivery","{0:c00}")%></p>
                            </div>

                            <asp:HiddenField ID="hfCatID" Value='<%# Eval("PcategoryID") %>' runat="server" />
                            <asp:HiddenField ID="hfSubCatID" Value='<%# Eval("PSubCatID") %>' runat="server" />
                            <asp:HiddenField ID="hfGenderID" Value='<%# Eval("PGenderID") %>' runat="server" />
                            <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
 <!-- Product Details Section End -->
     <script>

     function arttir(ele) {
         if (ele.previousSibling.previousSibling.value > 0) {
             ele.previousSibling.previousSibling.value = parseInt(ele.previousSibling.previousSibling.value) + 1;
         }
     }

     function azalt(ele) {
         arttir
         if (ele.nextSibling.nextSibling.value > 1) {
             ele.nextSibling.nextSibling.value = parseInt(ele.nextSibling.nextSibling.value) - 1;
         }
     }

     </script>
</asp:Content>
