using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
	public class MsDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=.;database=KarmaTest1;Integrated Security=SSPI");
		}


		public DbSet<Address> Addresses { get; set; }
		public DbSet<Entities.Concrete.Attribute> Attributes { get; set; }
		public DbSet<AttributeValue> AttributeValues { get; set; }
		public DbSet<Balance> Balances { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<CustomerAddress> CustomerAddresses { get; set; }
		public DbSet<Gallery> Galleries { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<Option> Options { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<PaymentInfo> PaymentInfos { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductAttribute> ProductAttributes { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductOrder> ProductOrders { get; set; }
		public DbSet<ProductTag> ProductTags { get; set; }
		public DbSet<Setting> Settings { get; set; }
		public DbSet<ShippingClass> ShippingClasses { get; set; }
		public DbSet<Shop> Shops { get; set; }
		public DbSet<ShopAddress> ShopAddresses { get; set; }
		public DbSet<ShopCategory> ShopCategories { get; set; }
		public DbSet<ShopLocation> ShopLocations { get; set; }
		public DbSet<ShopSocial> Socials { get; set; }
		public DbSet<ShopSetting> ShopSettings { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TaxClass> TaxClasses { get; set; }
		public DbSet<Entities.Concrete.Type> Types { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<VariationOption> VariationOptions { get; set; }



	}
}

