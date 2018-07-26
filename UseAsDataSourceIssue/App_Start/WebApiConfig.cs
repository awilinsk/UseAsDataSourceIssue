using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using UseAsDataSourceIssue.Models;

namespace UseAsDataSourceIssue
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<OrderModel>("Orders");
            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
        }
    }
}
