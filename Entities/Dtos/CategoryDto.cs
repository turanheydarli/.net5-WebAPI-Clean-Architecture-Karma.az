using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public class CategoryDto : IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Icon { get; set; }
		public Image Image { get; set; }
		public string Details { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string MetaKeywords { get; set; }
		public int? ParentId { get; set; }
		public Category Parent { get; set; }
		//public IEnumerable<Category> Childiren { get; set; }
		public Entities.Concrete.Type Type { get; set; }
		public bool IsDeactive { get; set; }
		public DateTime DeletedAt { get; set; }
	}
}
