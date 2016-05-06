﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Infraestructure
{
    public interface IDbContext
    {
        IDbSet<TEntity> GetSet<TEntity>() where TEntity : class;
    }
}
