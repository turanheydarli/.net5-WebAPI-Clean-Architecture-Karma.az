using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Order : IEntity
	{
		public int Id { get; set; }
		public string TrackingNumber { get; set; }
		public User Customer { get; set; }
		public int CustomerId { get; set; }
		public string CustomerContact { get; set; }
		public OrderStatus Status { get; set; }
		public decimal Amount { get; set; }
		public decimal? SalesTax { get; set; }
		public decimal? PaidTotal { get; set; }
		public decimal? Total { get; set; }
		public int? ParentId { get; set; }
		public Order Parent { get; set; }
		public int? ShopId { get; set; }
		public Shop Shop { get; set; }
		public decimal? Discount { get; set; }
		public string PaymentId { get; set; }
		public string PaymentGateway { get; set; }
		public string ShippingAddress { get; set; }
		public string BillingAddress { get; set; }
		public int? LogisticsProvider { get; set; }
		public decimal? DeliveryFee { get; set; }
		public string DeliveryTime { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public DateTime DeletedAt { get; set; }



	}
}
