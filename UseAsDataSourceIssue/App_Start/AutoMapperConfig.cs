using System;
using AutoMapper;
using UseAsDataSourceIssue.Domain;
using UseAsDataSourceIssue.Models;

namespace UseAsDataSourceIssue {
    public static class AutoMapperConfig {
        private static Lazy<MapperConfiguration> _configuration = new Lazy<MapperConfiguration>(() => {
            MapperConfiguration config = new MapperConfiguration(c => {
                //with this, I get an Argument types do not match
                c.CreateMap<Order, OrderModel>();
                c.CreateMap<DateTime, DateTimeOffset>();
                c.CreateMap<DateTime?, DateTimeOffset?>();

                //with this, I get an Expression of type 'System.DateTime' cannot be used for constructor parameter of type 'System.DateTimeOffset'
                //c.CreateMap<Order, OrderModel>().ForMember(x => x.OrderDate, o => o.Ignore());
                //c.CreateMap<DateTime, DateTimeOffset>();
                //c.CreateMap<DateTime?, DateTimeOffset?>();

                //with this, I get an Argument types do not match
                //c.CreateMap<Order, OrderModel>();
                //c.CreateMap<DateTime, DateTimeOffset>().ConvertUsing(x => (DateTimeOffset)x);
                //c.CreateMap<DateTime?, DateTimeOffset?>().ConvertUsing(x => (DateTimeOffset?)x);

                //with this, I get an Expression of type 'System.DateTime' cannot be used for constructor parameter of type 'System.DateTimeOffset'
                //c.CreateMap<Order, OrderModel>().ForMember(x => x.OrderDate, o => o.Ignore());
                //c.CreateMap<DateTime, DateTimeOffset>().ConvertUsing(x => (DateTimeOffset)x);
                //c.CreateMap<DateTime?, DateTimeOffset?>().ConvertUsing(x => (DateTimeOffset?)x);

                //with this, I get the full mapping to work. 
                //But, if I do $select=OrderDate, it throws a "Rewritten expression calls operator method 'System.DateTimeOffset op_Implicit(System.DateTime)', but the original node had no operator method. If this is is intentional, override 'VisitUnary' and change it to allow this rewrite."
                //If I do a $select=ShipDate, it throws a Argument types do not match
                //c.CreateMap<Order, OrderModel>();
                //c.CreateMap<DateTime, DateTimeOffset>().ProjectUsing(x => (DateTimeOffset)x);
                //c.CreateMap<DateTime?, DateTimeOffset?>().ProjectUsing(x => (DateTimeOffset?)x);

                //with this, I get the full mapping to work. 
                //But, if I do $select=OrderDate, it throws a "Rewritten expression calls operator method 'System.DateTimeOffset op_Implicit(System.DateTime)', but the original node had no operator method. If this is is intentional, override 'VisitUnary' and change it to allow this rewrite."
                //If I do a $select=ShipDate, it throws a Argument types do not match
                //c.CreateMap<Order, OrderModel>().ForMember(x => x.OrderDate, o => o.Ignore());
                //c.CreateMap<DateTime, DateTimeOffset>().ProjectUsing(x => (DateTimeOffset)x);
                //c.CreateMap<DateTime?, DateTimeOffset?>().ProjectUsing(x => (DateTimeOffset?)x);
            });
            config.CompileMappings();
            return config;
        });

        public static MapperConfiguration GetConfiguration() {
            return _configuration.Value;
        }
    }
}