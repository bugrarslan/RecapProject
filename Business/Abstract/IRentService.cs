﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<RentDetailDto>> GetAll();
        IDataResult<Rent> GetByRentId(int Id);
        IResult Add(Rent rent);
        IResult Delete(Rent rent);
        IResult Update(Rent rent);
    }
}
