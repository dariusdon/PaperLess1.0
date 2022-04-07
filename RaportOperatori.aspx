<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RaportOperatori.aspx.cs" Inherits="RaportOperatori" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="margin-left:45%">
            <asp:Label ID="Label1" runat="server" ForeColor="Orange" Font-Bold="true" Font-Size="35px" Text="Raport Operatori"></asp:Label>
            </p>
            <p style="margin-top:50px;margin-left:100px">
                
               
                
                <asp:Label ID="Label3" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Cod Material"> </asp:Label>
                &nbsp;&nbsp;&nbsp; <asp:Label ID="Label4" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Lot Material"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label5" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Coletaj Material"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Eroare Material"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Stare Material"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Tip Material"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" Font-Bold ="true" ForeColor="Black" Font-Size="24px" runat="server" Text="Cantitate Ambalaj"></asp:Label>
                 &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Text="Adauga" Font-Size="20px" OnClick="Button4_Click" Width="115px"/>
            </p>
            <p style=" margin-left:80px; border-width:4px; width: 1572px;">
                
               
                
               
                <asp:TextBox ID="TextBoxA" Font-Size="16px" BorderColor="Orange" runat="server" Width="144px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxB" Font-Size="16px" BorderColor="Orange" runat="server" Width="135px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxC" BorderColor="Orange" Font-Size="16px" runat="server" Width="159px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxD" Font-Size="16px"  runat="server" BorderColor="Orange"   Width="150px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxE" Font-Size="16px"  runat="server" BorderColor="Orange"  Width="142px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxF" Font-Size="16px"  runat="server" BorderColor="Orange"   Width="130px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxG" Font-Size="16px"  runat="server" BorderColor="Orange"   Width="147px"></asp:TextBox>
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                
                
                <asp:Button ID="Button5" runat="server" Text="Salveaza" Font-Size="20px" OnClick="Button5_Click" Width="115px"/>
                <br/>
                <br/>
            </p>

             <p style=" margin-left:1600px; border-width:4px; margin-top:-200px;width:250px;">
                 <asp:Label ID="Label10" Font-Bold ="true" Font-Size="26px" runat="server" Text="Nume Operator:"></asp:Label>
                 <br/>
                 <asp:Label ID="Label11" Font-Bold ="true" Font-Size="26px" runat="server" Text="Data:"></asp:Label>
                 <br/>
                 <asp:Label ID="Label12" Font-Bold ="true" Font-Size="26px" runat="server" Text="Schimb:"></asp:Label>
                 <br/>
            </p>

            <p style="margin-top:100px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" Font-Size="30px" ForeColor="Orange" FontSize = "24px" runat="server" Text="Cauta dupa:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" Font-size="Large" runat="server" style="margin-top: 0px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="Button3"  Font-Size ="20px" Font-Bold="true" runat="server" Text="Filtreaza"  OnClick="search"/>
            </p>
            
           
            <asp:GridView ID="GridView1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GrdEmp_PageIndexChanging" DataKeyNames="Date" style="margin-left:100px" AllowPaging="true" PageSize="20" Width="1600px" Font-size="20px" Font-Bold="true"  runat="server" HeaderStyle-BackColor="#ffa500" HeaderStyle-ForeColor="Black">
             <PagerSettings mode="Numeric"
          position="Bottom"           
          pagebuttoncount="20" />
         <PagerStyle backcolor="#ffa500"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Right"/>
             <Columns>
                  <asp:CommandField ButtonType="Image" SelectImageUrl ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIZO7jVpy7YL0_0RHfNp0qhjRyJwB8eZIrCa0ZUvGOp01XJM-sHIuC4PwXcEBJD40SdQU&usqp=CAU" ControlStyle-Width="25" ShowSelectButton="true" HeaderText ="Editeaza" CancelText="true"/>
                  <%--<asp:CommandField ButtonType="Image" DeleteImageUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThjl7mlwlpu7GjhxWZhtQIHCVajZN9Hh1FMGXeBRu5_OQBsnTgmE5t74V03FPuN5SQQ7E&usqp=CAU" ControlStyle-Width="30" ShowDeleteButton="true" HeaderText ="Delete"/>--%>
                  

                  </Columns>
            
            </asp:GridView>
          
            <p style="margin-left:40%;margin-top:10px">
                &nbsp;&nbsp;
                <asp:Button ID ="Button0" Font-Size ="24px" Font-Bold="true" runat="server" Text="Printare" OnClick="Button0_Click"/> 
                &nbsp;&nbsp; 
                <asp:Button ID="Button1" Font-Size ="24px" Font-Bold="true" runat="server" Text="Inchidere Schimb" OnClick="Button1_Click"/>
                &nbsp;&nbsp;
                <asp:Button ID="Button2" Font-Size ="24px" Font-Bold="true" runat="server" Text="Delogare" OnClick="Button2_Click"/>
            </p>
            <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
        </div>
    </form>
    <script type="text/javascript">
        function PrintGrid(html, css) {
            var printWin = window.open('', '', 'left=0,top=0,width=400,height=300,scrollbars=1');
            printWin.document.write('<style type = "text/css">' + css + '</style>');
            printWin.document.write(html);
            printWin.document.close();
            printWin.focus();
            printWin.print();
            printWin.close();
        };
    </script>
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

    #Button2:focus {
        outline: none;
        color: black;
    }

    
        #Button3 {
    background-color: black;
    color: #ffa500;
    
    
    border-radius: 20px;
    
    transition: all 0.5s ease-in-out;
    border: none;
    
    font-weight: bold;
}

    #Button3:hover {
        background: #ffa500;
        box-shadow: 0 4px 35px -5px #000000;
        cursor: pointer;
        color: black;
        font-weight: bold;
    }

    #Button3:focus {
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
      #TextBoxA {
    font-weight: bold;
    color:black;
    
    background: transparent;
    
    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
       #TextBoxB {
    font-weight: bold;
    color:black;
    
    background: transparent;
    
    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
        #TextBoxC {
    font-weight: bold;
    color:black;
    
    background: transparent;
   
    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
         #TextBoxD {
    font-weight: bold;
    color:black;
  
    background: transparent;

    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
          #TextBoxE {
    font-weight: bold;
    color:black;
    
    background: transparent;

    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
           #TextBoxF {
    font-weight: bold;
    color:black;
    
    background: transparent;

    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}
            #TextBoxG {
    font-weight: bold;
    color:black;
    background: transparent;
    
    border: 3px solid black;
    overflow: hidden;
    
    transition: all 0.6s ease-in-out;
}

        #Button0 {
    background-color: black;
    color: #ffa500;
   
   
    
    
    border-radius: 20px;
    
    transition: all 0.5s ease-in-out;
    border: none;
    
    font-weight: bold;
}

    #Button0:hover {
        background: #ffa500;
        box-shadow: 0 4px 35px -5px #000000;
        cursor: pointer;
        color: black;
        font-weight: bold;
    }

    #Button0:focus {
        outline: none;
        color: black;
    }

    #Button4 {
    background-color: black;
    color: #ffa500;
   
   
    
    
    border-radius: 20px;
    
    transition: all 0.5s ease-in-out;
    border: none;
    
    font-weight: bold;
}

    #Button4:hover {
        background: #ffa500;
        box-shadow: 0 4px 35px -5px #000000;
        cursor: pointer;
        color: black;
        font-weight: bold;
    }

    #Button4:focus {
        outline: none;
        color: black;
    }

     #Button5 {
    background-color: black;
    color: #ffa500;
   
   
    
    
    border-radius: 20px;
    
    transition: all 0.5s ease-in-out;
    border: none;
    
    font-weight: bold;
}

    #Button5:hover {
        background: #ffa500;
        box-shadow: 0 4px 35px -5px #000000;
        cursor: pointer;
        color: black;
        font-weight: bold;
    }

    #Button5:focus {
        outline: none;
        color: black;
    }
        </style>
</body>
</html>
