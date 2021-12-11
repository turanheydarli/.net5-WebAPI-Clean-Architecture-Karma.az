﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductTag : IEntity
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}
