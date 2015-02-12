<%@ Page AutoEventWireup="true" CodeBehind="Home.aspx.cs" EnableEventValidation="false" Inherits="Tavisca.Vexiere.WcfHarness.Home" Language="C#" ValidateRequest="false" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
<script src="Scripts/codemirror-2.37/lib/codemirror.js"></script>
<link rel="stylesheet" href="Scripts/codemirror-2.37/lib/codemirror.css">
<script src="Scripts/codemirror-2.37/mode/xml/xml.js"></script>
<style type="text/css">
    .CodeMirror {
        border-top: 1px solid #888;
        border-bottom: 1px solid #888;
        border-left: 1px solid #888;
        border-right: 1px solid #888;
    }
</style>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script>
        function setModeWithCodeMirror() {
            var textAreaRequest = document.getElementById("tbRequestXml");
            var textAreaResponse = document.getElementById("tbResponseXml");

            textAreaRequest = CodeMirror.fromTextArea(textAreaRequest,
            {
                mode: 'xml',
            });
            textAreaResponse = CodeMirror.fromTextArea(textAreaResponse,
            {
                mode: 'xml',
            });
        }
    </script>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
    <style type="text/css">
        /* GitHub stylesheet for MarkdownPad (http://markdownpad.com) */
        /* Author: Nicolas Hery - http://nicolashery.com */
        /* Version: b13fe65ca28d2e568c6ed5d7f06581183df8f2ff */
        /* Source: https://github.com/nicolahery/markdownpad-github */

        /* RESET
=============================================================================*/

        html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary, time, mark, audio, video {
            margin: 0;
            padding: 0;
            border: 0;
        }

        /* BODY
=============================================================================*/
        html {
            min-height: 100%;
            height: 100%;
        }

        .main {
            width: 980px;
            margin-left: auto;
            margin-right: auto;
        }

        .wrapper {
            padding-bottom: 70px;
            clear: both;
        }

        .site-footer, .page-wrap:after {
        }

        .site-footer {
            position: absolute;
            bottom: 0;
            width: 100%;
            padding: 20px 0px;
            background-color: #333;
            color: #FFF;
            font-size: 12px;
            font-family: 'Open Sans';
        }

        .wrapper:after {
            content: "";
            display: block;
        }


        body {
            font-family: 'Open Sans';
            font-size: 14px;
            line-height: 1.6;
            color: #333;
            background-color: #fff;
            margin: 0 auto;
            min-height: 100%;
            position: relative;
        }

            body > *:first-child {
                margin-top: 0 !important;
            }

            body > *:last-child {
                margin-bottom: 0 !important;
            }

        /* BLOCKS
=============================================================================*/

        p, blockquote, ul, ol, dl, table, pre {
            margin: 15px 0;
        }

        /* HEADERS
=============================================================================*/

        h1, h2, h3, h4, h5, h6 {
            margin: 20px 0 10px;
            padding: 0;
            font-weight: 300;
            -webkit-font-smoothing: antialiased;
        }

            h1 tt, h1 code, h2 tt, h2 code, h3 tt, h3 code, h4 tt, h4 code, h5 tt, h5 code, h6 tt, h6 code {
                font-size: inherit;
            }

        h1 {
            font-size: 28px;
            color: #000;
        }

        h2 {
            font-size: 24px;
            border-bottom: 1px solid #ccc;
            color: #000;
        }

        h3 {
            font-size: 18px;
        }

        h4 {
            font-size: 16px;
        }

        h5 {
            font-size: 14px;
        }

        h6 {
            color: #777;
            font-size: 14px;
        }

        body > h2:first-child, body > h1:first-child, body > h1:first-child + h2, body > h3:first-child, body > h4:first-child, body > h5:first-child, body > h6:first-child {
            margin-top: 0;
            padding-top: 0;
        }

        a:first-child h1, a:first-child h2, a:first-child h3, a:first-child h4, a:first-child h5, a:first-child h6 {
            margin-top: 0;
            padding-top: 0;
        }

        h1 + p, h2 + p, h3 + p, h4 + p, h5 + p, h6 + p {
            margin-top: 10px;
        }

        /* LINKS
=============================================================================*/

        a {
            color: #4183C4;
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }

        /* LISTS
=============================================================================*/

        ul, ol {
            padding-left: 30px;
        }

            ul li > :first-child,
            ol li > :first-child,
            ul li ul:first-of-type,
            ol li ol:first-of-type,
            ul li ol:first-of-type,
            ol li ul:first-of-type {
                margin-top: 0px;
            }

            ul ul, ul ol, ol ol, ol ul {
                margin-bottom: 0;
            }

        dl {
            padding: 0;
        }

            dl dt {
                font-size: 14px;
                font-weight: 300;
                font-style: italic;
                padding: 0;
                margin: 15px 0 5px;
            }

                dl dt:first-child {
                    padding: 0;
                }

                dl dt > :first-child {
                    margin-top: 0px;
                }

                dl dt > :last-child {
                    margin-bottom: 0px;
                }

            dl dd {
                margin: 0 0 15px;
                padding: 0 15px;
            }

                dl dd > :first-child {
                    margin-top: 0px;
                }

                dl dd > :last-child {
                    margin-bottom: 0px;
                }

        /* CODE
=============================================================================*/

        pre, code, tt {
            font-size: 12px;
            font-family: Consolas, "Liberation Mono", Courier, monospace;
        }

        code, tt {
            margin: 0 0px;
            padding: 0px 0px;
            white-space: nowrap;
            border: 1px solid #eaeaea;
            background-color: #f8f8f8;
            border-radius: 3px;
        }

        pre > code {
            margin: 0;
            padding: 0;
            white-space: pre;
            border: none;
            background: transparent;
        }

        pre {
            background-color: #f8f8f8;
            border: 1px solid #ccc;
            font-size: 13px;
            line-height: 19px;
            overflow: auto;
            padding: 6px 10px;
            border-radius: 3px;
        }

            pre code, pre tt {
                background-color: transparent;
                border: none;
            }

        kbd {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            background-color: #DDDDDD;
            background-image: linear-gradient(#F1F1F1, #DDDDDD);
            background-repeat: repeat-x;
            border-color: #DDDDDD #CCCCCC #CCCCCC #DDDDDD;
            border-image: none;
            border-radius: 2px 2px 2px 2px;
            border-style: solid;
            border-width: 1px;
            font-family: 'Open Sans';
            line-height: 10px;
            padding: 1px 4px;
        }

        /* QUOTES
=============================================================================*/

        blockquote {
            border-left: 4px solid #DDD;
            padding: 0 15px;
            color: #777;
        }

            blockquote > :first-child {
                margin-top: 0px;
            }

            blockquote > :last-child {
                margin-bottom: 0px;
            }

        /* HORIZONTAL RULES
=============================================================================*/

        hr {
            clear: both;
            margin: 15px 0;
            height: 0px;
            overflow: hidden;
            border: none;
            background: transparent;
            border-bottom: 4px solid #ddd;
            padding: 0;
        }

        /* TABLES
=============================================================================*/

        table th {
            font-weight: 300;
        }

        table th, table td {
            border-bottom: 1px solid #ccc;
            padding: 6px 13px;
        }

        table tr {
            border-top: 1px solid #ccc;
            background-color: #fff;
        }

        /* IMAGES
=============================================================================*/

        img {
            max-width: 100%;
        }
    </style>
</head>
<body>


    <form id="form1" runat="server">
        <div id="header" style="padding: 15px 20px; background-color: #333; color: #FFF; font-size: 14px;">
            <div class="main">
                <a href="https://dev-vexiere.tavisca.com/Vexiere3.0/Apis/docs/business/index.html">
                    <img src="Images/vex-logo.png" alt="Vexiere APIs" height="32" style="float: left;">
                </a>
                <div id="headerTitle" style="padding-left: 150px; padding-top: 2px; font-size: 18px; font-family: 'Open Sans';">API Documentation</div>
                <div style="clear: both;"></div>
            </div>
        </div>

        <div class="main wrapper">

            <h1 style="margin-left: 20px;">Vexiere Core Services Harness</h1>
            <br/>
            <div style="margin-left: 20px;">
                <div style="margin-left: 0px">
                    <asp:RadioButton ID="rbLogin" GroupName="login" runat="server" Font-Bold="True" Text="Login" ToolTip="Login as SuperAdmin" AutoPostBack="True" OnCheckedChanged="rbLogin_CheckedChanged" Checked="True" />
                    <asp:RadioButton ID="rbToken" GroupName="login" runat="server" Font-Bold="True" Text="Token" Style="margin-left: 100px" OnCheckedChanged="rbToken_CheckedChanged" AutoPostBack="True" />
                </div>
                <div style="margin: 20px 20px 20px 0px">
                    <asp:Label ID="lblLoginStatus" runat="server" Visible="False"></asp:Label>
                </div>
                <div style="margin-top: 10px">
                    <div runat="server" id="idLoginCredentials">
                        <div>
                            <asp:Label ID="lblUserName" runat="server" Text="Username:"></asp:Label>
                            <asp:TextBox ID="tbUserName" runat="server" Style="margin-left: 15px;" Width="209px"></asp:TextBox>
                            <asp:Label ID="lblPassword" runat="server" Text="Password:" Style="margin-left: 30px;"></asp:Label>
                            <asp:TextBox ID="tbPassword" runat="server" Width="195px" Style="margin-left: 15px;"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblRootId" runat="server" Text="Organization Id:"></asp:Label>
                            <asp:TextBox ID="tbRootId" runat="server" Width="91px" Style="margin-left: 15px;"></asp:TextBox>
                            <asp:Label ID="lblAPIKey" runat="server" Text="APIKey:" Style="margin-left: 30px;"></asp:Label>
                            <asp:TextBox ID="tbAPIKey" runat="server" Width="283px" Style="margin-left: 20px;"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblAccessTokenEndPoint" runat="server" Text="Access Token End Point:"></asp:Label>
                            <asp:TextBox ID="tbAccessTokenEndPoint" runat="server" Width="430px" Style="margin-left: 15px;"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" Width="110px" Height="31px" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                    <div runat="server" id="idTbToken">
                        <br />
                        <asp:Label ID="lbAccessToken" runat="server" Text="Access Token:"></asp:Label>
                        <asp:TextBox ID="tbAccessToken" runat="server" Style="margin-left: 15px; margin-top: 10px;" Height="30px" Width="491px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="margin-left: 20px">
                <asp:Label ID="lblSvc" runat="server" Text="Service : " Font-Bold="True" Height="30px" Width="110px"></asp:Label>
                <asp:DropDownList ID="ddlService" runat="server" Height="33px" Style="margin-left: 20px; margin-top: 20px" TabIndex="1" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ddlService_SelectedIndexChanged" Width="368px">
                </asp:DropDownList>
            </div>
            <div style="margin-left: 20px">
                <asp:Label ID="lblOperation" runat="server" Text="Method : " Font-Bold="True" Height="30px" Width="110px"></asp:Label>
                <asp:DropDownList ID="ddlOperation" runat="server" Height="29px" Style="margin-left: 20px; margin-top: 20px" TabIndex="1" ViewStateMode="Enabled" OnSelectedIndexChanged="ddlOperation_SelectedIndexChanged" AutoPostBack="True" Width="368px">
                </asp:DropDownList>
            </div>
            <div style="margin-left: 20px">
                <asp:Label ID="lblSample" runat="server" Text="Sample : " Font-Bold="True" Height="30px" Width="110px"></asp:Label>
                <asp:DropDownList ID="ddlSamples" runat="server" Height="29px" Style="margin-left: 20px; margin-top: 20px" TabIndex="1" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ddlSamples_SelectedIndexChanged" Width="368px">
                </asp:DropDownList>
            </div>
            <div style="margin-left: 20px; margin-bottom: 20px">
                <br />
                <asp:Label ID="lblUrl" runat="server" Text="URL :" Font-Bold="True" Height="30px" Width="110px"></asp:Label>
                <asp:TextBox ID="tbUrl" runat="server" Style="margin-left: 20px" Width="368px" TextMode="Url" Height="30px"></asp:TextBox>
                <br />
            </div>
            <div style="margin-left: 20px">
                <div style="margin-top: 10px; margin-bottom: 10px">
                    <asp:Label ID="lblRequest" runat="server" Font-Bold="True" Text="Request:"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="tbRequestXml" runat="server" ClientIDMode="Static" Height="360px" Style="margin-left: 0px;" TextMode="MultiLine" Width="600px" Wrap="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnPost" runat="server" Height="30px" Style="margin-left: 0px; margin-right: 20px" Text="Post" Width="80px" OnClick="btnPost_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblResponse" runat="server" Font-Bold="True" Text="Response:"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="tbResponseXml" runat="server" ClientIDMode="Static" Height="360px" Style="margin-left: 0px;" TextMode="MultiLine" Width="600px" Wrap="False"></asp:TextBox>
                    <br />
                </div>
            </div>


        </div>
        <div id="footer" align="center" class="site-footer">© 2015 Tavisca Solutions Pvt. Ltd.</div>
    </form>

    <script>
        window.onload = setModeWithCodeMirror();
    </script>
</body>


</html>


