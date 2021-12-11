using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ShopSocial : IEntity
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }

		[ForeignKey("Shop")]
		public int ShopId { get; set; }
		public Shop Shop { get; set; }
	}
}
