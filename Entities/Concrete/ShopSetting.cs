using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ShopSetting : IEntity
	{
		public int Id { get; set; }
		public string Contact { get; set; }
		public string Website { get; set; }

		[ForeignKey("Shop")]
		public int ShopId { get; set; }
		public Shop Shop { get; set; }
	}
}
