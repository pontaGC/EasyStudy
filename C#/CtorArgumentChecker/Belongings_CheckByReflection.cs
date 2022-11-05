using CtorArgumentChecker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtorArgumentChecker
{
    internal class Belongings_CheckByReflection
    {
        public Belongings_CheckByReflection(
            IComputer myDesktopPC, 
            IComputer myNotePC,
            ISmartPhone mySmartPhone,
            ICar myCar)
        {
            this.MyDesktopPC = myDesktopPC;
            this.MyNotePC = myNotePC;
            this.MySmartPhone = mySmartPhone;
            this.MyCar = myCar;
        }

        public IComputer MyDesktopPC { get; }

        public IComputer MyNotePC { get; }

        public ISmartPhone MySmartPhone { get; }

        public ICar MyCar { get; }
    }
}
