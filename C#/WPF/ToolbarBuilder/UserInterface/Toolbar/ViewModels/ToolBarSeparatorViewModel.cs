using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToolbarBuilder.UserInterface.Toolbar.ViewModels
{
    internal sealed class ToolBarSeparatorViewModel : ToolBarItemViewModelBase
    {
        public ToolBarSeparatorViewModel(int rank)
            : base(rank, null, null)
        {

        }
    }
}
