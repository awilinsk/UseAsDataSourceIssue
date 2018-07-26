using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNet.OData;
using UseAsDataSourceIssue.Domain;
using UseAsDataSourceIssue.Models;

namespace UseAsDataSourceIssue.Controllers {
    public class OrdersController : ODataController {
        private IMapper _mapper;
        private OrderRepository _orderRepository;

        public OrdersController() {
            this._orderRepository = new OrderRepository();
            this._mapper = new Mapper(AutoMapperConfig.GetConfiguration());
        }

        [EnableQuery]
        [ResponseType(typeof(IEnumerable<OrderModel>))]
        public async Task<IHttpActionResult> Get() {
            try {
                return this.Ok(this._orderRepository.Query().UseAsDataSource(this._mapper).For<OrderModel>());

                //this works, but is not utilizing the odata query options and expression mapping
                //return this.Ok(this._orderRepository.All().Select(this._mapper.Map<Order, OrderModel>));
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        [EnableQuery]
        [ResponseType(typeof(OrderModel))]
        public async Task<IHttpActionResult> Get([FromODataUri] int key) {
            return this.Ok(SingleResult.Create(this._orderRepository.Query().Where(x => (x.OrderId == key)).UseAsDataSource(this._mapper).For<OrderModel>()));
        }
    }
}