using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class PaymentInfo : BaseEntity, IEntity
	{
		public string Bank { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Account { get; set; }
	}
}
