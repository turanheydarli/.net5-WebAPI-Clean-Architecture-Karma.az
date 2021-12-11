using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Address : IEntity
	{
		public int Id { get; set; }
		public string Zip { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string StreetAddress { get; set; }

		[ForeignKey("CustomerAddress")]
		public int CustomerAddressId { get; set; }
		public CustomerAddress CustomerAddress { get; set; }
		
	}
}
