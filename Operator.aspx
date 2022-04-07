<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Operator.aspx.cs" Inherits="Operator"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OperatorPO</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" ForeColor="Orange" Font-Bold="true" Font-Size="30px" Text="1"></asp:Label>
            <br/>
            <asp:Label ID="Label2" runat="server" ForeColor="Orange" Font-Bold="true" Font-Size="30px" Text="2"></asp:Label>
            <br/>
            <asp:Label ID="Label3" Font-Bold="true" ForeColor="Orange" runat="server" Font-Size="30px" Text="3"></asp:Label>
            <br/>
            <p style="margin-left:43%;margin-top:200px">
                <asp:Label ID="Label4" Font-Bold="true" ForeColor="Orange" Font-Size="32px" runat="server" Text="Scaneaza Material"></asp:Label>
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:TextBox ID="TextBox1" Font-Size="25px" Font-Bold="true" runat="server" Width="244px" Height="38px"></asp:TextBox>
            </p>
           
            <p style="margin-left:42%;margin-top:20px">
                <asp:Label ID="Label5" Font-Bold="true" ForeColor="Orange" Font-Size="32px" runat="server" Text="Introduceti cantitate"></asp:Label>
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:TextBox ID="TextBox2" Font-Size="25px" Font-Bold="true" runat="server" Width="244px" Height="38px"></asp:TextBox>
            </p>
             <p style="margin-left:43%; margin-top:20px">
                <asp:Button ID="Button1" runat="server" Font-Bold="true" Font-Size="25px" Text="Adauga Material" Height="37px" Width="267px" OnClick="Button1_Click" />
            </p>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
     <style type="text/css">
         #Button1 {
    background-color: black;
    color: #ffa500;
    border-radius: 20px; 
    transition: all 0.5s ease-in-out;
    border: none;
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
