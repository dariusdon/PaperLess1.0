<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vama.aspx.cs" Inherits="Vama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vama</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <p style="margin-left:47%">
            <asp:Label ID="Label1" Font-Size="30px" runat="server" Text="Interfata Vama"></asp:Label>
            </p>
             <br/>
             <p style="margin-left:100px">
             <asp:Label ID="Label4" Font-Size="30px" runat="server" Text="Alege Fisierul:"></asp:Label>
             &nbsp;&nbsp;
             <asp:FileUpload ID="FileUpload2"  runat="server" />
             &nbsp;&nbsp;
             <asp:Label ID="Label5" Font-Size="30px" runat="server" Text="Genereaza CSV:"></asp:Label>
             &nbsp;&nbsp;
             <asp:Button ID="Button2" runat="server" Font-Size="20px" Text="Descarca CSV" Height="27px" Width="174px"  OnClick="OnClick"/>
             </p>
             <asp:GridView ID="GridView1" style="margin-left:100px" Width="1600px" Font-size="20px" Font-Bold="true"  runat="server" HeaderStyle-BackColor="#ffa500" HeaderStyle-ForeColor="Black"/>
        </div>
    </form>
     <style type="text/css">
         #FileUpload1 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }
           #FileUpload2 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }
   
   
    
    
    
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
     </style>
</body>
</html>
