using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class AttributeValue : BaseEntity, IEntity
	{
		public Attribute Attribute { get; set; }
		public string Value { get; set; }
		public string Meta { get; set; }
	}
}
