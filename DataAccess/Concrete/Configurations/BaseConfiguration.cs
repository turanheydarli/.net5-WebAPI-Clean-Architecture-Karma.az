using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations
{
	public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity, IEntity
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
