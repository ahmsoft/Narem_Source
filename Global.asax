<%@ Application Language="VB" %>
<script RunAt="server">
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Application("visToday") = 0
        'Dim db = New LinqDBClassesDataContext
        'Dim Vis = From m In db.Visitors
        '          Select m

        'For Each m In Vis
        '    Application("vis") = m.AllVisitor
        'Next
        RegisterRoutes(Routing.RouteTable.Routes)
    End Sub
    Sub RegisterRoutes(routes As Routing.RouteCollection)
        'routes.MapPageRoute("", "PostView/{Action}/{Title}", "~/PostView.aspx")
        '@* ----------------------------------------------------------------------Farsi------------------------
        'routes.MapPageRoute("", "PostView/{Action}/{ID}/{Tag}", "~/PostView.aspx")
        'routes.MapPageRoute("", "PostView/{Action}/{ID}", "~/PostView.aspx")
        'routes.MapPageRoute("defaultRoute", "{*value}", "~/Index.aspx")

        routes.MapPageRoute("defaultRoute", "", "~/Index.aspx")

        'routes.MapPageRoute("", "portfolio/{CatName}/{Title_En}/{ID}", "~/Portfolio.aspx")
        'routes.MapPageRoute("", "portfolios", "~/Portfolio.aspx")
        routes.MapPageRoute("", "portfolios", "~/Portf.aspx")
        routes.MapPageRoute("", "portfolio", "~/portfolio.aspx")
        routes.MapPageRoute("", "{Action}/{CatName}/{Title_En}/{ID}", "~/PostView.aspx")
        routes.MapPageRoute("", "{Action}/{Title_En}/{ID}", "~/PostView.aspx")
        routes.MapPageRoute("", "about/{Person}", "~/About.aspx")
        routes.MapPageRoute("", "about", "~/About.aspx")
        routes.MapPageRoute("", "result/{Search}", "~/Search.aspx")
        routes.MapPageRoute("", "contact-us", "~/ContactUs.aspx")
        routes.MapPageRoute("", "contact", "~/ContactUs.aspx")
        routes.MapPageRoute("", "faq", "~/FAQ.aspx")
        routes.MapPageRoute("", "faq/{CatName}", "~/FAQ.aspx")
        routes.MapPageRoute("", "order", "~/OrderWebsite.aspx")
        routes.MapPageRoute("", "edu-account-signup", "~/StudentSignupWebsite.aspx")
        routes.MapPageRoute("", "index", "~/Index.aspx")
        routes.MapPageRoute("", "home", "~/Index.aspx")
        routes.MapPageRoute("", "login", "~/Login.aspx")
        routes.MapPageRoute("", "posts", "~/Posts.aspx")
        'routes.MapPageRoute("", "Posts", "~/Posts/All")
        routes.MapPageRoute("", "posts/{CatName}", "~/Posts.aspx")
        routes.MapPageRoute("", "terms/{Type}", "~/Terms.aspx")
        routes.MapPageRoute("", "terms", "~/Terms.aspx")
        routes.MapPageRoute("", "news/{CatName}", "~/News.aspx")
        routes.MapPageRoute("", "news", "~/News.aspx")
        routes.MapPageRoute("", "login", "~/Login.aspx")
        routes.MapPageRoute("", "error", "~/ErrorPage.aspx")
        routes.MapPageRoute("", "gallery", "~/Gallery.aspx")
        routes.MapPageRoute("", "signin", "~/SignIn.aspx")
        routes.MapPageRoute("", "checkout", "~/ForgotPass.aspx")
        '@* ---------------------------------------------------------------------Arabic------------------------
        'routes.MapPageRoute("", "PostViewAr", "~/PostViewAr.aspx")
        'routes.MapPageRoute("", "ResultAr", "~/SearchAr.aspx")
        'routes.MapPageRoute("", "FAQAr", "~/FAQAr.aspx")
        'routes.MapPageRoute("", "IndexAr", "~/IndexAr.aspx")
        'routes.MapPageRoute("", "PostsAr", "~/PostsAr.aspx")
        'routes.MapPageRoute("", "LoginAr", "~/Login.aspx")
        'routes.MapPageRoute("", "ErrorAr", "~/ErrorPageAr.aspx")
        'routes.MapPageRoute("", "GalleryAr", "~/GalleryAr.aspx")
        '@* ---------------------------------------------------------------------English----------------------
        routes.MapPageRoute("", "portfolios-en", "~/En/Portf.aspx")
        routes.MapPageRoute("", "portfolio-en", "~/En/portfolio.aspx")
        routes.MapPageRoute("", "{Action}/{CatName}/{Title_En}/en/{ID}", "~/En/PostView.aspx")
        routes.MapPageRoute("", "{Action}/{Title_En}/en/{ID}", "~/En/PostView.aspx")
        routes.MapPageRoute("", "about-en/{Person}", "~/En/About.aspx")
        routes.MapPageRoute("", "about-en", "~/En/About.aspx")
        routes.MapPageRoute("", "result-en/{Search}", "~/En/Search.aspx")
        routes.MapPageRoute("", "contact-us-en", "~/En/ContactUs.aspx")
        routes.MapPageRoute("", "contact-en", "~/En/ContactUs.aspx")
        routes.MapPageRoute("", "faq-en", "~/En/FAQ.aspx")
        routes.MapPageRoute("", "faq-en/{CatName}", "~/En/FAQ.aspx")
        routes.MapPageRoute("", "order-en", "~/En/OrderWebsite.aspx")
        routes.MapPageRoute("", "index-en", "~/En/Index.aspx")
        routes.MapPageRoute("", "home-en", "~/En/Index.aspx")
        routes.MapPageRoute("", "login-en", "~/En/Login.aspx")
        routes.MapPageRoute("", "posts-en", "~/En/Posts.aspx")
        'routes.MapPageRoute("", "Posts", "~/Posts/All")
        routes.MapPageRoute("", "posts-en/{CatName}", "~/En/Posts.aspx")
        routes.MapPageRoute("", "terms-en/{Type}", "~/En/Terms.aspx")
        routes.MapPageRoute("", "terms-en", "~/En/Terms.aspx")
        routes.MapPageRoute("", "news-en/{CatName}", "~/En/News.aspx")
        routes.MapPageRoute("", "news-en", "~/En/News.aspx")
        routes.MapPageRoute("", "login-en", "~/En/Login.aspx")
        routes.MapPageRoute("", "error-en", "~/En/ErrorPage.aspx")
        routes.MapPageRoute("", "gallery-en", "~/En/Gallery.aspx")
        routes.MapPageRoute("", "signIn-en", "~/En/SigIn.aspx")
        routes.MapPageRoute("", "checkout-en", "~/En/ForgotPass.aspx")
        '@* ----------------------------------------------------------------------Control----------------------

    End Sub
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Application.Lock()
        Application("OnlineUsers") = Convert.ToInt64(Application("OnlineUsers")) + 1
        Application.UnLock()
        ' Code that runs when a new session is started
        Dim counter1 As Int64
        counter1 = Convert.ToInt64(Application("visToday")) + 1
        Application("visToday") = counter1
        Dim counter As Int64
        counter = Convert.ToInt64(Application("Vis")) + 1
        Application("Vis") = counter
        'Try
        '    Dim db = New LinqDBClassesDataContext
        '    Dim q = New Visitor
        '    q.AllVisitor = Application("Vis")
        '    q.Today = Application("visToday")
        '    db.Visitors.InsertOnSubmit(q)
        '    db.SubmitChanges()

        'Catch ex As Exception
        'End Try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Application.Lock()
        Application("OnlineUsers") = Convert.ToInt64(Application("OnlineUsers")) - 1
        Application.UnLock()
    End Sub

</script>
