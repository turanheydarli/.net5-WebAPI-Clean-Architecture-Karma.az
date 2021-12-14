using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductAttribute : BaseEntity, IEntity
	{
		public AttributeValue AttributeValue { get; set; }
		public Product Product { get; set; }
	}
}
