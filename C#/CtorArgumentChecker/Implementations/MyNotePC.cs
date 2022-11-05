using CtorArgumentChecker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtorArgumentChecker.Implementations
{
    internal class MyNotePC : IComputer
    {
        public string Name { get; }

        public string Vendor { get; }
    }
}
