using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Coupon : BaseEntity, IEntity
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public Image Image { get; set; }
		public string Type { get; set; }
		public decimal Amount { get; set; }
		public string ExpireAt { get; set; }
		public bool IsDeactive { get; set; }
		public DateTime DeletedAt { get; set; }

	}
}
