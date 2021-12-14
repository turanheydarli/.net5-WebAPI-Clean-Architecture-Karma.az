using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Shop : BaseEntity, IEntity
	{
		public User Owner { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public Image Cover { get; set; }
		public Image Logo { get; set; }
		public ShopAddress Address { get; set; }
		public ShopLocation Location { get; set; }
		public ShopSetting Setting { get; set; }
		public List<ShopSocial> Socials { get; set; }
		public bool IsActive { get; set; }
	}
}
