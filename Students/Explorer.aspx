<%@ Page Title="" Language="VB"AutoEventWireup="false" CodeFile="Explorer.aspx.vb" Inherits="Students_Exploer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- babakhani datepicker -->
    <link rel="stylesheet" href="StudentsComponents/dist/css/persian-datepicker-0.4.5.min.css" />
    <!-- daterange picker -->
    <link rel="stylesheet" href="StudentsComponents/bower_components/bootstrap-daterangepicker/daterangepicker.css" />
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="StudentsComponents/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" />
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="StudentsComponents/dist/css/bootstrap-theme.css" />
    <!-- Bootstrap rtl -->
    <!-- Font Awesome -->
    <link rel="stylesheet" href="StudentsComponents/bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="StudentsComponents/bower_components/Ionicons/css/ionicons.min.css" />
    <!-- jvectormap -->
    <link rel="stylesheet" href="StudentsComponents/bower_components/jvectormap/jquery-jvectormap.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="StudentsComponents/dist/css/AdminLTE.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="StudentsComponents/dist/css/skins/_all-skins.min.css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="StudentsComponents/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" />
    <title>آپلود سنتر</title>
    <link href="dialogstyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <telerik:RadFileExplorer ID="FileExplorer1" OnClientFileOpen="OnClientFileOpen" runat="server" AllowPaging="True" DisplayUpFolderItem="True" EnableCopy="True" EnableTheming="True" Style="width: 100%;" Width="100%" Configuration-AllowMultipleSelection="False">
            <Configuration DeletePaths="~/Students/Uploads" MaxUploadFileSize="1024000000" UploadPaths="~/Students/Uploads" ViewPaths="~/Students/Uploads" />
        </telerik:RadFileExplorer>
        <script src="StudentsComponents/dialogscripts.js" type="text/javascript"></script>
    <asp:Button runat="server" ID="btnBack" Text="بازگشت" CssClass="btn btn-danger" PostBackUrl="~/Students/StudentsPanel.aspx" />
    </form>
</body>
</html>