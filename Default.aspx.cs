using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void OnClick(Object sender, EventArgs e)
    {
        Session["name"] = TextBox1.Text;
        Session["password"] = TextBox2.Text;
        
        if ((string)Session["name"] == "mixing" && (string)Session["password"] == "mixing")
        {
            Response.Redirect("RaportMixing.aspx");
        }
        if((string)Session["name"] == "admin" && (string)Session["password"] == "admin")
        {
            Response.Redirect("Admin.aspx");
        }
        if((string)Session["name"] == "Anton" && (string)Session["password"] == "7127")
        {
            Session["name"] = "Anton";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Menihardt" && (string)Session["password"] == "6562")
        {
            Session["name"] = "Menihardt";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "sebastian" && (string)Session["password"] == "titirig")
        {
            Session["name"] = "Sebastian Titirig";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Costea" && (string)Session["password"] == "8039")
        {
            Session["name"] = "Costea";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Stirboiu" && (string)Session["password"] == "6843")
        {
            Session["name"] = "Stirboiu";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Firu" && (string)Session["password"] == "7396")
        {
            Session["name"] = "Firu";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Stalea" && (string)Session["password"] == "7396")
        {
            Session["name"] = "Stalea";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Deac" && (string)Session["password"] == "5262")
        {
            Session["name"] = "Deac";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "Porosnicu" && (string)Session["password"] == "5908")
        {
            Session["name"] = "Porosnicu";
            Response.Redirect("RaportOperatori.aspx");
        }
        if ((string)Session["name"] == "vama" && (string)Session["password"] == "vama")
        {
            Response.Redirect("Vama.aspx");
        }
        if((string)Session["name"] == "incomming" && (string)Session["password"] == "incomming")
        {
            Response.Redirect("Incomming.aspx");
        }

    }
}