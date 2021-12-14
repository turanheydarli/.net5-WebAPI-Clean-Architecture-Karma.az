using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Option : BaseEntity, IEntity
	{
		public VariationOption VariationOption { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}
}
