using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Category : BaseEntity, IEntity
	{
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Icon { get; set; }
		public int? ImageId { get; set; }
		public Image Image { get; set; }
		public string Details { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string MetaKeywords { get; set; }
		public int? ParentId { get; set; }
		public Category Parent { get; set; }
		public int TypeId { get; set; }
		public Entities.Concrete.Type Type { get; set; }
		public bool IsDeactive { get; set; }
		public DateTime DeletedAt { get; set; }

	}
}
