using System;
using System.Collections.Generic;
using System.Linq;

namespace UseAsDataSourceIssue.Domain {
    public class OrderRepository {
        private IList<Order> _orders;

        public OrderRepository() {
            this._orders = new List<Order>() {
                new Order() {OrderId = 1, CompanyName = "Company 1", OrderDate = new DateTime(2018, 7, 2), ShipDate = null},
                new Order() {OrderId = 2, CompanyName = "Company 2", OrderDate = new DateTime(2018, 3, 23), ShipDate = new DateTime(2018, 4, 12)},
                new Order() {OrderId = 3, CompanyName = "Company 3", OrderDate = new DateTime(2018, 6, 30), ShipDate = null}
            };
        }

        public IEnumerable<Order> All() {
            return this._orders;
        }
        public IQueryable<Order> Query() {
            return this._orders.AsQueryable();
        }
    }
}