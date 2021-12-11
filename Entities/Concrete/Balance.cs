using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Balance : IEntity
	{
		public int Id { get; set; }
		public int ShopId { get; set; }
		public Shop Shop { get; set; }
		public decimal AdminCommissionRate { get; set; }
		public decimal TotalEarnings { get; set; }
		public decimal WithdrawnAmount { get; set; }
		public decimal CurrentBalance { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int? PaymentInfoId { get; set; }
		public PaymentInfo PaymentInfo { get; set; }

	}
}
