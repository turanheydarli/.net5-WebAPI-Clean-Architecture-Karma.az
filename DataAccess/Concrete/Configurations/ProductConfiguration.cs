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
	public class ProductConfiguration : BaseConfiguration<Product>
	{
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Name).HasMaxLength((int)MaxLenghtSize.Title).IsRequired();
			builder.Property(p => p.Description).HasMaxLength((int)MaxLenghtSize.Description).IsRequired();
			builder.Property(p => p.Slug).IsRequired();

			base.Configure(builder);
		}
	}
}
