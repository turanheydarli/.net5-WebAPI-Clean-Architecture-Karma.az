using Core.Entities.Concrete;
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
	public class UserProfileConfiguration : BaseConfiguration<UserProfile>
	{
		public override void Configure(EntityTypeBuilder<UserProfile> builder)
		{
			builder.Property(u => u.Bio).HasMaxLength((int)MaxLenghtSize.Bio).IsRequired();
			builder.Property(u => u.Customer.Name).IsRequired();
			builder.Property(u => u.Customer.Email).IsRequired();

			base.Configure(builder);
		}
	}
}
