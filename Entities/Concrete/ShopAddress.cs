﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ShopAddress : IEntity
	{
		public int Id { get; set; }
		public string Zip { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string StreetAddress { get; set; }

		[ForeignKey("Shop")]
		public int ShopId { get; set; }
		public Shop Shop { get; set; }
	}
}
