using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class CustomerAddress : BaseEntity, IEntity
	{
		public string Title { get; set; }
		public string Type { get; set; }
		public string Default { get; set; }
		public User Customer { get; set; }

		public Address Address { get; set; }
	}
}
