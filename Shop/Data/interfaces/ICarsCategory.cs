﻿using System;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
