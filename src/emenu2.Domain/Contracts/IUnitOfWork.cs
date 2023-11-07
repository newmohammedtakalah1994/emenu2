﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void Complete();
    }
}
