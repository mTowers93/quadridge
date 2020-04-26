using Quadridge2.Models;
using Quadridge2.Models.Contacts;
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
            sb.Append("<input type='"+ inputType + "' id='" + name + "AddModal' class='form-control' />");
            sb.Append("</form>");
            sb.Append("</div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' class='btn btn-primary' id='save" + name + "'>Submit</button>");
            sb.Append("<button type='button' class='btn btn-primary' data-dismiss='modal'>Hide</button>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");    
            sb.Append("</div>");


            return new HtmlString(sb.ToString());
        }

        public static IHtmlString DeleteModal (this HtmlHelper html, string name)
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
            sb.Append("<p>Are you sure you want to delete this " + name + "?</p>");
            sb.Append("</div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='button' id='yes' class='btn btn-primary'>Yes</button>");
            sb.Append("<button type='button' class='btn btn-primary' data-dismiss='modal'>No</button>");
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
            sb.Append("<label for='editModalText'>"+ label + "</label>");
            sb.Append("<input type='text' id='editModalText' class='form-control' />");
            sb.Append("</form>");
            sb.Append("</div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' class='btn btn-primary save" + name +"'>Submit</button>");
            sb.Append("<button type='button' class='btn btn-primary' data-dismiss='modal'>Hide</button>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString ContactsModal(this HtmlHelper html, ICollection<Contact> contacts, string controller, string action, string id)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='modal fade' id='contactsModal' role='dialog'>");
            sb.Append("<div class='modal-dialog modal-lg'>");
            sb.Append("<form action='/" + controller + "/" + action + "/" + id +"' method='post'>");
            sb.Append("<div class='modal-content'>");
            sb.Append("<div class='modal-header'>");
            sb.Append("<h4 class='modal-title'>Choose Contacts</h4>");
            sb.Append("<button type='button' class='close' data-dismiss='modal'>&times;</button>");
            sb.Append("</div>");
            sb.Append("<div class='modal-body'>");
            sb.Append("<table class='display table table-light table-bordered'>");
            sb.Append("<thead class='thead-light'><tr>");
            sb.Append("<th>Name</th><th>Select</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            foreach(var contact in contacts)
            {
                sb.Append("<tr><td>" + contact.Fullname + "</td>");
                sb.Append("<td><input type=checkbox name='contacts' id ='check_" + contact.Id + "' value = '" + contact.Id + "' /></td></tr>");
            };
            sb.Append("</tbody></table></div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' class='btn btn-default'>Submit</button>");
            sb.Append("<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>");
            sb.Append("</div></div></form></div></div>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString TrustsModal(this HtmlHelper html, ICollection<Trust> trusts, string controller, string action, string id)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='modal fade' id='trustsModal' role='dialog'>");
            sb.Append("<div class='modal-dialog modal-lg'>");
            sb.Append("<form action='/" + controller + "/" + action + "/" + id + "' method='post'>");
            sb.Append("<div class='modal-content'>");
            sb.Append("<div class='modal-header'>");
            sb.Append("<h4 class='modal-title'>Choose Trusts</h4>");
            sb.Append("<button type='button' class='close' data-dismiss='modal'>&times;</button>");
            sb.Append("</div>");
            sb.Append("<div class='modal-body'>");
            sb.Append("<table class='display table table-light table-bordered'>");
            sb.Append("<thead class='thead-light'><tr>");
            sb.Append("<th>Name</th><th>Select</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            foreach (var trust in trusts)
            {
                sb.Append("<tr><td>" + trust.Name + "</td>");
                sb.Append("<td><input type=checkbox name='trusts' id ='check_" + trust.Id + "' value = '" + trust.Id + "' /></td></tr>");
            };
            sb.Append("</tbody></table></div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' class='btn btn-default'>Submit</button>");
            sb.Append("<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>");
            sb.Append("</div></div></form></div></div>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString CompaniesModal(this HtmlHelper html, ICollection<Company> companies, string controller, string action, string id)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='modal fade' id='companiesModal' role='dialog'>");
            sb.Append("<div class='modal-dialog modal-lg'>");
            sb.Append("<form action='/" + controller + "/" + action + "/" + id + "' method='post'>");
            sb.Append("<div class='modal-content'>");
            sb.Append("<div class='modal-header'>");
            sb.Append("<h4 class='modal-title'>Choose Companies</h4>");
            sb.Append("<button type='button' class='close' data-dismiss='modal'>&times;</button>");
            sb.Append("</div>");
            sb.Append("<div class='modal-body'>");
            sb.Append("<table class='display table table-light table-bordered'>");
            sb.Append("<thead class='thead-light'><tr>");
            sb.Append("<th>Name</th><th>Select</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            foreach (var company in companies)
            {
                sb.Append("<tr><td>" + company.Name + "</td>");
                sb.Append("<td><input type=checkbox name='companies' id ='check_" + company.Id + "' value = '" + company.Id + "' /></td></tr>");
            };
            sb.Append("</tbody></table></div>");
            sb.Append("<div class='modal-footer'>");
            sb.Append("<button type='submit' class='btn btn-default'>Submit</button>");
            sb.Append("<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>");
            sb.Append("</div></div></form></div></div>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString EditDeleteLine (this HtmlHelper html, int id, string name, string dataName)
        {
            var sb = new StringBuilder();
            sb.Append("<td><button class='btn btn-info edit' data-target='#editModal' ");
            var str = String.Format("data-toggle='modal' onclick='editGroupName(\'{0}', '{1}'); return false;'>Edit</button>", id, name);
            sb.Append(str);
            sb.Append("<button data-target='#deleteModal' data-toggle='modal' class='btn btn-danger delete'");
            sb.Append("data-" + dataName + "-id="+ id + " data-target='#confirmDelete'><i class='fa fa-trash-o fa-lg'></i></button></td>");
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