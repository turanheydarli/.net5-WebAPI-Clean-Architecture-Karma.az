using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class UserProfile : BaseEntity, IEntity
	{
		public Image Avatar { get; set; }
		public string Bio { get; set; }
		public string Contact { get; set; }

		[ForeignKey("User")]
		public int CustomerId { get; set; }
		public User Customer { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Product> Products { get; set; }

	}
}
