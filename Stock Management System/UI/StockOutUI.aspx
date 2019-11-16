<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="Stock_Management_System.UI.StockOutUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="alert bg-primary text-center">Stock Out</h2>
        <hr />
        <label id="lblShow" runat="server" class="col-md-offset-4 text-center text-success"></label>
        <br />
        <br />
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-md-4 control-label">Company :</label>
                        <asp:DropDownList runat="server" ID="ddlCompany" DataTextField="Name" DataValueField="Id" class="col-md-6 form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"/>
                    </div>
                    <div class="form-group">
                        <label class="col-md-4 control-label">Item :</label>
                        <asp:DropDownList runat="server" ID="ddlItem" DataTextField="Name" DataValueField="Id" class="col-md-6 form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"/>
                    </div> 
                    <div class="form-group">
                        <label class="col-md-4 control-label">Reorder Level :</label>
                        <input id="inputReorderLevel" runat="server" readonly class="col-md-6 form-control" value="0"/>
                    </div>
                    <div class="form-group">
                        <label class="col-md-4 control-label">Available Quantity :</label>
                        <input id="inputAvailableQuantity" runat="server" readonly class="col-md-6 form-control" />
                    </div>
                    <div class="form-group">
                        <label class="col-md-4 control-label">Stock Out Quantity :</label>
                        <input id="inputStockOutQuantity" runat="server" class="col-md-6 form-control" />
                    </div>
                    <div class="col-md-offset-4">
                        <asp:Button ID="btnAdd" runat="server" BackColor="#009933" ForeColor="White" OnClick="btnAdd_Click" Text="Add" BorderColor="#33CC33" Height="28px" Width="66px" />
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <asp:GridView ID="gridStockOut" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="Medium" ForeColor="#333333" GridLines="None" Height="161px" HorizontalAlign="Center" Width="661px">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
                <Columns>
                    <asp:TemplateField HeaderText="SL No.">
                        <ItemTemplate>
                            <%#Eval("Id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <%#Eval("Item") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <%#Eval("Company") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <%#Eval("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <hr />
            <div class="col-md-offset-4">
                <asp:Button ID="btnSell" runat="server" BackColor="#009933" ForeColor="White" OnClick="btnSell_Click" Text="Sell" BorderColor="#33CC33" Height="28px" Width="66px" />
                &nbsp;<asp:Button ID="btnDamage" runat="server" BackColor="#FF9900" ForeColor="White" OnClick="btnDamage_Click" Text="Damage" BorderColor="#FFCC00" Height="28px" Width="66px" />
                &nbsp;<asp:Button ID="btnLost" runat="server" BackColor="Red" ForeColor="White" OnClick="btnLost_Click" Text="Lost" BorderColor="#FF3300" Height="28px" Width="66px" />
            </div>
        </div>
    </div>
</asp:Content>
