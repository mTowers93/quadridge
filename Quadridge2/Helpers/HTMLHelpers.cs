using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Quadridge2.Helpers
{
    public static class HTMLHelpers
    {
        public static MvcHtmlString LiActionLink(this HtmlHelper html, string text, string action, string controller)
        {
            var context = html.ViewContext;
            if (context.Controller.ControllerContext.IsChildAction)
                context = html.ViewContext.ParentActionViewContext;
            var routeValues = context.RouteData.Values;
            var currentAction = routeValues["action"].ToString();
            var currentController = routeValues["controller"].ToString();

            var str = String.Format("<li role=\"presentation\"{0}>{1}</li>",
                currentAction.Equals(action, StringComparison.InvariantCulture) &&
                currentController.Equals(controller, StringComparison.InvariantCulture) ?
                " class=\"active\"" :
                String.Empty, html.ActionLink(text, action, controller).ToHtmlString()
            );
            return new MvcHtmlString(str);
        }

        public static IHtmlString AddNewModal(this HtmlHelper html, string name, string title, string label, string inputType="text")
        {

            var sb = new StringBuilder();
            var htmlString = String.Format("<div class='modal fade' id='add{0}' role='dialog'>",name);
            sb.Append(htmlString);
            sb.Append("<div class='modal-dialog modal-lg'>");
            sb.Append("<div class='modal-content'>");
            sb.Append("<div class='modal-header'>");
            htmlString = String.Format("<h4 class='modal-title'>{0}</h4>", title);
            sb.Append(htmlString);
            sb.Append("</div>");
            sb.Append("<div class='modal-body'>");
            sb.Append("<form id='" + name + "TypeForm'>");
            sb.Append("<label for=" + name + ">" + label + "</label>");
            sb.Append("<input type='"+ inputType + "' id='" + name + "' class='form-control' />");
            sb.Append("</form>");
            sb.Append("</div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' id='save" + name +"' class='btn btn-primary'>Submit</button>");
            sb.Append("<button type='button' id='btnHideModal' class='btn btn-primary'>Hide</button>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");    
            sb.Append("</div>");


            return new HtmlString(sb.ToString());
        }

        public static IHtmlString DeleteModal (this HtmlHelper html)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='modal fade' id='confirmDelete' role='dialog'>");
            sb.Append("<div class='modal-dialog modal-lg'>");
            sb.Append("<div class='modal-content'>");
            sb.Append("<div class='modal-header'>");
            sb.Append("<h4 class='modal-title'>Delete</h4>");
            sb.Append("</div>");
            sb.Append("<div class='modal-body'>");
            sb.Append("<form>");
            sb.Append("<input id='deleteId' type='hidden' value='' />");
            sb.Append("</form>");
            sb.Append("<p>Are you sure you want to delete this interaction type?</p>");
            sb.Append("</div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='button' id='yes' class='btn btn-primary'>Yes</button>");
            sb.Append("<button type='button' id='hideConfirmModal' class='btn btn-primary'>No</button>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return new HtmlString(sb.ToString());
        }

        public static HtmlString EditModal(this HtmlHelper html, string title, string label, string name)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='modal fade' id='editModal' role='dialog'>");
            sb.Append("<div class='modal-dialog modal-lg'>");
            sb.Append("<div class='modal-content'>");
            sb.Append("<div class='modal-header'>");
            sb.Append("<h4 class='modal-title'>Edit " + title + "</h4>");
            sb.Append("</div>");
            sb.Append("<div class='modal-body'>");
            sb.Append("<form id='editForm'>");
            sb.Append("<input type='hidden' value='' id='editId' />");
            sb.Append("<label for='InteractionType'>InteractionType Name</label>");
            sb.Append("<input type='text' id='editModalText' class='form-control' />");
            sb.Append("</form>");
            sb.Append("</div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' id='save" + name + " class='btn btn-primary'>Submit</button>");
            sb.Append("<button type='button' id='btnHideEditModal' class='btn btn-primary'>Hide</button>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

        public static string IsActive(this HtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "active" : "";
        }
    }
}