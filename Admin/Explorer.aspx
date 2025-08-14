<%@ Page %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>انتخاب تصویر</title>
    <link href="dialogstyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <telerik:RadFileExplorer ID="FileExplorer1" OnClientFileOpen="OnClientFileOpen" runat="server" AllowPaging="True" DisplayUpFolderItem="True" EnableCopy="True" EnableTheming="True" Style="width: 100%;" Width="100%" Configuration-AllowMultipleSelection="False">
            <Configuration DeletePaths="~/" MaxUploadFileSize="1024000000" UploadPaths="~/" ViewPaths="~/" />
        </telerik:RadFileExplorer>
        <script src="AdminComponents/dialogscripts.js" type="text/javascript"></script>
    </form>
</body>
</html>
