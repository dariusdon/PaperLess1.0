using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox3.Text = "OK";
        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        
    }
    protected void OnClick1(object sender, EventArgs e)
    {
        Session["LotMaterial"] = TextBox1.Text;
        //Session["ColetajMaterial"] = Session["All"];
        Session["EroareMaterial"] = TextBox2.Text;
        Session["StareMaterial"] = TextBox3.Text;
        Session["Ambalaj"] = TextBox4.Text;
       // Session["Ambalaj"] = TextBox5.Text;
       // TextBox5.Text = (string)Session["TipMaterial"];
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"
                    INSERT INTO[dbo].[RawMaterial]
                        ([Cod Material]
                      ,[Lot Material]
                      ,[Coletaj Material]
                      ,[Eroare Material]
                      ,[Stare Material]
                      ,[Tip Material]
                      ,[Cantitate Material]
                      ,[Date]
                      ,[Schimb]
                      ,[Operator])
                    VALUES
                      (
                       '" + Session["CodMaterial"] + @"'
                       , '" + Session["LotMaterial"] + @"'
                       , '" + Session["Cantitate"] + @"'
                       , '" + Session["EroareMaterial"] + @"'
                       , '" + Session["StareMaterial"] + @"'
                       , '" + Session["TipAmbalaj"] + @"'
                       , '" + Session["Ambalaj"] + @"'
                       , '" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + @"'
                       , '" + Session["schimb"] + @"'
                       , '" + Session["name"] + @"'
                               )";
                //coletaj material, il am
                //lot
                //eroare
                //stare
                //cantitate
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                }
            }
        }
        Response.Redirect("RaportOperatori.aspx");
    }
    protected void OnClick2(object sender,EventArgs e)
    {
        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        TextBox3.Enabled = true;
        TextBox4.Enabled = true;
    }
}
