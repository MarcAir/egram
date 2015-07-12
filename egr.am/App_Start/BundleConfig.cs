namespace egr.am
{
    using System.Web.Optimization;
    using egr.am.Constants;

    public static class BundleConfig
    {
        /// <summary>
        /// For more information on bundling, visit <see cref="http://go.microsoft.com/fwlink/?LinkId=301862"/>.
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Enable Optimizations
            // Set EnableOptimizations to false for debugging. For more information,
            // Web.config file system.web/compilation[debug=true]
            // OR
            // BundleTable.EnableOptimizations = true;

            // Enable CDN usage. 
            // Note: that you can choose to remove the CDN if you are developing an intranet application.
            // Note: We are using Google's CDN where possible and then Microsoft if not available for better 
            //       performance (Google is more likely to have been cached by the users browser).
            // Note: that protocol (http:) is omitted from the CDN URL on purpose to allow the browser to choose the protocol.
            bundles.UseCdn = true;

            AddCss(bundles);
            AddJavaScript(bundles);
        }


        private static void AddCss(BundleCollection bundles)
        {
            // foundation - zurb foundation CSS (http://foundation.zurb.com/docs/using-sass.html).
            //http://www.jsdelivr.com/#!foundation cdn update
            // Font Awesome - Icons using font (http://fortawesome.github.io/Font-Awesome/).
            // Note: If you host any of your CSS on a separate domain (Like a CDN), then be sure to fix an issue with 
            //       respond.js which stops working for IE8.
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 // "~/Content/fontawesome/site.css",
                  "~/Content/Site.css"));

        }

        /// <summary><link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">

        /// Creates and adds JavaScript bundles to the bundle collection. Content Delivery Network's (CDN) are used 
        /// where available. 
        /// 
        /// Note: MVC's built in <see cref="System.Web.Optimization.Bundle.CdnFallbackExpression"/> is not used as 
        /// using in-line scripts is not permitted under Content Security Policy (CSP) (See <see cref="FilterConfig"/> 
        /// for more details).
        /// 
        /// Instead, we create our own failover bundles. If a CDN is not reachable, the failover script loads the local 
        /// bundles instead. The failover script is only a few lines of code and should have a minimal impact, although 
        /// it does add an extra request (Two if the browser is IE8 or less). If you feel confident in the CDN 
        /// availability and prefer better performance, you can delete these lines.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        private static void AddJavaScript(BundleCollection bundles)
        {
            // jQuery - The JavaScript helper API (http://jquery.com/).
            Bundle jqueryBundle = new ScriptBundle("~/bundles/jquery", ContentDeliveryNetwork.Google.JQueryUrl)
                .Include("~/Scripts/jquery-{version}.js");
            bundles.Add(jqueryBundle);

            // jQuery Validate - Client side JavaScript form validation (http://jqueryvalidation.org/).
            Bundle jqueryValidateBundle = new ScriptBundle(
                "~/bundles/jqueryval",
                ContentDeliveryNetwork.Microsoft.JQueryValidateUrl)
                .Include("~/Scripts/jquery.validate*");
            bundles.Add(jqueryValidateBundle);

            // Microsoft jQuery Validate Unobtrusive - Validation using HTML data- attributes 
            // http://stackoverflow.com/questions/11534910/what-is-jquery-unobtrusive-validation
            Bundle jqueryValidateUnobtrusiveBundle = new ScriptBundle(
                "~/bundles/jqueryvalunobtrusive",
                ContentDeliveryNetwork.Microsoft.JQueryValidateUnobtrusiveUrl)
                .Include("~/Scripts/jquery.validate*");
            bundles.Add(jqueryValidateUnobtrusiveBundle);

            // Modernizr - Allows you to check if a particular API is available in the browser (http://modernizr.com).
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            // Note: The current version of Modernizr does not support Content Security Policy (CSP) (See FilterConfig).
            // See here for details: https://github.com/Modernizr/Modernizr/pull/1263 and 
            // http://stackoverflow.com/questions/26532234/modernizr-causes-content-security-policy-csp-violation-errors
            Bundle modernizrBundle = new ScriptBundle(
                "~/bundles/modernizr",
                ContentDeliveryNetwork.Microsoft.ModernizrUrl)
                .Include("~/Scripts/modernizr-*");
            bundles.Add(modernizrBundle);

            // foundation - zurb foundation CSS (http://foundation.zurb.com/docs/using-sass.html).
            //http://www.jsdelivr.com/#!foundation cdn update
            Bundle foundationBundle = new ScriptBundle("~/bundles/foundation", "//cdn.jsdelivr.net/foundation/5.5.1/js/foundation/foundation.js")
                .Include("~/Scripts/foundation/foundation.js");
            bundles.Add(foundationBundle);

            // foundation - zurb foundation CSS (http://foundation.zurb.com/docs/using-sass.html).
            //http://www.jsdelivr.com/#!foundation cdn update
            Bundle foundationoffcanvasBundle = new ScriptBundle("~/bundles/foundation.offcanvas", "//cdn.jsdelivr.net/foundation/5.5.1/js/foundation/foundation.offcanvas.js")
                .Include("~/Scripts/foundation/foundation.offcanvas.js");
            bundles.Add(foundationoffcanvasBundle);

            // Respond.js - A fast & lightweight polyfill for min/max-width CSS3 Media Queries 
            // https://github.com/scottjehl/Respond. 
            // Note: that the CDN version is a little behind the latest 1.4.2.
            Bundle respondBundle = new ScriptBundle("~/bundles/respond", ContentDeliveryNetwork.Microsoft.RespondUrl)
                .Include("~/Scripts/respond.js");
            bundles.Add(respondBundle);

            // Failover Core - If the CDN's fail then these scripts load local copies of the same scripts.
            Bundle failoverCoreBundle = new ScriptBundle("~/bundles/failovercore")
                .Include("~/Scripts/Failover/jquery.js")
                .Include("~/Scripts/Failover/jqueryval.js")
                .Include("~/Scripts/Failover/jqueryvalunobtrusive.js");
            bundles.Add(failoverCoreBundle);

            // Failover Respond - If the Respond.js CDN fails then this script loads a local copy. 
            // Note: This script is only used if the browser is running IE8 or less.
            Bundle failoverRespondBundle = new ScriptBundle("~/bundles/failoverrespond")
                .Include("~/Scripts/Failover/respond.js");
            bundles.Add(failoverRespondBundle);
        }
    }
}
