using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Attribute : BaseEntity, IEntity
	{
		public string Slug { get; set; }
		public string Name { get; set; }
		public Shop Shop { get; set; }

	}
}
