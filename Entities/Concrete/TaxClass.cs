using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class TaxClass : IEntity
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string City { get; set; }
		public decimal Rate { get; set; }
		public string Name { get; set; }
		public int? IsGlobal { get; set; }
		public int? Priority { get; set; }
		public bool OnShipping { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

	}
}
