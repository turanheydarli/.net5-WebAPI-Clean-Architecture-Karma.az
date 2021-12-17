using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductOrder : BaseEntity, IEntity
	{
		public Order Order { get; set; }
		public Product Product { get; set; }
		public VariationOption VariationOption { get; set; }
		public string OrderQuantity { get; set; }
		public string UnitPrice { get; set; }
		public string SubTotal { get; set; }
		public DateTime DeletedAt { get; set; }
	}
}
