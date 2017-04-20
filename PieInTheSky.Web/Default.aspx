<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PieInTheSky.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h1>Pie In The Sky Pizza</h1>
        <p id="topLead" class="lead">Pizza to watch movies by...</p>
        <div class="form-group">
            <label>Size:<asp:DropDownList ID="sizeDropDownList" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="recalculateCost">
                    <asp:ListItem Text="Please select..." Value="" Selected="True" />
                    <asp:ListItem Text="" />
                    <asp:ListItem Text="Small (12 in - $12)" Value="Small" />
                    <asp:ListItem Text="Medium (14 in - $14)" Value="Medium" />
                    <asp:ListItem Text="Large (16 in - $16)" Value="Large" />
                   </asp:DropDownList>
            </label>
        </div>
        <div class="form-group">
            <label>Crust:<asp:DropDownList ID="crustDropDownList" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="recalculateCost">
                    <asp:ListItem Text="Please select..." Value="" Selected="True" />
                    <asp:ListItem Text="" />
                    <asp:ListItem Text="Thin" Value="Thin" />
                    <asp:ListItem Text="Regular" Value="Regular" />
                    <asp:ListItem Text="Thick (+ $2)" Value="Thick" />
                   </asp:DropDownList>
            </label>
        </div>
        <div class="checkbox"><label><asp:CheckBox ID="sausageCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="recalculateCost" /> Sausage (+ $2)</label></div>
        <div class="checkbox"><label><asp:CheckBox ID="pepperoniCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="recalculateCost" /> Pepperoni (+$1.50)</label></div>
        <div class="checkbox"><label><asp:CheckBox ID="onionsCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="recalculateCost" /> Onions (+ $1)</label></div>
        <div class="checkbox"><label><asp:CheckBox ID="greenpeppersCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="recalculateCost" /> Green Peppers (+$1)</label></div>
        <h2>Deliver To:</h2>
        <div class="form-group">
            <label>Name: <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" placeholder="Name" /></label>
        </div>
        <div class="form-group">
            <label>Address: <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"  placeholder="Address" /></label>
        </div>
        <div class="form-group">
            <label>Zip Code: <asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control" placeholder="Zip Code" /></label>
        </div>
        <div class="form-group">
            <label>Phone: <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control" placeholder="Phone" /></label>
        </div>
        <h2>Payment:</h2>
        <div class="radio"><label><asp:RadioButton ID="cashRadioButton" runat="server" GroupName="paymentType" Checked="true" /> Cash</label></div>   
        <div class="radio"><label><asp:RadioButton ID="creditRadioButton" runat="server" GroupName="paymentType" /> Credit</label></div>

        <asp:Button ID="orderButton" runat="server" Text="Order" CssClass="btn btn-primary btn-lg" OnClick="orderButton_Click" /><br /><br />
        <asp:Label ID="resultLabel" runat="server" CssClass="lead" /><br /><br />
        <asp:Label ID="errorMessageLabel" runat="server" CssClass="bg-warning" Visible="false" />
    </div>
    </form>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/webLayer.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>