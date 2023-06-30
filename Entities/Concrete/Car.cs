﻿
using Core.Entities;
using System;

namespace Entities.Concrete
{

       public class Car: IEntity
        {

            public int Id { get; set; }
            public int BrandId { get; set; }
            public int ColorId { get; set; }
            public DateTime ModelYear { get; set; }
            public Decimal DailyPrice { get; set; }
            public string Description { get; set; }

        }

   
}
