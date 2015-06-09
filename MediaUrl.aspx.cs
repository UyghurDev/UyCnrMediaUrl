using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using net.UyghurDev.Text;
using System.Text;

public partial class UyCnrMediaUrl_MediaUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getUrl();
    }

    private void getUrl()
    {
        Response.Clear();
        String strResult = "";
        Boolean blnError = false;
        if (String.IsNullOrEmpty(Request.QueryString["url"]))
        {
            strResult = "ئادرىس يوق!";
            Response.Write(strResult);
            return;
        }

        string strUrl=Request.QueryString["url"].ToLower();
        if (!strUrl.StartsWith("http://www.uycnr.com/wqhg/"))
        {
            strResult = "چوقۇم مەركىزى خەلق رادىئو ئىستانسىسىنىڭ(www.uycnr.com) «توردىكى رادىئو» سەھىپىسىدىكى پروگراممىلارنىڭ ئادرىسىنى كىرگۈزۈشىڭىز كېرەك!";
            Response.Write(strResult);
            return;
        }


        try
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            StringBuilder sbResult = new StringBuilder();


            string strText = System.Text.UTF8Encoding.UTF8.GetString(wc.DownloadData(Request.QueryString["url"]));

            List<string> lstTable = HtmlTableParser.Table(strText);
            List<string> lstLinks = HtmlTableParser.getLinks(lstTable[2]);

            //List<string> lstRow = HtmlTableParser.Tr(lstTable[2]);
            //List<string> lstDt=new List<string>();
            //foreach(string strRow in lstRow)
            //{
            //    foreach( string strTd in HtmlTableParser.Td(strRow))
            //    {
            //        lstDt.Add(HtmlTableParser.getTdContent(strTd));
            //     }
            //}

            sbResult.AppendLine("<center>");
            foreach (string strLink in lstLinks)
            {
                sbResult.Append(getStreamUrl(strLink)).AppendLine("<br/>");
            }
            sbResult.AppendLine("</center>");



            Response.Write(sbResult.ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<center><span id='err'>خاتالىق كۆرۈلدى!</span></center>");
        }
    }

    

    private string getStreamUrl(string strASXUrl)
    {
        System.Net.WebClient wc = new System.Net.WebClient();
        string strText = System.Text.UTF8Encoding.UTF8.GetString(wc.DownloadData(strASXUrl));
        if (String.IsNullOrEmpty(strText))
        { return null; }
        List<string> lstLinks = HtmlTableParser.getLinks(strText);
        StringBuilder sbLinks = new StringBuilder();
        foreach (string strLink in lstLinks)
        {
            sbLinks.Append("<a href='").Append(strLink).Append("'>").Append(getName(strLink)).Append("</a>");
        }
        return sbLinks.ToString();
    }

    private string getName(string strUrl)
    {
        try
        {
        mms://mediafb.cnrmz.com/VOD/SmartEncoder2011/05/wygb_wyshdh_08_00_00_2011-05-22_08-30-12.wma?zqzT78n6u+61vLq9XzIwMTEtMDUtMjIjMjQyMjkjMTcz
            int nStart = strUrl.IndexOf("_");
            int nEnd = strUrl.IndexOf(".", nStart);
            return strUrl.Substring(nStart, nEnd - nStart);
        }
        catch(Exception ex)
        {
        return "Link";
        }
    }
}
