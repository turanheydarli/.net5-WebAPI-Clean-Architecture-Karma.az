using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Image : BaseEntity, IEntity
	{
		public string Original { get; set; }
		public string Thumbnail { get; set; }
	}
}
