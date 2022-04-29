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
using Aspose.Pdf.Operators;

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
                SELECT
               *FROM[BD_Timisoara].[dbo].[RawMaterialFinal]
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
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";

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
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox5.Text = "";
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
                string sql = @"select c1.Schimb,c1.CodMaterial,SUM(c1.ColetajMaterial) as NumarPaletiPO,SUM(c2.ColetajMaterial) as NumarPaletiMixing,
                            (SUM(c1.ColetajMaterial) - SUM(c2.ColetajMaterial)) as DiferentaPoMixing,
                            (SUM(c2.ColetajMaterial) - SUM(c1.ColetajMaterial)) as DiferentaMixingPO
                            from RawMaterialFinal c1
                            inner Join RawMaterialMixing c2 on c1.CodMaterial = c2.CodMaterial 
                            Where c1.Date > '" + data1 + "' and c2.Date<'" + data2 + "' Group By c1.Schimb,c1.CodMaterial";

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
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
    }

    protected void OnClick3(object sender, EventArgs e)
    {
        int eroare = 0;
        int fara = 0;
        string data1 = TextBox13.Text + " " + TextBox14.Text;
        string data2 = TextBox15.Text + " " + TextBox16.Text;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable final = new DataTable();

        Random rand = new Random();
        int x = rand.Next(1000, 10000000);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql =  @"Select Count(CodMaterial) as FaraEroare from dbo.RawMaterialFinal Where Date > '" + data1 + "' And Date<'" + data2 + "' ";




                //aici trebuie facut un inner join
                cmd.CommandText = sql;

                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                   fara = Convert.ToInt32(dt.Rows[0]["FaraEroare"]);
                }
            }
        }
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"Select Count(CodMaterial) as Eroare from dbo.RawMaterialFinal  Where Date > '" + data1 + "' And Date<'" + data2 + "' AND (EroareMaterial = 'FEFO' or EroareMaterial = 'Lipsa Stoc' or EroareMaterial = 'Lipsa Batch') ";




                //aici trebuie facut un inner join
                cmd.CommandText = sql;

                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt1);
                    eroare = Convert.ToInt32(dt1.Rows[0]["Eroare"]);
                }
            }
        }

        double kpi;
        kpi = Convert.ToDouble(eroare) / Convert.ToDouble(fara) * 100;
        string kpiprocent = "KPI:" + Convert.ToString(kpi) + '%';
        final.Columns.Add("Numar Erori:" + eroare.ToString());
        final.Columns.Add("Numar Transferuri:" + fara.ToString());
        final.Columns.Add(kpiprocent);
        
       
        

        ToCSV(final, Server.MapPath("~/File/" + "KPI" + x.ToString() + ".csv"));
        if (File.Exists(Server.MapPath("~/File/" + "KPI" + x.ToString() + ".csv")))
        {
            Response.ContentType = "application/csv";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "KPI" + x.ToString() + ".csv");
            Response.TransmitFile(Server.MapPath("~/File/" + "KPI" + x.ToString() + ".csv"));
            Response.End();
        }
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox16.Text = "";
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