using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Business.Services.File;
using Business;
using System.Reflection;
using Autofac;
using Microsoft.IdentityModel.Protocols;

namespace WebAPI
{
	public class Startup : BusinessStartup
	{
		public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
		   : base(configuration, hostEnvironment)
		{
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public override void ConfigureServices(IServiceCollection services)
		{

			services.AddSingleton<ICategoryService, CategoryManager>();
			services.AddSingleton<ICategoryDal, EfCategoryDal>();

			services.AddSingleton<MsDbContext, MsDbContext>();

			services.AddSingleton<IFileService, FileService>();
			services.AddSingleton<IImageDal, EfImageDal>();

			services.AddAutoMapper();



			services.AddControllers()
			   .AddJsonOptions(options =>
			   {
				   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				   options.JsonSerializerOptions.IgnoreNullValues = true;
			   });

			services.AddMediatR(typeof(BusinessStartup).GetTypeInfo().Assembly);


			services.AddCors(options =>
			{
				options.AddPolicy(
					"AllowOrigin",
					builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidIssuer = tokenOptions.Issuer,
						ValidAudience = tokenOptions.Audience,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
						ClockSkew = TimeSpan.Zero
					};
				});

			base.ConfigureServices(services);
		}



		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("AllowOrigin");

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
