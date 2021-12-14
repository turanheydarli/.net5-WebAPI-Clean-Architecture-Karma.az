using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductCategory : IEntity
	{
		public Product Product { get; set; }
		public Category Category { get; set; }
	}
}
