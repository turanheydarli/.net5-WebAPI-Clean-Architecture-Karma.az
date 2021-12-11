using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductAttribute : IEntity
	{
		public int Id { get; set; }
		public int AttributeValueId { get; set; }
		public AttributeValue AttributeValue { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
