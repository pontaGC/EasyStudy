﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CtorArgumentChecker.Interfaces
{
    public interface ISmartPhone
    {
        string Name { get; }

        string Vendor { get; }
    }
}
