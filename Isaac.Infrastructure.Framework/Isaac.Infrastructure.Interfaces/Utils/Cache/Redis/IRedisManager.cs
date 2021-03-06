﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRedisManager<T>
    {
        void Initialize(IRedisConnection<T>);

        T GetClient();
    }
}