<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="margin-left:47%">
            <asp:Label ID="Label1" ForeColor="Orange" Font-Size="30px" Font-Bold="true" runat="server" Text="Interfata Admini"></asp:Label>
            </p>
            <p style="margin-top:20px;margin-left:100px">
                <asp:Label ID="Label2" ForeColor="Orange" Font-Size="20px" runat="server" Text="Raport PO"></asp:Label>
                <br/>
                <asp:Label ID="Label3" ForeColor="Orange" Font-Size="20px" runat="server" Text="De la Data Si Ora:"></asp:Label>
               &nbsp;&nbsp;
               <asp:TextBox ID="TextBox1" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox3" TextMode="Time"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label4" ForeColor="Orange" Font-Size="20px" runat="server" Text="Pana la Data Si Ora:"></asp:Label>
                 &nbsp;&nbsp;
               <asp:TextBox ID="TextBox2" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                  &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox4" TextMode="Time" Width="150px"  runat="server"></asp:TextBox>
                  &nbsp;&nbsp;
                <asp:Label ID="Label14" ForeColor="Orange" Font-Size="20px" runat="server" Text="Pana la Data Si Ora:"></asp:Label>
                <asp:Button ID="Button1" Font-Bold="true" Font-Size="20px" runat="server" Text="Genereaza Raport" Onclick="OnClick"/>
             </p>
            
            <br/>
            <p style="margin-top:20px;margin-left:100px">
                <asp:Label ID="Label6" ForeColor="Orange" Font-Size="20px" runat="server" Text="Raport Mixing"></asp:Label>
                <br/>
                <asp:Label ID="Label7" ForeColor="Orange" Font-Size="20px" runat="server" Text="De la Data Si Ora:"></asp:Label>
               &nbsp;&nbsp;
               <asp:TextBox ID="TextBox5" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox6" TextMode="Time"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label8" ForeColor="Orange" Font-Size="20px" runat="server" Text="Pana la Data Si Ora:"></asp:Label>
                 &nbsp;&nbsp;
               <asp:TextBox ID="TextBox7" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                  &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox8" TextMode="Time" Width="150px"  runat="server"></asp:TextBox>
                  &nbsp;&nbsp;
                <asp:Button ID="Button2" Font-Bold="true" Font-Size="20px" runat="server" Text="Genereaza Raport" OnClick="OnClick1"/>
             </p>
            <br/>
            <p style="margin-top:20px;margin-left:100px">
                <asp:Label ID="Label5" ForeColor="Orange" Font-Size="20px" runat="server" Text="Raport Comparare Mixing/PO"></asp:Label>
                <br/>
                <asp:Label ID="Label9" ForeColor="Orange" Font-Size="20px" runat="server" Text="De la Data Si Ora:"></asp:Label>
               &nbsp;&nbsp;
               <asp:TextBox ID="TextBox9" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox10" TextMode="Time"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label10" ForeColor="Orange" Font-Size="20px" runat="server" Text="Pana la Data Si Ora:"></asp:Label>
                 &nbsp;&nbsp;
               <asp:TextBox ID="TextBox11" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                  &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox12" TextMode="Time" Width="150px"  runat="server"></asp:TextBox>
                  &nbsp; &nbsp;<asp:Button ID="Button3" Font-Bold="true" Font-Size="20px" runat="server" Text="Genereaza Raport" />
             </p>
              <br/>
            <p style="margin-top:20px;margin-left:100px">
                <asp:Label ID="Label11" ForeColor="Orange" Font-Size="20px" runat="server" Text="Generare KPI"></asp:Label>
                <br/>
                <asp:Label ID="Label12" ForeColor="Orange" Font-Size="20px" runat="server" Text="De la Data Si Ora:"></asp:Label>
               &nbsp;&nbsp;
               <asp:TextBox ID="TextBox13" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox14" TextMode="Time"  Width="150px"  runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label13" ForeColor="Orange" Font-Size="20px" runat="server" Text="Pana la Data Si Ora:"></asp:Label>
                 &nbsp;&nbsp;
               <asp:TextBox ID="TextBox15" TextMode="Date"  Width="150px"  runat="server"></asp:TextBox>
                  &nbsp;&nbsp;
                 <asp:TextBox ID="TextBox16" TextMode="Time" Width="150px"  runat="server"></asp:TextBox>
                  &nbsp; &nbsp;<asp:Button ID="Button4" Font-Bold="true" Font-Size="20px" runat="server" Text="Genereaza Raport" />
             </p>
                </div>
    </form>
  
         <style type="text/css">
             #TextBox1 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }
             #TextBox2 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }

             #TextBox3 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }
                     #TextBox4 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }
                      #TextBox5 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }
             #TextBox6 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }

             #TextBox7 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }
                     #TextBox8 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }
                      #TextBox9 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }
             #TextBox10 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }

             #TextBox11 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }
                     #TextBox12 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }

                     #TextBox13 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
                    }
                      #TextBox14 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }
             #TextBox15 {
                 background: #ffa500;
             border-color: black;
             border-radius: 10px;
             border: 2px solid;
             font-size: 16px;
             font-weight: bold;
            }

             #TextBox16 {
                         background: #ffa500;
                     border-color: black;
                     border-radius: 10px;
                     border: 2px solid;
                     font-size: 16px;
                     font-weight: bold;
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
              </style> 
</body>
</html>
