
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Spire.Pdf;
using Spire.Pdf.Exporting.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public partial class Vama : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void OnClick(object sender, EventArgs e)
    {
        string folderpath = Server.MapPath("~/File/");
        FileUpload2.SaveAs(folderpath + "1.pdf");
        string path = folderpath + "1.pdf";
        PdfDocument pdf = new PdfDocument();
        pdf.LoadFromFile(path);
        StringBuilder content = new StringBuilder();
        foreach (PdfPageBase page in pdf.Pages)
        {
            content.Append(page.ExtractText());
        }
        String fileName = Server.MapPath("~/File/" + "1.txt");
        File.WriteAllText(fileName, content.ToString());
        
    }
}