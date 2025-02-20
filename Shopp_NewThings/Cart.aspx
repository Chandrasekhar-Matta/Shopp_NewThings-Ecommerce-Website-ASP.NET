<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppNewThings.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Shopp_NewThings.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-top: 20px;">
            <div class="col-md-9">
                <h5 class="proNameViewCart" runat="server" id="h5NoItems"></h5>

                <asp:Repeater ID="rptrCartProducts" runat="server">
                    <ItemTemplate>
                        <div class="media my-3" style="border: 1px solid #eaeaec;">
                            <div class="align-self-center mr-3">
                                <a href="ProductView.aspx?PID=<%#Eval("PID") %>" target="_blank">
                                    <img width="110" class="media-object" src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("PImg01Name") %>" alt="<%#Eval("PImg01Name") %>">
                                </a>
                            </div>
                            <div class="media-body">
                                <h5 class="media-heading proNameViewCart"><%#Eval("PName") %></h5>
                                <p class="proPriceDiscountView">Size : <%#Eval("SizeNamee") %></p>
                                <asp:Label ID="lblSizeName" ForeColor="Red" runat="server"></asp:Label>
                                <span class="proPriceView"><%#Eval("PSelPrice","{0:c00}")%></span>
                                <span class="proOgPriceView"><%#Eval("PPrice","{0:0,00}") %></span>
                                <table>
                                    <tr >
                                        <td class="shoping_cart_quantity">
                                         <asp:Button ID="btnMinus" runat="server" CssClass=" qtybtn1"   OnClientClick="azalt(this)" Text="-" CommandArgument='<%#Eval("PID") + "-" + Eval("SizeIDD")%>' OnClick="btnMinus_Click" />
                                <asp:TextBox ID="txtSeletedQuantity" CssClass="txt" Width="40px" value='<%#Eval("Quantities") %>' runat="server" AutoPostBack="true"></asp:TextBox>
                                <asp:Button ID="btnPlus" runat="server"  CssClass=" qtybtn2" OnClientClick="arttir(this)" Text="+" CommandArgument='<%#Eval("PID") + "-" + Eval("SizeIDD")%>' OnClick="btnPlus_Click"/>                             
                                    </td>
                                    </tr>
                                </table>
                                  <p>
                                   <asp:Button CommandArgument='<%#Eval("PID") + "-" + Eval("SizeIDD") + "-" + Eval("Quantities")%>' ID="btnRemoveItem" OnClick="btnRemoveItem_Click" CssClass="removeButton" runat="server" Text="REMOVE" />
                                </p>
                            </div>
                            <p>
                                <table>
                                    <tr class="text-md-center border">
                                        <th>Each item</th>
                                    </tr>
                                    <tr class="border">
                                        <td>(Pric * Quantity:<%#Eval("Quantities") %>) =
                                        </td>
                                    </tr>
                                    <tr class="border">
                                        <td>
                                            (Price - SelPrice) =
                                        </td>
                                    </tr>
                                    <tr class="border">
                                        <td class="text-danger font-weight-bold">
                                            %
                                        </td>
                                    </tr>
                                </table>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-3 pt-5" runat="server" id="divPriceDetails">
                <div style="border-bottom: 1px solid #eaeaec;">
                    <h5 class="proNameViewCart">PRICE DETAILS</h5>
                    <div>
                        <label>Cart Total</label>
                        <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                    </div>
                    <div>
                        <label >Cart Discount</label>
                        <span class="float-right priceGreen" id="spanDiscount" runat="server"></span>
                    </div>
                </div>
                <div>
                    <div class="proPriceView">
                        <label>Total</label>
                        <span class="float-right" id="spanTotal" runat="server"></span>
                    </div>
                    <div>
                        <asp:Button ID="btnBuyNow" OnClick="btnBuyNow_Click" CssClass="buyNowBtn" runat="server" Text="BUY NOW" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/jquery.nice-select.min.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <script src="js/jquery.slicknav.js"></script>
    <script src="js/mixitup.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
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
