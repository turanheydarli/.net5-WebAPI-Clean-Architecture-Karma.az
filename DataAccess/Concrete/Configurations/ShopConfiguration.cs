using Entities.Common;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations
{
	public class ShopConfiguration : BaseConfiguration<Shop>
	{
		public override void Configure(EntityTypeBuilder<Shop> builder)
		{
			builder.Property(s => s.Name).HasMaxLength((int)MaxLenghtSize.Name).IsRequired();
			builder.Property(s => s.Owner).IsRequired();
			builder.Property(s => s.Slug).IsRequired();

			base.Configure(builder);
		}
	}
}
