﻿using Newtonsoft.Json.Converters;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;


namespace DpdWebApi
{
    public static class WebApiConfig
    {
        public const string DEFAULT_ROUTE_NAME = "MyDefaultRoute";
        public static readonly string UriPathExtensionKey = "ext";
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "ApiMultiParamPathExtension ID",
               routeTemplate: "api-v1/{controller}/{din}/{brandname}/{company}/{lang}.{ext}",
               defaults: new { din = RouteParameter.Optional, brandname = RouteParameter.Optional, company = RouteParameter.Optional, lang = RouteParameter.Optional, ext = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
               name: "ApiTwoUriPathExtension ID",
               routeTemplate: "api-v1/{controller}/{lang}.{ext}",
               defaults: new { lang = RouteParameter.Optional, ext = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
                name: "ApiUriPathExtension ID",
                routeTemplate: "api-v1/{controller}/{lang}/{id}.{ext}",
                defaults: new { lang = RouteParameter.Optional, id = RouteParameter.Optional, ext = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api-v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            config.Formatters.JsonFormatter.SupportedEncodings.Add(Encoding.GetEncoding("utf-8"));
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
