using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ShopCategory : IEntity
	{
		public int Id { get; set; }
		public int ShopId { get; set; }
		public Shop Shop { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
