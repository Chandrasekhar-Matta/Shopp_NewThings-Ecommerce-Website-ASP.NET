<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppNewThings.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="Shopp_NewThings.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>
    </div>
   
    <asp:FormView ID="fviewUserDetails" runat="server"  DataKeyNames="Uid" OnModeChanging="fviewUserDetails_ModeChanging" >
        <ItemTemplate>
            <div class="container-sm border p-2 m-2">
                <table class=" border border-primary">
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Name</th>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                            <asp:Label ID="Labe" runat="server" Text='<%#Eval("LastName") %>'></asp:Label></td>
                    </tr>
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Email</th>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Email") %>'></asp:Label></td>
                    </tr >
                    <tr class=" border border-primary">
                        <th class=" border border-primary">PhoneNumber</th>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label></td>
                    </tr>
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Usertype</th>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Usertype") %>'></asp:Label></td>
                    </tr>
                    <tr><%--OnClick="btnEdit_Click"--%>
                    <td colspan="2">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton7" runat="server" CommandName="New">New</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
              </td>
                </tr>
                </table>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="container-sm border p-2 m-2">
                <table class=" border border-primary">
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Name</th>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Bind("Name") %>'></asp:TextBox>
                    </tr>
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Email</th>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%#Bind("Email") %>'></asp:TextBox>
                    </tr>
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Username</th>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%#Bind("Username") %>'></asp:TextBox>
                    </tr>
                    <tr class=" border border-primary">
                        <th class=" border border-primary">Usertype</th>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%#Bind("Usertype") %>'></asp:TextBox>
                    </tr>
                    <tr>
                        <td>
                                           <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Update">Update</asp:LinkButton>

                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
             <div class="container-sm border p-2 m-2">
     <table class=" border border-primary">
         <tr class=" border border-primary">
             <th class=" border border-primary">Name</th>
             <td>
                 <asp:TextBox ID="TextBox1" runat="server" Text='<%#Bind("Name") %>'></asp:TextBox>
         </tr>
         <tr class=" border border-primary">
             <th class=" border border-primary">Email</th>
             <td>
                 <asp:TextBox ID="TextBox2" runat="server" Text='<%#Bind("Email") %>'></asp:TextBox>
         </tr>
         <tr class=" border border-primary">
             <th class=" border border-primary">Username</th>
             <td>
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Bind("Username") %>'></asp:TextBox>
         </tr>
         <tr class=" border border-primary">
             <th class=" border border-primary">Usertype</th>
             <td>
                 <asp:TextBox ID="TextBox4" runat="server" Text='<%#Bind("Usertype") %>'></asp:TextBox>
         </tr>
         <tr>
             <td>
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Insert">Insert</asp:LinkButton>
                             <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
             </td>
         </tr>
     </table>
 </div>
        </InsertItemTemplate>
        
    </asp:FormView>
    <asp:FormView ID="FormView1" runat="server">
        <ItemTemplate>
            <div class="container-sm border p-2 m-2">
                <table class=" border border-primary">
                    <tr class=" border border-primary">
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <script src="js/bootstrap.bundle.min.js"></script>
</asp:Content>
