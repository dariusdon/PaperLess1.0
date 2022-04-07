using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic.FileIO;
using System.IO;
public partial class Operator : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        getSchimb();
        GridView1.Visible = false;
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
            Label1.Text ="Data:" + DateTime.Now.ToString("dd/MM/yyyy");
            Label2.Text = "Schimb:" + Session["schimb"].ToString();
            Label3.Text = "Operator:" + Session["name"];
        //    string dirpath = "G:\\Plant_Operations\\PO_Public\\ParametriiMateriale\\";
        //    Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(dirpath + "Parametrii.xlsx");
        //    string altpath = dirpath;
        //    workbook.Save(altpath + "Parametrii.csv");
        //    string csvpath = altpath + "Parametrii.csv";


        //    var table = new DataTable();
        //    using (var parser = new TextFieldParser(File.OpenRead(csvpath)))
        //    {
        //        parser.Delimiters = new[] { "," };
        //        parser.HasFieldsEnclosedInQuotes = true;
        //        // load DataColumns from first line 
        //        String[] headers = parser.ReadFields();
        //        foreach (var h in headers)
        //            table.Columns.Add(h);
        //        // load all other lines as data '
        //        String[] fields;
        //        while ((fields = parser.ReadFields()) != null)
        //        {
        //            table.Rows.Add().ItemArray = fields;
        //        }
        //    }
        //    GridView1.DataSource = table;
        //    GridView1.DataBind();
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if((string)Session["CodMaterial"] == "" || (string)Session["Cantitate"] == "")
        {
            Response.Redirect("Operator.aspx");
        }
        else
        {
            Session["CodMaterial"] = TextBox1.Text;
            Session["Cantitate"] = TextBox2.Text;
            

        //    for(int i=0;i < GridView1.Rows.Count; i++)
        //    {
        //        for(int j = 0; j < GridView1.Rows[i].Cells.Count;j++)
        //        {
        //            if (GridView1.Rows[i].Cells[j].Text == TextBox1.Text)
        //            {
        //                Session["Greutate"] = GridView1.Rows[i].Cells[j+2].Text;
        //                Session["TipAmbalaj"] = GridView1.Rows[i].Cells[j+1].Text;
                        
        //            }
        //        }
        //    }
        //    Session["All"] = Session["Cantitate"] + "x" + Session["Greutate"];
        }
        Response.Redirect("DetaliiMaterial.aspx");
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
}