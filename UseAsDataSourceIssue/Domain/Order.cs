using System;

namespace UseAsDataSourceIssue.Domain {
    public class Order {
        public string CompanyName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
    }
}