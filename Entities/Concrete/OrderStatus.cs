using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class OrderStatus :BaseEntity, IEntity
	{

		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public string Name { get; set; }
		public int Serial { get; set; }
		public string Color { get; set; }

	}
}
