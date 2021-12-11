using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Shop : IEntity
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public User Owner { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public int CoverId { get; set; }
		public Image Cover { get; set; }
		public int LogoId { get; set; }
		public Image Logo { get; set; }
		public ShopAddress Address { get; set; }
		public ShopLocation Location { get; set; }
		public ShopSetting Setting { get; set; }
		public List<ShopSocial> Socials { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
