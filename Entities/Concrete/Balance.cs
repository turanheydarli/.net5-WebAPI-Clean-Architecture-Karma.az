using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Balance : BaseEntity, IEntity
	{
		public Shop Shop { get; set; }
		public decimal AdminCommissionRate { get; set; }
		public decimal TotalEarnings { get; set; }
		public decimal WithdrawnAmount { get; set; }
		public decimal CurrentBalance { get; set; }
		public PaymentInfo PaymentInfo { get; set; }

	}
}
