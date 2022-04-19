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

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void OnClick(object sender, EventArgs e)
    {

        string data1 = TextBox1.Text + " " + TextBox3.Text;
        string data2 = TextBox2.Text + " " + TextBox4.Text;
        Random rand = new Random();
        int x = rand.Next(1000, 10000000);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"
                SELECT TOP(1000) [CodMaterial]
               ,[LotMaterial]
               ,[ColetajMaterial]
               ,[EroareMaterial]
               ,[StareMaterial]
               ,[TipMaterial]
               ,[CantitateMaterial]
               ,[Schimb]
               ,[Operator]
               ,[Date]
               FROM[BD_Timisoara].[dbo].[RawMaterial]
            Where Date > '" + data1 + "' and Date<'" + data2 + "' order by Date desc";


                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ToCSV(dt, Server.MapPath("~/File/" +"RawMaterial" + x.ToString() + ".csv"));
                    if (File.Exists(Server.MapPath("~/File/" + "RawMaterial"+ x.ToString() + ".csv")))
                    {
                        Response.ContentType = "application/csv";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "RawMaterial" + x.ToString() + ".csv");
                        Response.TransmitFile(Server.MapPath("~/File/" + "RawMaterial" + x.ToString() + ".csv"));
                        Response.End();
                    }
                }

            }

        }
    }
    protected void OnClick1(object sender,EventArgs e)
    {
        string data1 = TextBox5.Text + " " + TextBox6.Text;
        string data2 = TextBox7.Text + " " + TextBox8.Text;
        
        Random rand = new Random();
        int x = rand.Next(1000, 10000000);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"
                SELECT *FROM[BD_Timisoara].[dbo].[RawMaterialMixing]
            Where Date > '" + data1 + "' and Date<'" + data2 + "' order by Date desc";


                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ToCSV(dt, Server.MapPath("~/File/" + "Mixing" + x.ToString() + ".csv"));
                    if (File.Exists(Server.MapPath("~/File/" + "Mixing" + x.ToString()+ ".csv")))
                    {
                        Response.ContentType = "application/csv";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Mixing" + x.ToString() + ".csv");
                        Response.TransmitFile(Server.MapPath("~/File/" + "Mixing" + x.ToString() + ".csv"));
                        Response.End();
                    }
                }

            }

        }
    }
    protected void OnClick2(object sender,EventArgs e)
    {

        string data1 = TextBox9.Text + " " + TextBox10.Text;
        string data2 = TextBox11.Text + " " + TextBox12.Text;
        DataTable dt = new DataTable();

        Random rand = new Random();
        int x = rand.Next(1000, 10000000);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"SELECT SUM ([ColetajMaterial]) NumarPaletiMixing, [CodMaterial] FROM [BD_Timisoara].[dbo].[RawMaterialMixing]
                              where date > '" + data1 + "'   GROUP BY [CodMaterial]";



                //aici trebe facut un inner join, pentru a completa tabelul si a face comparatia intre tabele :)
                //pentru asta e nevoie de acelasi format al datei
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
            string sql = @"WITH RawMaterialMF AS
            (
            SELECT CodMaterial, [ColetajMaterial], Date
            FROM [BD_Timisoara].[dbo].[RawMaterialMixing]



            UNION ALL



            SELECT CodMaterial, [ColetajMaterial], Date
            FROM [BD_Timisoara].[dbo].[RawMaterialFinal]
            )



            SELECT CodMaterial, SUM(ColetajMaterial) AS TransferPO
            FROM RawMaterialMF
            WHERE Date Between '"+ data1 + "' AND '" + data2 + "' GROUP BY CodMaterial";




                //aici trebuie facut un inner join
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }
        ToCSV(dt, Server.MapPath("~/File/" + "Comparare" + x.ToString() + ".csv"));
                    if (File.Exists(Server.MapPath("~/File/" + "Comparare" + x.ToString() + ".csv")))
                    {
                        Response.ContentType = "application/csv";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Comparare" + x.ToString() + ".csv");
                        Response.TransmitFile(Server.MapPath("~/File/" + "Comparare" + x.ToString() + ".csv"));
                        Response.End();
                    }
    }

            
    protected void ToCSV(DataTable dtDataTable, string strFilePath)
    {
        StreamWriter sw = new StreamWriter(strFilePath, false);
        //headers    
        for (int i = 0; i < dtDataTable.Columns.Count; i++)
        {
            sw.Write(dtDataTable.Columns[i]);
            if (i < dtDataTable.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        foreach (DataRow dr in dtDataTable.Rows)
        {
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    string value = dr[i].ToString();
                    if (value.Contains(','))
                    {
                        value = String.Format("\"{0}\"", value);
                        sw.Write(value);
                    }
                    else
                    {
                        sw.Write(dr[i].ToString());
                    }
                }
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
    }
}