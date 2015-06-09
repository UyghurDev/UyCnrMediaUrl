using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace net.UyghurDev.Text
{
   public static  class HtmlTableParser
    {
        const string msgFormat = "table[{0}], tr[{1}], td[{2}], a: {3}, b: {4}";
        const string table_pattern = "<table.*?>(.*?)</table>";
        const string tr_pattern = "<tr>(.*?)</tr>";
        const string td_pattern = "<td.*?>(.*?)</td>";
        const string a_pattern = "<a href=\"(.*?)\"></a>";
        const string b_pattern = "<b>(.*?)</b>";
        const string p_pattern = "<p.*?>(.*?)</p>";
        const string lnk_pattern = "\\b(https?|ftp|file|mms)://[-A-Z0-9+&@#/%?=~_|!:,.;]*[-A-Z0-9+&@#/%=~_|]";

      
       /// <summary>
       /// جەدىۋەل ئېلىش
       /// </summary>
       /// <param name="strHtml">پۈتۈن بەت كودى</param>
       /// <returns>بارلىق جەدىۋەللەرنى قايتۇرىدۇ</returns>
       public static List<string> Table(string strHtml)
       {
           List<string> tableContents = GetContents(strHtml, table_pattern,RegexOptions.Singleline);
            return tableContents;

       }

       /// <summary>
       /// قۇر ئېلىش
       /// </summary>
       /// <param name="tableContent">بىر جەدىۋەلنىڭ كودى</param>
       /// <returns>بىر جەدىۋەلدىكى بارلىق قۇرلارنى قايتۇرىدۇ</returns>
       public static List<string> Tr(string tableContent)
       {
           List<string> trContents= GetContents(tableContent, tr_pattern,RegexOptions.Singleline);
           return trContents;
       }

       /// <summary>
       /// كاتەك ئېلىش
       /// </summary>
       /// <param name="trContent">بىر قۇرنىڭ كودى</param>
       /// <returns>بىر قۇردىكى بارلىق كاتەكلەرنى ئالىدۇ</returns>
       public static List<string> Td(string trContent)
       {
           List<string> tdContents = GetContents(trContent, td_pattern,RegexOptions.Singleline);
           return tdContents;
       }

       /// <summary>
       /// ئۇلىنىش ئېلىش
       /// </summary>
       /// <param name="strContent">مەزمۇن</param>
       /// <returns>ئۇلىنىشلار</returns>
       public static List<string> getLinks(string strContent)
       {
           List<string> lnkContents = GetContents(strContent, lnk_pattern,RegexOptions.IgnoreCase);
           return lnkContents;
       }

       /// <summary>
       /// كاتەكتىكى مەزمۇنلارنى ئېلىش
       /// </summary>
       /// <param name="strTd">بىر جەدىۋەل كاتىكىنىڭ كودى</param>
       /// <returns>مەزمۇن</returns>
       public static string getTdContent(string strTd)
       {
           Regex r;
           Match m;
           string rx = "<td.*?>(.*?)</td>";
           //r = new Regex(rx, RegexOptions.IgnoreCase | RegexOptions.Compiled);
           r = new Regex(rx);
           string strRet = "";
           m = r.Match(strTd);
           strRet = m.Groups[1].Value;
           //for (m = r.Match(strTd); m.Success; m = m.NextMatch())
           //{
           //   strRet=m.Groups[1].Value;
           //}
           return strRet;
       }

       /// <summary>
       /// ماس مەزمۇننى ئېلىش
       /// </summary>
       /// <param name="input">ئەسلى تېكىست مەزمۇنى</param>
       /// <param name="pattern">ئەندىزە</param>
       /// <returns>مەزمۇنلارنىڭ توپلىمى</returns>
       private static List<string> GetContents(string input, string pattern,RegexOptions rxo)
       {
           MatchCollection matches = Regex.Matches(input, pattern, rxo);
           List<string> contents = new List<string>();
           foreach (Match match in matches)
               contents.Add(match.Value);
           return contents;
       }



       /// <summary>
       /// html كودلىرىنى سۈزىۋىتىش
       /// </summary>
       /// <param name="in_HTML"></param>
       /// <returns></returns>
       public static string RemoveHTML(string in_HTML)
       {
           return Regex.Replace(in_HTML, "<(.|\n)*?>", "");
       }
    }
}
