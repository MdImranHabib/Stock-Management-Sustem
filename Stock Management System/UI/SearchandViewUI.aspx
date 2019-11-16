<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchandViewUI.aspx.cs" Inherits="Stock_Management_System.UI.SearchandViewUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="alert bg-primary text-center">Search and View Items Summary</h2>
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
                        <label class="col-md-4 control-label">Category :</label>
                        <asp:DropDownList runat="server" ID="ddlCategory" DataTextField="Name" DataValueField="Id" class="col-md-6 form-control" AutoPostBack="true"/>
                    </div> 
                    <div class="col-md-offset-4">
                        <asp:Button ID="btnSearch" runat="server" BackColor="#009933" ForeColor="White" OnClick="btnSearch_Click" Text="Search" BorderColor="#33CC33" Height="28px" Width="66px" />
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <asp:GridView ID="gridSearchandViewItems" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="Medium" ForeColor="#333333" GridLines="None" Height="161px" HorizontalAlign="Center" Width="750px" style="margin-left: 0px">
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
                     <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <%#Eval("Category") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Available Quantity">
                        <ItemTemplate>
                            <%#Eval("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reorder Level">
                        <ItemTemplate>
                            <%#Eval("ReorderLevel") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
