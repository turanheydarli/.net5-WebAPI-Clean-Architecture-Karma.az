using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Comment : BaseEntity, IEntity
	{
		public int? UserId { get; set; }
		public User User { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public string CommentText { get; set; }
		public string CommenterName { get; set; }
		public string CommenterEmail { get; set; }
		public int? ParentId { get; set; }
		public Comment Parent { get; set; }
		public ICollection<Comment> Replies { get; protected set; } = new List<Comment>();
	}
}
