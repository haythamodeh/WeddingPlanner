#pragma checksum "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43f286ca4ffb0d653cad31ad1c48321a6c2b1f53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_dashboard), @"mvc.1.0.view", @"/Views/Home/dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/dashboard.cshtml", typeof(AspNetCore.Views_Home_dashboard))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43f286ca4ffb0d653cad31ad1c48321a6c2b1f53", @"/Views/Home/dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Wedding>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 123, true);
            WriteLiteral("<div class=\"center jumbotron\">\n    <h2 class=\"text-success\" style=\"display: inline-block;\">Welcome to the Wedding Planner, ");
            EndContext();
            BeginContext(145, 22, false);
#line 3 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
                                                                                       Write(ViewBag.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(167, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(169, 21, false);
#line 3 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
                                                                                                               Write(ViewBag.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(190, 303, true);
            WriteLiteral(@"</h2>
    <a class=""btn btn-danger logout"" style=""float:right;"" href=""/logout"">Logout</a>
</div>
<table class=""table"">
  <thead>
    <tr>
      <th scope=""col"">Wedding</th>
      <th scope=""col"">Date</th>
      <th scope=""col"">Guest</th>
      <th scope=""col"">Action</th>
    </tr>
  </thead>
  <tbody>
");
            EndContext();
#line 16 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
        
        foreach(var w in @Model)
        {

#line default
#line hidden
            BeginContext(545, 31, true);
            WriteLiteral("          <tr>\n          <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 576, "\"", 608, 2);
            WriteAttributeValue("", 583, "view/wedding/", 583, 13, true);
#line 20 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
WriteAttributeValue("", 596, w.WeddingID, 596, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(609, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(611, 11, false);
#line 20 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
                                             Write(w.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(622, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(626, 11, false);
#line 20 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
                                                            Write(w.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(637, 24, true);
            WriteLiteral("</a></td>\n          <td>");
            EndContext();
            BeginContext(662, 33, false);
#line 21 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
         Write(w.Date.ToString("MMMM, dd, yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(695, 20, true);
            WriteLiteral("</td>\n          <td>");
            EndContext();
            BeginContext(716, 17, false);
#line 22 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
         Write(w.AllGuests.Count);

#line default
#line hidden
            EndContext();
            BeginContext(733, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 23 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
           if(w.UserID == ViewBag.User.UserID)
          {

#line default
#line hidden
            BeginContext(798, 41, true);
            WriteLiteral("            <td><a class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 839, "\"", 874, 2);
            WriteAttributeValue("", 846, "/delete/wedding/", 846, 16, true);
#line 25 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
WriteAttributeValue("", 862, w.WeddingID, 862, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(875, 17, true);
            WriteLiteral(">Delete</a></td>\n");
            EndContext();
#line 26 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
          }else if(w.UserID != ViewBag.User.UserID && !w.AllGuests.Any(u => u.UserID == ViewBag.User.UserID))
          {

#line default
#line hidden
            BeginContext(1014, 42, true);
            WriteLiteral("            <td><a class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1056, "\"", 1089, 2);
            WriteAttributeValue("", 1063, "/rsvp/wedding/", 1063, 14, true);
#line 28 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
WriteAttributeValue("", 1077, w.WeddingID, 1077, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1090, 15, true);
            WriteLiteral(">RSVP</a></td>\n");
            EndContext();
#line 29 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
          }else {

#line default
#line hidden
            BeginContext(1123, 42, true);
            WriteLiteral("            <td><a class=\"btn btn-warning\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1165, "\"", 1200, 2);
            WriteAttributeValue("", 1172, "/unrsvp/wedding/", 1172, 16, true);
#line 30 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
WriteAttributeValue("", 1188, w.WeddingID, 1188, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1201, 18, true);
            WriteLiteral(">Un-RSVP</a></td>\n");
            EndContext();
#line 31 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
          }

#line default
#line hidden
            BeginContext(1231, 16, true);
            WriteLiteral("          </tr>\n");
            EndContext();
#line 33 "/Users/HOdehLion/Desktop/c#/orms/WeddingPlanner/Views/Home/dashboard.cshtml"
        }
      

#line default
#line hidden
            BeginContext(1265, 103, true);
            WriteLiteral("  </tbody>\n</table>\n<a class=\"btn btn-primary\" style=\"float:right;\" href=\"/wedding/new\">New Wedding</a>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Wedding>> Html { get; private set; }
    }
}
#pragma warning restore 1591
