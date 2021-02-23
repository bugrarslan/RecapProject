﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDal : EfEntityRepositoryBase<Rent, ReCapProjectContext>, IRentDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rents
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             select new RentDetailDto
                             {
                                 RentId = r.RentId,
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                             };

                return result.ToList();
               
            }
        }
    }
}
