using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductTag : IEntity
	{
		public Product Product { get; set; }
		public Tag Tag { get; set; }
	}
}
