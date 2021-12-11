using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Attribute : IEntity
	{
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Name { get; set; }
		public int ShopId { get; set; }
		public Shop Shop { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

	}
}
