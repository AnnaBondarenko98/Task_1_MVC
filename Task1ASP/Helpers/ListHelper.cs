using System.Collections.Generic;
using System.Web.Mvc;

namespace Task1ASP.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, IEnumerable<string> items)
        {
            var ul = new TagBuilder("ul");

            foreach (var item in items)
            {
                var li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }

            return new MvcHtmlString(ul.ToString());
        }
    }
}