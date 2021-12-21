using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Image : BaseEntity, IEntity
	{
		public string Original { get; set; }
		public string Thumbnail { get; set; }

		[NotMapped]
		public byte[] Photo { get; set; }
	}
}
