<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoginPage</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:30px">
            <p style="margin-left:46%">
            <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Orange" Font-Size="35px" Text="PaperPass2.0"></asp:Label>
            </p>
            <p style="margin-left:46%;margin-top: 10%">
            <asp:Label ID="Label2" Font-Bold="true" ForeColor ="Orange" Font-Size="30px" runat="server" Text="Nume utilizator:"></asp:Label>
            </p>
            <p style="margin-left:45%">
                <asp:TextBox ID="TextBox1" Font-Size="Large" runat="server" Height="30px" Width="233px"></asp:TextBox>
            </p>
            <p style="margin-left:49%">
            <asp:Label ID="Label3" Font-Size="30px" Font-Bold="true" ForeColor ="Orange" runat="server" Text="Parola:"></asp:Label>
            </p>
            <p style="margin-left:45%">
                <asp:TextBox ID="TextBox2" TextMode="Password"  Height="30px" Width="233px"  runat="server"></asp:TextBox>
            </p>
            <p style="margin-left:46%;margin-top:10px">
                <asp:Button ID="Button1" runat="server" Font-Size="25px" Text="Login" Width="215px" Height="46px" OnClick="OnClick" />
            </p>
            <p style="margin-left:41%">
                <asp:Image ID="Image1" BorderColor="White" ImageUrl="https://thumbs.dreamstime.com/b/forklift-icon-white-background-48714652.jpg" runat="server" Height="269px" Width="376px" />
            </p>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
    <style type="text/css">
         #Button1 {
    background-color: black;
    color: #ffa500;
    border-radius: 20px;
    transition: all 0.5s ease-in-out;
    border: none;
    text-transform: uppercase;
    font-weight: bold;
}

    #Button1:hover {
        background: #ffa500;
        box-shadow: 0 4px 35px -5px #000000;
        cursor: pointer;
        color: black;
        font-weight: bold;
    }

    #Button1:focus {
        outline: none;
        color: black;
    }
    #TextBox1 {
    font-weight: bold;
    color:black;
    font-size: 25px;
    padding: 5px 5px;
    background: transparent;
    border-radius: 10px;
    border: 4px solid #ffa500;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
    #TextBox2 {
    font-weight: bold;
    color:black;
    font-size: 25px;
    padding: 5px 5px;
    background: transparent;
    border-radius: 10px;
    border: 4px solid #ffa500;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
        </style>
</body>
</html>
