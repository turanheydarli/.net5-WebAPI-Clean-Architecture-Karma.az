using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Setting : IEntity
	{
		public int Id { get; set; }
		public int LogoId { get; set; }
		public Image Logo { get; set; }
		public string Currency { get; set; }
		public int TaxClass { get; set; }
		public string SiteTitle { get; set; }
		public string SiteSubtitle { get; set; }
		public int ShippingClass { get; set; }
	}
}
