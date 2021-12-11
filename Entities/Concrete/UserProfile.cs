using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class UserProfile : IEntity
	{
		public int Id { get; set; }
		public int? AvatarId { get; set; }
		public Image Avatar { get; set; }
		public string Bio { get; set; }
		public string Contact { get; set; }
		public int CustomerId { get; set; }
		public User Customer { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

	}
}
