﻿using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfColorDal  : EfEntityRepositoryBase<Color, NorthwindContext>,IColorDal
    {
        
    }
}
