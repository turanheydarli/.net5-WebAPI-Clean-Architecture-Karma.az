using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class AttributeValue : IEntity
	{
		public int Id { get; set; }
		public int AttributeId { get; set; }
		public Attribute Attribute { get; set; }
		public string Value { get; set; }
		public string Meta { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
