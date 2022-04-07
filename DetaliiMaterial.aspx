<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetaliiMaterial.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalii</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="margin-left:45%;margin-top:150px">
                <asp:Label ID="Label1" Font-Bold="true" ForeColor="Orange" Font-Size="32px" runat="server" Text="Lot Material:"></asp:Label>
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:TextBox ID="TextBox1"  Font-Size="25px" Font-Bold="true" runat="server" Width="244px" Height="38px"></asp:TextBox>
            </p>
           
            <p style="margin-left:43%;margin-top:20px">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" Font-Bold="true" ForeColor="Orange" Font-Size="32px" runat="server" Text="Eroare Material"></asp:Label>
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:TextBox ID="TextBox2" Font-Size="25px" Font-Bold="true" runat="server" Width="247px" Height="38px"></asp:TextBox>
            </p>

            <p style="margin-left:44%;margin-top:20px">
                <asp:Label ID="Label2" Font-Bold="true" ForeColor="Orange" Font-Size="32px" runat="server" Text="Stare Material:"></asp:Label>
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:TextBox ID="TextBox3" Font-Size="25px" Font-Bold="true" runat="server" Width="244px" Height="38px"></asp:TextBox>
            </p>
            <p style="margin-left:42%;margin-top:20px">
                &nbsp;&nbsp;
                <asp:Label ID="Label3" Font-Bold="true" ForeColor="Orange" Font-Size="32px" runat="server" Text="Cantitate Ambalaje:"></asp:Label>
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:TextBox ID="TextBox4" Font-Size="25px" Font-Bold="true" runat="server" Width="244px" Height="38px"></asp:TextBox>
            </p>
          
            <p style="margin-left:43%; margin-top:20px">
                <asp:Button ID="Button2" runat="server" Font-Bold="true" Font-Size="25px" Text="Editeaza Date" Height="37px" Width="267px" OnClick="OnClick2" />
            </p>
            <p style="margin-left:43%; margin-top:20px">
                <asp:Button ID="Button1" runat="server" Font-Bold="true" Font-Size="25px" Text="Adauga Material" Height="37px" Width="267px" OnClick="OnClick1" />
            </p>

            
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

    #Button2 {
    background-color: black;
    color: #ffa500;
   
   
    
    
    border-radius: 20px;
    
    transition: all 0.5s ease-in-out;
    border: none;
    
    font-weight: bold;
}

    #Button2:hover {
        background: #ffa500;
        box-shadow: 0 4px 35px -5px #000000;
        cursor: pointer;
        color: black;
        font-weight: bold;
    }

    #Button2:focus {
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
    border: 4px solid black;
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
    border: 4px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
    #TextBox3 {
    font-weight: bold;
    color:black;
    font-size: 25px;
    padding: 5px 5px;
    background: transparent;
    border-radius: 10px;
    border: 4px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
    #TextBox4 {
    font-weight: bold;
    color:black;
    font-size: 25px;
    padding: 5px 5px;
    background: transparent;
    border-radius: 10px;
     border: 4px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
    #TextBox5 {
    font-weight: bold;
    color:black;
    font-size: 25px;
    padding: 5px 5px;
    background: transparent;
    border-radius: 10px;
     border: 4px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
        </style>
</body>
</html>
