<%@ Page Title="" Language="VB" MasterPageFile="StudentsMasterPage.master" AutoEventWireup="false" CodeFile="Upload.aspx.vb" Inherits="Upload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">

        <div class="container-fluid">

            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">مدیریت پیام <small>پیام های مطالب سایت</small></h1>

                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-edit"></i>Upload Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
                    <telerik:RadFileExplorer ID="FileExplorer1" OnClientFileOpen="OnClientFileOpen" runat="server" AllowPaging="True" DisplayUpFolderItem="True" EnableCopy="True" EnableTheming="True" Style="width: 100%;" Width="100%" Configuration-AllowMultipleSelection="False">
                        <Configuration DeletePaths="~/Uploads" MaxUploadFileSize="1024000000" UploadPaths="~/Uploads" ViewPaths="~/Uploads" />
                    </telerik:RadFileExplorer>
                    <script src="StudentsComponents/dialogscripts.js" type="text/javascript"></script>

                </div>
            </div>
            <!-- /.row -->

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->

</asp:Content>

