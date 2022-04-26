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

public partial class RaportOperatori : System.Web.UI.Page
{

    TimeSpan Shift1 = TimeSpan.FromHours(7);
    TimeSpan Shift3 = TimeSpan.FromHours(23);
    TimeSpan alternative = TimeSpan.FromHours(0);
    TimeSpan current = DateTime.Now.TimeOfDay;
    string date1 = DateTime.Now.Year.ToString("yyyy") + "-" + DateTime.Now.Month.ToString("MM") + "-" + DateTime.Now.Day.ToString("dd") + "23:00:00";
    string date2 = DateTime.Now.Year.ToString("yyyy") + "-" + DateTime.Now.Month.ToString("MM") + "-" + DateTime.Now.Day.ToString("dd") + "23:59:00";
    string date3 = DateTime.Now.Year.ToString("yyyy") + "-" + DateTime.Now.Month.ToString("MM") + "-" + DateTime.Now.Day.ToString("dd") + "07:00:00";
    string date4 = DateTime.Now.Year.ToString("yyyy") + "-" + DateTime.Now.Month.ToString("MM") + "-" + DateTime.Now.AddDays(1).ToString("dd") + "23:00:00";
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        GridView1.ShowHeader = true;
        getSchimb();
        if ((string)Session["shift"] == "O")
        {
            Session["schimb"] = "Orange";
        }
        else if ((string)Session["shift"] == "Y")
        {
            Session["schimb"] = "Yellow";
        }
        else if ((string)Session["shift"] == "G")
        {
            Session["schimb"] = "Green";
        }
        else if ((string)Session["shift"] == "B")
        {
            Session["schimb"] = "Blue";
        }
        Label10.Text = "Operator:" + (string)Session["name"];
        Label11.Text = "Data:" + DateTime.Now.ToString("yyyy-MM-dd");
        Label12.Text = "Schimb:" + (string)Session["schimb"];

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @" Select * from dbo.RawMaterial where  Operator = '" + Session["name"] + "' and Date like '%" + DateTime.Now.ToString("dd/MM/yyyy") + "%' order by Date desc";

                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void getSchimb()
    {

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd1 = new SqlCommand())
            {
                string sql1 = @"SELECT [ShiftDate]
                      ,[ShiftID]
                      ,[ShiftColor]
                      FROM[tias067a].[NewERT].[dbo].[ShiftCalendar]
                      where convert(varchar, ShiftDate,23) = convert(varchar, getdate(), 23)
                      and ShiftID = (case when convert(varchar, getdate(),24) between '07:00:00' and '15:00:00' then '1'
                      when convert(varchar, getdate(),24) between '15:00:00' and '23:00:00' then '2'
                      when convert(varchar, getdate(),24) between '23:00:00' and '23:59:59' then '3'
                      when convert(varchar, getdate(),24) between '00:00:00' and '07:00:00' then '3' end)";
                cmd1.CommandText = sql1;
                cmd1.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Session["shift"] = Convert.ToString(dt.Rows[0]["ShiftColor"]);
                }
            }
        }
    }
    protected void Details()
    {
        TextBoxA.Text = "";
        TextBoxB.Text = "";
        TextBoxC.Text = "";
        TextBoxD.Text = "";
        TextBoxE.Text = "";
        TextBoxF.Text = "";
        TextBoxG.Text = "";

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @" Select * from dbo.RawMaterial where  Operator = '" + Session["name"] + "' order by Date desc";

                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void GrdEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();

    }
    public static void ToCSV(DataTable dtDataTable, string strFilePath)
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

    public void clear(object sender, EventArgs e)
    {
        Details();
    }
    public void search(object sender, EventArgs e)
    {
        string str = TextBox1.Text;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"Select * from dbo.RawMaterial where  Operator = '" + Session["name"] + "' and (CodMaterial like '%" + str + "%' or LotMaterial like '%" + str + "%' or EroareMaterial like '%" + str + "%') order by Date desc";
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void Button0_Click(object sender, EventArgs e)
    {
        Label label = new Label();
        label.Font.Size = 20;
        label.Text = "Semantura Mixing:";
        Label label2 = new Label();
        label2.Text = "Semnatura Depozit:";
        GridView1.Columns[0].Visible = false;
        GridView1.PagerSettings.Visible = false;
        GridView1.AllowPaging = false;
        GridView1.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=300,width=1730,height=900,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<p style= font-size:20px; margin-left:100px> Semnatura Depozit:<p/>");
        sb.Append("\");");
        sb.Append("printWin.document.write(\"");
        sb.Append("<p style= font-size:20px; margin-left:100px; margin-top:-20px> Semnatura Mixing:<p/>");
        sb.Append("\");");
        sb.Append("printWin.document.write(\"");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        // sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        GridView1.AllowPaging = true;
        GridView1.DataBind();
        Details();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"Select * from dbo.RawMaterial where Operator = '" + Session["name"] + "' order by Date desc";
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    string date = DateTime.Now.Date.ToString();

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.AllowPaging = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    ToCSV(dt, Server.MapPath("~/File/" + DateTime.Now.Date.ToString("dd MM yyyy") + " " + "Schimb " + Session["schimb"] + ".csv"));
                }
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    string sql1 = "Delete from dbo.RawMaterial where 1 = 1";
                    cmd.CommandText = sql1;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd))
                    {
                        DataTable dt1 = new DataTable();
                        sda.Fill(dt1);
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        Details();
                    }
                }
                if (File.Exists(Server.MapPath("~/File/" + DateTime.Now.Date.ToString("dd MM yyyy") + " " + "Schimb " + Session["schimb"] + ".csv")))
                {
                    Send_Email("razvan.sodoleanu@conti.de", Server.MapPath("~/File/" + DateTime.Now.Date.ToString("dd MM yyyy") + " " + "Schimb " + Session["schimb"] + ".csv"));
                    Response.ContentType = "application/csv";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.Date.ToString("dd MM yyyy") + " " + "Schimb " + Session["schimb"] + ".csv");
                    Response.TransmitFile(Server.MapPath("~/File/" + DateTime.Now.Date.ToString("dd MM yyyy") + " " + "Schimb " + Session["schimb"] + ".csv"));
                    Response.End();
                }
            }

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    public void Send_Email(string approval, string file)
    {

        try
        {
            //Send Email
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("TI_TI_SM_CHANGE_TI@continental.com");// Sender details here, replace with valid value



            Msg.Subject = "Raport Transfer:" + DateTime.Now.ToString("dd/MM/yyyy") + " " + "Schimb:" + Session["schimb"]; // subject of email
                                                                                                                          //Msg.To.Add("natalia.nicoleta.dragoescu@conti.de"); //Add Email id, to which we will send email
            Msg.To.Add(approval);
            Msg.Attachments.Add(new Attachment(file));


            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Va informam ca a fost trimis raportul de transfer:" + DateTime.Now.ToString("dd/MM/yyyy"));
            sb.AppendLine(" Schimbul " + Session["schimb"]);
            sb.AppendLine(" Operator: " + Session["name"]);
            sb.AppendLine("Cel mai bun tool dezvoltat vreodata in Continental: Developer: Darius Don");
            sb.AppendLine("Cu drag pentru cei mai smecheri colegi!");
            //Label2.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            Msg.Body = sb.ToString().Replace(Environment.NewLine, "<br />");



            Msg.IsBodyHtml = true;
            Msg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
            smtp.Host = "smtphubeu.contiwan.com";
            smtp.Port = 2525;
            smtp.Credentials = new System.Net.NetworkCredential("", "");// replace with valid value
            smtp.EnableSsl = true;
            smtp.Timeout = 70000;
            smtp.Send(Msg);
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string string1;
        string string2;
        string string3;
        string string4;
        string string5;
        string string6;
        string string7;
        string[] alt = TextBoxC.Text.Split('x');
        int value = Convert.ToInt32(alt[0]);
        string1 = TextBoxA.Text;
        string2 = TextBoxB.Text;
        string3 = TextBoxC.Text;
        string4 = TextBoxD.Text;
        string5 = TextBoxE.Text;
        string6 = TextBoxF.Text;
        string7 = TextBoxG.Text;
        string alternative = string1.Replace(" ", String.Empty);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"
                    INSERT INTO[dbo].[RawMaterial]
                        ([CodMaterial]
                      ,[LotMaterial]
                      ,[ColetajMaterial]
                      ,[EroareMaterial]
                      ,[StareMaterial]
                      ,[TipMaterial]
                      ,[CantitateMaterial]
                      ,[Date]
                      ,[Schimb]
                      ,[Operator])
                    VALUES
                      (
                       '" + alternative + @"'
                       , '" + string2 + @"'
                       , '" + string3 + @"'
                       , '" + string4 + @"'
                       , '" + string5 + @"'
                       , '" + string6 + @"'
                       , '" + string7 + @"'
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
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"
                    INSERT INTO[dbo].[RawMaterialFinal]
                        ([CodMaterial]
                      ,[LotMaterial]
                      ,[ColetajMaterial]
                      ,[EroareMaterial]
                      ,[StareMaterial]
                      ,[TipMaterial]
                      ,[CantitateMaterial]
                      ,[Date]
                      ,[Schimb]
                      ,[Operator])
                    VALUES
                      (
                       '" + alternative + @"'
                       , '" + string2 + @"'
                       , '" + value + @"'
                       , '" + string4 + @"'
                       , '" + string5 + @"'
                       , '" + string6 + @"'
                       , '" + string7 + @"'
                       , getdate()
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
        Details();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowIndex == GridView1.SelectedIndex)
            {
                GridViewRow row1 = (GridViewRow)GridView1.Rows[row.RowIndex];
                string reference = (string)GridView1.DataKeys[row1.RowIndex].Values["Date"];

                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string sql = @"Select *from dbo.RawMaterial where Date = '" + reference + "'";
                        cmd.CommandText = sql;
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            TextBoxA.Text = Convert.ToString(dt.Rows[0]["CodMaterial"]);
                            TextBoxB.Text = Convert.ToString(dt.Rows[0]["LotMaterial"]);
                            TextBoxC.Text = Convert.ToString(dt.Rows[0]["ColetajMaterial"]);
                            TextBoxD.Text = Convert.ToString(dt.Rows[0]["EroareMaterial"]);
                            TextBoxE.Text = Convert.ToString(dt.Rows[0]["StareMaterial"]);
                            TextBoxF.Text = Convert.ToString(dt.Rows[0]["TipMaterial"]);
                            TextBoxG.Text = Convert.ToString(dt.Rows[0]["CantitateMaterial"]);
                            TextBox2.Text = Convert.ToString(dt.Rows[0]["Date"]);
                            string[] date1 = TextBox2.Text.Split(' ');
                            string[] date2 = date1[0].ToString().Split('/');
                            string[] time = date1[1].ToString().Split(':');
                            string year = date2[2];
                            string mounth = date2[1];
                            string day = date2[0];
                            string hour = time[0];
                            string minutes = time[1];
                            int seconds1 = Convert.ToInt32(time[2]);
                            string seconds1alt = time[2];
                            int seconds2 = seconds1 + 1;

                            string seconds2alt = "";

                            if (seconds2 < 10)
                            {
                                seconds2alt = "0" + Convert.ToString(seconds2);
                            }
                            else
                            {
                                seconds2alt = Convert.ToString(seconds2);
                            }
                            string finaldate1 = year + "-" + mounth + "-" + day + " " + hour + ":" + minutes + ":" + seconds1alt + ".000";
                            string finaldate2 = year + "-" + mounth + "-" + day + " " + hour + ":" + minutes + ":" + seconds2alt + ".000";
                            TextBox3.Text = finaldate1;
                            TextBox4.Text = finaldate2;
                        }
                    }
                }
            }
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string date = TextBox2.Text;
        string codmaterial = TextBoxA.Text;
        string lotmaterial = TextBoxB.Text;
        string coletaj = TextBoxC.Text;
        string eroare = TextBoxD.Text;
        string stare = TextBoxE.Text;
        string tip = TextBoxF.Text;
        string cantitate = TextBoxG.Text;

        string[] alt = TextBoxC.Text.Split('x');
        int value = Convert.ToInt32(alt[0]);

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"UPDATE dbo.RawMaterial SET CodMaterial = '" + codmaterial + "', LotMaterial = '" + lotmaterial + "', ColetajMaterial = '" + coletaj + "', EroareMaterial = '" + eroare + "', StareMaterial = '" + stare + "', TipMaterial='" + tip + "', CantitateMaterial= '" + cantitate + "'  where Date like '" + date + "' ";

                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                }
                Details();
            }
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"UPDATE dbo.RawMaterialFinal SET CodMaterial = '" + codmaterial + "', LotMaterial = '" + lotmaterial + "', ColetajMaterial = '" + coletaj + "', EroareMaterial = '" + eroare + "', StareMaterial = '" + stare + "', TipMaterial='" + tip + "', CantitateMaterial= '" + cantitate + "'  where Date between '" + TextBox3.Text + "' and '" + TextBox4.Text + "'";

                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                }
                Details();
            }

        }

    }
    public void Details_sort(object sender, GridViewSortEventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @" Select * from dbo.RawMaterial where  Operator = '" + Session["name"] + "' order by Date desc";

                cmd.CommandText = sql;
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    e.SortDirection = SortDirection.Ascending;
                    dt.DefaultView.Sort = e.SortExpression;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
}



