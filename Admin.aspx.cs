﻿using System;
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

        string[] date = TextBox1.Text.Split('-');
        TextBox1.Text = date[2] + "/" + date[1] + "/" + date[0];
        string min = TextBox1.Text + " " + TextBox3.Text;
        string[] date1 = TextBox2.Text.Split('-');
        TextBox2.Text = date1[2] + "/" + date1[1] + "/" + date1[0];
        string max = TextBox2.Text + " " + TextBox4.Text;
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
            Where Date > '" + min + "' and Date<'" + max + "' order by Date desc";


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
        string[] date = TextBox5.Text.Split('-');
        TextBox5.Text = date[2] + "/" + date[1] + "/" + date[0];
        string min = TextBox5.Text + " " + TextBox6.Text;
        string[] date1 = TextBox7.Text.Split('-');
        TextBox7.Text = date1[2] + "/" + date1[1] + "/" + date1[0];
        string max = TextBox7.Text + " " + TextBox8.Text;
        Random rand = new Random();
        int x = rand.Next(1000, 10000000);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"
                SELECT *FROM[BD_Timisoara].[dbo].[RawMaterialMixingTemp]
            Where Date > '" + min + "' and Date<'" + max + "' order by Date desc";


                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ToCSV(dt, Server.MapPath("~/File/" + "Mixing:" + x.ToString() + ".csv"));
                    if (File.Exists(Server.MapPath("~/File/" + "Mixing:" + x.ToString()+ ".csv")))
                    {
                        Response.ContentType = "application/csv";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Mixing:" + x.ToString() + ".csv");
                        Response.TransmitFile(Server.MapPath("~/File/" + "Mixing:" + x.ToString() + ".csv"));
                        Response.End();
                    }
                }

            }

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