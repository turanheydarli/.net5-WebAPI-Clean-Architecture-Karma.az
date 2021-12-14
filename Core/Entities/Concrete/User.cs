using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
	public class User : BaseEntity, IEntity
	{
		public string Name { get; set; }
		public string ImagePath { get; set; }
		public string Email { get; set; }
		public byte[] PasswordSalt { get; set; }
		public byte[] PasswordHash { get; set; }
		public DateTime EmailVerifiedAt { get; set; }
		public bool IsActive { get; set; }
		public string RememberToken { get; set; }
		public int ShopId { get; set; }
	}
}
