﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfImageDal : EfEntityRepositoryBase<Image, MsDbContext>,  IImageDal
	{
		public EfImageDal(MsDbContext context):base(context)
		{

		}
	}
}
