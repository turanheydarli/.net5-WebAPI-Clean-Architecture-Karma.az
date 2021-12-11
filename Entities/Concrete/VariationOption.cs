using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class VariationOption : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Price { get; set; }
		public string SalePrice { get; set; }
		public string Quantity { get; set; }
		public bool IsDisable { get; set; }
		public string Sku { get; set; }
		public int ProductId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public DateTime DeletedAt { get; set; }
	}
}
