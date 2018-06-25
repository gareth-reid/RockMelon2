using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using RockMelon.Tools.Models;

namespace RockMelon.Tools.Helpers
{
    /// <summary>
    /// This is cool but downloads all images initially
    /// Should be used for relatvely small lists or single items
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// Shows the thumbnail of an image and then shows full when hover or click
        /// Helper when using path
        /// </summary>
        /// <param name="html"></param>
        /// <param name="imgPath">path pointing to image</param>
        /// <param name="title">title of popover</param>
        /// <param name="spanType">width of thumbnail -in twitter bootstrapper terms i.e. span1</param>
        /// <param name="leftOrRight">left or right of thumbnail</param>
        /// <param name="linkId">link for thumbnail</param>
        /// <returns></returns>
        public static MvcHtmlString ImageHoverViewer(this HtmlHelper html, string imgPath, string title, string spanType = "span1", string leftOrRight = "left", string linkId = "image-display")
        {
            return ImageHoverViewer(spanType, leftOrRight, linkId, imgPath, title);
        }

        /// <summary>
        /// Shows the thumbnail of an image and then shows full when hover or click
        /// Helper when using byte array
        /// </summary>
        /// <param name="html"></param>
        /// <param name="imgArray">byte array containing image data</param>
        /// <param name="title">title of popover</param>
        /// <param name="spanType">width of thumbnail -in twitter bootstrapper terms i.e. span1</param>
        /// <param name="leftOrRight">left or right of thumbnail</param>
        /// <param name="linkId">link for thumbnail</param>
        /// <returns></returns>
        public static MvcHtmlString ImageHoverViewer(this HtmlHelper html, byte[] imgArray, string title, string spanType = "span1", string leftOrRight = "left", string linkId = "image-display")
        {
            string imageBase64 = Convert.ToBase64String(imgArray);
            string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);

            return ImageHoverViewer(spanType, leftOrRight, linkId, imageSrc, title);
        }

        private static MvcHtmlString ImageHoverViewer(string spanType, string leftOrRight, string linkId, string imageSrc, string title)
        {
            var sb = new StringBuilder();
            sb.Append("<ul class='thumbnails'>");
            sb.Append("<li class='{2}'>");
            sb.Append("<div class='thumbnail'>");
            sb.Append("<a href='javascript:imageClick();' class='thumbnail' data-placement='{3}' id='{4}' rel='popover' data-content='<img src=\"{0}\"/>' data-original-title='{1}'>");
            sb.Append("<img src='{0}' alt='Image'>");
            sb.Append("</a></span></div></li></ul>");
            sb.Append("<script>function imageClick(){5}</script>");
            return new MvcHtmlString(String.Format(sb.ToString(), imageSrc, title, spanType, leftOrRight, linkId, "{$('#" + linkId + "').popover('hide'); return false;}"));
        }

        /// <summary>
        /// Adds add new, edit etc. to a grid
        /// Author: Gareth reid
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <param name="html"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static MvcHtmlString GridTools<TM>(this HtmlHelper<TM> html, object routeValues) where TM : ListModel
        {
            var sb = new StringBuilder();
            sb.Append("<div class='span12'>");
            sb.Append(html.DisplayFor(m => m.GridState));
            sb.Append("</div>");
            sb.Append("<div class='span12'>");
            sb.Append(html.ActionLink("Add New", "Edit", routeValues));
            sb.Append("</div>");
            return new MvcHtmlString(sb.ToString());
        }
        
        /// <summary>
        /// Generats a download link for an image
        /// Author: Gareth reid
        /// </summary>
        /// <param name="html"></param>
        /// <param name="action"></param>
        /// <param name="downloadImage"></param>
        /// <returns></returns>
        public static MvcHtmlString DownloadLink(this HtmlHelper html, string action, string downloadImage) 
        {
            var htmlString = String.Format("<a href='{0}'><img src='/Content/Images/{1}' title='Download Current Dates' alt='Download'/></a>", action, downloadImage);
            return new MvcHtmlString(htmlString);
        }

        /// <summary>
        /// Generates a download link for an image and allows a js function to be called
        /// Author: Gareth reid
        /// </summary>
        /// <param name="html"></param>
        /// <param name="jsFunction"></param>
        /// <param name="downloadImage"></param>
        /// <returns></returns>
        public static MvcHtmlString DownloadLinkCallJsFunction(this HtmlHelper html, string jsFunction, string downloadImage)
        {
            var htmlString = String.Format("<a href='#' onClick='{0}'><img src='/Content/Images/{1}' title='Download Current Dates' alt='Download'/></a>", jsFunction, downloadImage);
            return new MvcHtmlString(htmlString);
        }

        /// <summary>
        /// Returns a message with an info icon
        /// Author: Gareth reid
        /// </summary>
       /// <param name="html"></param>
       /// <param name="message"></param>
       /// <param name="hideIfEmpty"></param>
       /// <returns></returns>
        public static MvcHtmlString Message(this HtmlHelper html, string message, bool hideIfEmpty = true)
        {
            if (hideIfEmpty && String.IsNullOrEmpty(message))
            {
                return new MvcHtmlString(String.Empty);
            }

            var htmlString = String.Format("<span class=\"message\">{0}</span>", message);
            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString DisplayForWithToolTip<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string toolTip)
        {
            var exp = (MemberExpression)expression.Body;
            var id = exp.Member.Name;
            var value = ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model;
            var name = ModelMetadata.FromLambdaExpression(expression, html.ViewData).DisplayName;

            var htmlValue = new StringBuilder();
            htmlValue.Append("<label class='strong' for='{0}'>{3}</label>");
            htmlValue.Append("<span id='{0}' Title='{2}'>{1}</span>");
            return MvcHtmlString.Create(String.Format(htmlValue.ToString(), id, value, toolTip, name));
        }
    }
}