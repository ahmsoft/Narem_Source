﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentSignup.aspx.vb" Inherits="StudentSignup" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <asp:Literal runat="server" ID="litMeta" />
    <meta charset="utf-8">
    <style>
        html::-webkit-scrollbar {
            background-color: rgb(50,50,50);
            width: 10px;
        }

        html::-webkit-scrollbar-thumb {
            background-color: #7baa00;
        }

            html::-webkit-scrollbar-thumb:hover {
                background-color: #7b9900;
            }

        html::-o-scrollbar {
            background-color: rgb(50,50,50);
            width: 10px;
        }

        html::-o-scrollbar-thumb {
            background-color: #7baa00;
        }

            html::-o-scrollbar-thumb:hover {
                background-color: #7b9900;
            }
    </style>
    <title>فرم ثبت حساب کاربری آموزشی | شرکت نارم</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="/AdminComponents/dist/css/bootstrap-theme.css">
    <!-- Bootstrap rtl -->
    <link rel="stylesheet" href="/AdminComponents/dist/css/rtl.css">
    <!-- babakhani datepicker -->
    <link rel="stylesheet" href="/AdminComponents/dist/css/persian-datepicker-0.4.5.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="/AdminComponents/bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="/AdminComponents/bower_components/Ionicons/css/ionicons.min.css">
    <!-- daterange picker -->
    <link rel="stylesheet" href="/AdminComponents/bower_components/bootstrap-daterangepicker/daterangepicker.css">
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="/AdminComponents/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="/AdminComponents/plugins/iCheck/all.css">
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="/AdminComponents/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css">
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="/AdminComponents/plugins/timepicker/bootstrap-timepicker.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="/AdminComponents/bower_components/select2/dist/css/select2.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="/AdminComponents/dist/css/AdminLTE.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="/AdminComponents/dist/css/skins/_all-skins.min.css">
    <script src="/js/sweetalert.min.js"></script>
    <link rel="stylesheet" href="css/sweetalert2.all.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form runat="server" autocomplete="off">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <div class="">

            <%--            <header class="main-header">
                <!-- Logo -->
                <a href="Home" class="logo" style="background-color: rgba(0,0,0,0.9);">
                    <!-- mini logo for sidebar mini 50x50 pixels -->
                    <!-- logo for regular state and mobile devices -->
                    <span class="logo-lg" style="color: #7baa00"><b>شرکت نارم </b>
                        <img src="../img/favicon.ico" alt="نارم" style="width: 48px;" /></span>
                </a>
                <!-- Header Navbar: style can be found in header.less -->
                <nav class="navbar navbar-static-top" style="background-color: rgba(20,20,20,0.7);">
                    <!-- Sidebar toggle button-->

                    <!-- Delete This after download -->
                    <!-- End Delete-->



                    <div class="navbar-custom-menu">
                        <ul class="nav navbar-nav">
                            <!-- Messages: style can be found in dropdown.less-->
                            <li class="dropdown messages-menu">
                                <a href="Posts" class="dropdown-toggle" data-toggle="">
                                    <i class="">مطالب سایت</i>
                                </a>
                            </li>
                            <!-- Notifications: style can be found in dropdown.less -->
                            <li class="dropdown notifications-menu">
                                <a href="News" class="dropdown-toggle" data-toggle="">
                                    <i class="">اخبار</i>
                                </a>

                            </li>
                            <!-- Tasks: style can be found in dropdown.less -->
                            <li class="dropdown tasks-menu">
                                <a href="Contact" class="dropdown-toggle" data-toggle="">
                                    <i class="">تماس با ما</i>
                                </a>

                            </li>
                            <!-- User Account: style can be found in dropdown.less -->

                            <!-- Control Sidebar Toggle Button -->

                        </ul>
                    </div>
                </nav>
            </header>--%>
            <!-- right side column. contains the logo and sidebar -->

            <!-- Content Wrapper. Contains page content -->
            <div class="">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>فرم ثبت نام حساب آموزشی 
        <small>دریافت اطلاعات لازم برای ایجاد حساب کاربری آموزشی</small>
                    </h1>
                    <%--<ol class="breadcrumb">
                        <li><a href="https://narem.ir/Home"><i class="fa fa-desktop"></i>صفحه اصلی </a></li>
                        <li><a href="https://narem.ir/posts">مطالب سایت </a></li>
                        <li class="active">ثبت سفارش </li>
                    </ol>--%>
                </section>

                <!-- Main content -->
                <section class="content">

                    <!-- SELECT2 EXAMPLE -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3 class="box-title">اطلاعات اولیه </h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <!-- /.form-group -->
                                    <br />
                                    <label for="txtName_Fa">نام</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-address-book"></i>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName_Fa" ControlToValidate="txtName_Fa" runat="server" ErrorMessage="وارد شود" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionName_Fa" ControlToValidate="txtName_Fa" runat="server" ErrorMessage="فارسی وارد شود" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[ابپتثجچحخدذرزژئسشصضطظعغفق  کگلمنوهیآیيك\s]+\s*$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtName_Fa" onKeyup="Check()" MaxLength="20" placeholder="به عنوان مثال: علی" runat="server" type="Text" required="required" class="form-control" data-inputmask='"mask": ""' data-mask />
                                    </div>
                                    <!-- /.form-group -->
                                    <br />
                                    <label for="txtNameAndFamily">نام خانوادگی</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-address-book"></i>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFamily_Fa" runat="server" ErrorMessage="وارد شود" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionFamily_Fa" ControlToValidate="txtFamily_Fa" runat="server" ErrorMessage="فارسی وارد شود" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[ابپتثجچحخدذرزژئسشصضطظعغفق  کگلمنوهیآیيك\s]+\s*$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtFamily_Fa" onKeyup="Check()" MaxLength="20" placeholder="به عنوان مثال: علی‌پور" runat="server" type="Text" required="required" class="form-control" data-inputmask='"mask": ""' data-mask />
                                    </div>
                                    <!-- /.form-group -->
                                    <br />
                                    <label for="txtIDNo">شماره کاربری</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-id-card"></i>
                                        </div>
                                        <asp:TextBox ID="txtIDNo" onKeyup="Check()" placeholder="به عنوان مثال: 984759440" runat="server" type="text" required="required" class="form-control" data-inputmask='"mask": "999999999999999"' data-mask />
                                    </div>
                                    <br />
                                    <!-- /.input group -->
                                    <label for="txtMobile">تلفن همراه</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-mobile"></i>
                                        </div>
                                        <asp:TextBox ID="txtMobile" onKeyup="Check()" placeholder="به عنوان مثال: 09123456789" runat="server" type="text" required="required" class="form-control" data-inputmask='"mask": "09999999999"' data-mask />
                                    </div>
                                    <!-- /.form-group -->

                                </div>
                                <!-- /.col -->


                                <div class="col-md-6">
                                    <br />
                                    <!-- /.input group -->
                                    <label for="txtPass">رمز عبور</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-key"></i>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ControlToValidate="txtPass" ErrorMessage="وارد شود" ValidationGroup="contact" Style="color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPass" onKeyup="Check()" MaxLength="20" placeholder="رمز عبور" runat="server" type="Password" required="required" class="form-control" data-inputmask='"mask": ""' data-mask />
                                    </div>
                                    <!-- /.form-group -->
                                    <br />
                                    <!-- /.input group -->
                                    <label for="txtEmail">پست الکترونیک</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-at"></i>
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="نادرست" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,6}$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="وارد شود" ValidationGroup="contact" Style="color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtEmail" onKeyup="Check()" MaxLength="50" placeholder="به عنوان مثال: abcdfgh.edu@gmail.com" runat="server" type="Email" required="required" class="form-control" data-inputmask='"mask": ""' data-mask />
                                    </div>
                                    <!-- /.form-group -->
                                    <br />
                                    <label for="txtJob">رشته تحصیلی</label><span style="color: red;">*</span>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-book"></i>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtJob" runat="server" ErrorMessage="وارد شود" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtJob" runat="server" ErrorMessage="فارسی وارد شود" ValidationGroup="contact" Style="margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 0px 0px; padding: 2px 2px 5px 5px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[ابپتثجچحخدذرزژئسشصضطظعغفق  کگلمنوهیآیيك\s]+\s*$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtJob" onKeyup="Check()" MaxLength="20" placeholder="به عنوان مثال: حسابداری" runat="server" type="text" required="required" class="form-control" data-inputmask='"mask": ""' data-mask />
                                    </div>
                                    <!-- /.form-group -->
                                    <br />
                                    <label for="txtAddress">مقطع تحصیلی</label><span style="color: red;">*</span>
                                    <select id="optionLevel" onchange="Check();" runat="server" class="form-control select2 text-right" style="width: 100%;">
                                        <option value="0" selected="selected">مقطع تحصیلی خود را انتخاب نمایید</option>
                                        <option value="1">دکتری تخصصی</option>
                                        <option value="2">فوق لیسانس</option>
                                        <option value="3">لیسانس</option>
                                        <option value="4">فوق دیپلم</option>
                                        <option value="5">دیپلم</option>
                                    </select>
                                    <!-- /.input group -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <span>پس از راستی آزمایی اطلاعاتِ فوق، حساب کاربری شما فعال خواهد شد </span>
                        </div>
                    </div>
                    <!-- /.box -->
                </section>
                <table style="width: 100%;">
                    <tr>
                        <th class="ali">
                            <center>
                                <asp:Label runat="server" Visible="false" ID="lblSubmitStatus" Text="پس از ارسال درخواست سفارش منتظر تماس کارشناس شرکت ما باشید. " /></center>
                        </th>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:TextBox runat="server" ID="txtSecCode" CssClass="" placeholder="کد پیامک شده" Visible="false" />
                                <asp:Button runat="server" ID="btnSignup" Text="تایید" CssClass="btn btn-success" Visible="false" />
                                <asp:Button runat="server" ID="btnRefresh" UseSubmitBehavior="false" ValidationGroup="Noting" Style="font-size: 25px; background-color: rgba(0,0,0,0); border: none; display: inline-block; position: absolute; margin-right: 90px;" Text="🔄" />
                                <telerik:RadCaptcha ID="RadCaptcha" onKeyup="Check()" runat="server" CaptchaTextBoxCssClass="aligncenter" Font-Names="arial" Font-Bold="true" CaptchaImage-ImageCssClass="aligncenter " CaptchaTextBoxLabel=""></telerik:RadCaptcha>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <%--<strong style="color: orangered;">توجه:</strong> بارگذاری مجدد تصویر امنیتی Ctrl + R--%>
                            </center>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" Style="width: 100%; height: 45px; border-top-left-radius: 20px; border-top-right-radius: 20px; border-bottom-right-radius: 20px; border-bottom-left-radius: 20px;" name="submit" ID="btnSubmit" Text="ارسال" disabled class="btn btn-block btn-primary" />
                        </td>
                    </tr>
                </table>

            </div>
            <!-- ./wrapper -->
        </div>
    </form>
    <!-- jQuery 3 -->
    <script src="AdminComponents/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="AdminComponents/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- Select2 -->
    <script src="AdminComponents/bower_components/select2/dist/js/select2.full.min.js"></script>
    <!-- InputMask -->
    <script src="AdminComponents/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="AdminComponents/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="AdminComponents/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <!-- date-range-picker -->
    <script src="AdminComponents/bower_components/moment/min/moment.min.js"></script>
    <script src="AdminComponents/bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap datepicker -->
    <script src="AdminComponents/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <!-- bootstrap color picker -->
    <script src="AdminComponents/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
    <!-- bootstrap time picker -->
    <script src="AdminComponents/plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <!-- SlimScroll -->
    <script src="AdminComponents/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- iCheck 1.0.1 -->
    <script src="AdminComponents/plugins/iCheck/icheck.min.js"></script>
    <!-- FastClick -->
    <script src="AdminComponents/bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="AdminComponents/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="AdminComponents/dist/js/demo.js"></script>
    <!-- babakhani datepicker -->
    <script src="AdminComponents/dist/js/persian-date-0.1.8.min.js"></script>
    <script src="AdminComponents/dist/js/persian-datepicker-0.4.5.min.js"></script>
    <!-- Page script -->
    <script>
        $(document).ready(function () {
            $('#tarikh').persianDatepicker({
                altField: '#tarikhAlt',
                altFormat: 'X',
                format: 'D MMMM YYYY HH:mm a',
                observer: true,
                timePicker: {
                    enabled: true
                },
            });

        });
        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2()

            //Datemask dd/mm/yyyy
            $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
            //Datemask2 mm/dd/yyyy
            $('#datemask2').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' })
            //Money Euro
            $('[data-mask]').inputmask()

            //Date range picker
            $('#reservation').daterangepicker()
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' })
            //Date range as a button
            $('#daterange-btn').daterangepicker(
                {
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    },
                    startDate: moment().subtract(29, 'days'),
                    endDate: moment()
                },
                function (start, end) {
                    $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'))
                }
            )

            //Date picker
            $('#datepicker').datepicker({
                autoclose: true
            })

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            })
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            })
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            })

            //Colorpicker
            $('.my-colorpicker1').colorpicker()
            //color picker with addon
            $('.my-colorpicker2').colorpicker()

            //Timepicker
            $('.timepicker').timepicker({
                showInputs: false
            })
        })
        //function Signupp(event) {

        //}
        function Check() {
            var txtname_fa = document.getElementById("<%=txtName_Fa.ClientID%>");
            var txtfamily_fa = document.getElementById("<%=txtFamily_Fa.ClientID%>");
            var txtpass = document.getElementById("<%=txtPass.ClientID%>");
            var txtemail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtidno = document.getElementById("<%=txtIDNo.ClientID%>");
            var txtmobile = document.getElementById("<%=txtMobile.ClientID%>");
            var txtjob = document.getElementById("<%=txtJob.ClientID%>");
            var optionlevel = document.getElementById("<%=optionLevel.ClientID%>");
            var Captcha = document.getElementById("<%=RadCaptcha.ClientID%>");
            var myButton = document.getElementById("<%=btnSubmit.ClientID%>");
            if (txtname_fa.value != "" && txtfamily_fa.value != "" && txtpass.value !="" && txtmobile.value != "" && txtidno.value != "" && txtemail.value != "" && txtjob.value != "" && Captcha.value != "" && optionlevel.value > 0) {
                myButton.disabled = false;
            } else {
                myButton.disabled = true;

            }
            //myButton.setAttribute("disabled", "disabled");
            //alert("Hello! I am an alert box!!");
            //if (txtnameandfamily.value.length > 1) {
            //}
            //else {
            //    btnsubmit.enabled = false;

            //}
        }
        //function Signupp(event) {
        //    if (event.keyCode == 13) {
        //        $("#ContentPlaceHolder1_btnSignup").click();
        //    }
        //}
    </script>
</body>
</html>
