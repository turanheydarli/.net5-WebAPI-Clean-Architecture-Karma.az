using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Product : BaseEntity, IEntity
	{
		public string Description { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public int TypeId { get; set; }
		public Entities.Concrete.Type Type { get; set; }
		public Shop Shop { get; set; }
		public ICollection<ProductCategory> Categories { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public decimal Price { get; set; }
		public string Sku { get; set; }
		public int Quantity { get; set; }
		public bool InStock { get; set; }
		public bool IsTaxable { get; set; }
		public ShippingClass ShippingClass { get; set; }
		public string Status { get; set; }
		public string Unit { get; set; }
		public string Height { get; set; }
		public string Width { get; set; }
		public string Length { get; set; }
		public decimal MaxPrice { get; set; }
		public decimal MinPrice { get; set; }
		public int ReviewCount { get; set; }
		public DateTime DeletedAt { get; set; }

	}
}
