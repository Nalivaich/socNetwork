using System.Web;
using System.Web.Optimization;

namespace socNetworkWebApi
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/bower_components/css").Include(
                       "~/Content/bower_components/uploadImages/css/*.css",
                       "~/Content/bower_components/bootstrap/dist/css/bootstrap.css"
           ));

            bundles.Add(new ScriptBundle("~/Content/app/css").Include(
                        "~/Content/app/css/*.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/Content/bower_components/js").Include(
                        "~/Content/bower_components/angular/angular.js",
                        "~/Content/bower_components/angular-animate/angular-animate.js",
                        "~/Content/bower_components/angular-ui-router/release/angular-ui-router.js",
                        "~/Content/bower_components/angular/ngular-route.js",
                        "~/Content/bower_components/angular/angular-resource.js",
                        "~/Content/bower_components/bootstrap/dist/js/bootstrap.js",
                        "~/Content/bower_components/ui-bootstrap/ui-bootstrap-0.13.1.js",
                        "~/Content/bower_components/ui-bootstrap/ui-bootstrap-tpls-0.13.1.js",
                        "~/Content/bower_components/uploadImages/js/jquery.ui.widget.js",
                        "~/Content/bower_components/uploadImages/js/load-image.all.js",
                        "~/Content/bower_components/uploadImages/js/canvas-to-blob.js",
                        "~/Content/bower_components/uploadImages/js/jquery.blueimp-gallery.js",
                        "~/Content/bower_components/uploadImages/js/jquery.iframe-transport.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload-process.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload-image.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload-audio.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload-video.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload-validate.js",
                        "~/Content/bower_components/uploadImages/js/jquery.fileupload-angular.js"
                        ));

            bundles.Add(new ScriptBundle("~/Content/app").Include(
                        "~/Content/app/app.js",

                        "~/Content/app/models/*.js",

                        "~/Content/app/services/*.js",

                        "~/Content/app/controllers/appController.js",
                        "~/Content/app/controllers/createAlbumController.js",
                        "~/Content/app/controllers/headerController.js",
                        "~/Content/app/controllers/LogInController.js",
                        "~/Content/app/controllers/manageAlbumController.js",
                        "~/Content/app/controllers/personalRoomController.js",
                        "~/Content/app/controllers/registrationController.js",
                        "~/Content/app/controllers/searchUserController.js",
                        "~/Content/app/controllers/userListController.js",
                        "~/Content/app/controllers/viewAlbumController.js",
                        "~/Content/app/controllers/createPostController.js",
                        "~/Content/app/controllers/fileUploadController.js",
                        "~/Content/app/controllers/fileDestroyController.js",
                        "~/Content/app/controllers/viewUserImagesController.js"
                        ));
        }


    }
}