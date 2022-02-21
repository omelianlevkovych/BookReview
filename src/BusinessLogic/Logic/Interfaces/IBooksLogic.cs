﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic.Interfaces
{
    public interface IBooksLogic
    {
        Task<IEnumerable<BookModel>> GetAll();
    }
}
