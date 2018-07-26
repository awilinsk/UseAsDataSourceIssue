using System;
using System.ComponentModel.DataAnnotations;

namespace UseAsDataSourceIssue.Models {
    public class OrderModel {
        public string CompanyName { get; set; }
        [Key]
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? ShipDate { get; set; }
    }
}