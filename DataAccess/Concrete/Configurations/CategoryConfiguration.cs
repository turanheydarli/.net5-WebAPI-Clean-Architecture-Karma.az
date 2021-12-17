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
	public class CategoryConfiguration : BaseConfiguration<Category>
	{
		public override void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(c => c.Name).HasMaxLength((int)MaxLenghtSize.Name).IsRequired();
			builder.Property(c => c.MetaDescription).HasMaxLength((int)MaxLenghtSize.MetaDescription);
			builder.Property(c => c.MetaTitle).HasMaxLength((int)MaxLenghtSize.Title);
			builder.Property(c => c.MetaKeywords).HasMaxLength((int)MaxLenghtSize.MetaKeyword);

			base.Configure(builder);
		}
	}
}
