<%@ Page Title="ئۈن ئادرىسىنى ئېلىش" Language="C#" MasterPageFile="~/Common/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UyCnrMediaUrl_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpheader" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #loading { display:none; }
       #tUrl { direction:ltr;}
       #btnGet{ font-family:"alkatip tor", "Microsoft Uighur" !important;}
       #result 
       {
       	 text-align:justify; 
       	}
       	#err {color:#ff0000;}
    </style>
    

    <script src="../Common/jquery-1.6.1.js" type="text/javascript"></script>
      <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
  <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="ئۈن ئادرىسىنى تېپىش" Font-Size="Large"></asp:Label>
    <br />
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td>
                ئادرىس:<input id="tUrl" type="text" value="http://www.uycnr.com/wqhg/zbtx/" /><div id="btnGet">ئۈن ئادرىسىنى ئېلىش</div>
                <br /><img id="loading" alt="" 
                        src="ajax-loader.gif" width="126" height="22" /></td>
        </tr>
        <tr>
            <td>
                
                <div id="result">
                <p>
                مەركىزى خەلق رادىئو ئىستانسىسىنىڭ ئۇيغۇرچە ئاڭلىتىشلىرى رادىئو ئىستانسىسىنىڭ ئۇيغۇرچە ئورگان تور بېتىدە تەمىنلەنگەن. ئەمما Internet Explorer  دىن باشقا تور كۆرگۈچلەردە ئۇنى ئاڭلىغىلى بولمايدۇ. سىز بۇ يەرگە مەركىزى خەلق رادىئو ئىستانسىسىنىڭ «توردىكى رادىئو» سەھىپىسىدىكى ماس رادىئو پروگراممىلىرىنىڭ ئادرىسىنى كىرگۈزۈش ئارقىلىق شۇ پروگراممىنىڭ ئاۋاز ھۆججەتلىرىنىڭ ئادرىسىنى تاپالايسىز. شۇنداقلا ئۇنى Media Player ياكى باشقا ئۈن قويغۇچلار ئارقىلىق ئاڭلىيالايسىز.
                </p>
                    <p>
                        مەركىزى خەلق رادىئو ئىستانسىسىنىڭ تور بىكەت ئادرىسى:<a 
                            href="http://www.uycnr.com/">www.uycnr.com</a></p>
                    <p>
                        توردىكى رادىئو سەھىپىسىنىڭ ئادرىسى: <a href="http://www.uycnr.com/wqhg/shdh/">
                        www.uycnr.com/wqhg/shdh</a></p>
                </div>
                <script language="javascript" type="text/javascript">
                    $(document).ready(function() {
                        $('#btnGet').button();
                    });
                    
                    $('#btnGet').click(function() {
                       showLoading();
                        $('#result').load("MediaUrl.aspx?url=" + $('#tUrl').val(), function() {
                             hideLoading();
                        }

                        );
                    });
                    function showLoading() {
                        $("#loading").show();
                    }

                    function hideLoading() {
                        $("#loading").hide();
                    }
                </script>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

