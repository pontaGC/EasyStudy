using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolbarBuilder.UserInterface.Toolbar.ViewModels
{
    internal class ToolBarCheckBoxViewModel : ToolBarItemViewModelBase
    {
        public ToolBarCheckBoxViewModel(int rank, string tooltipKey, string tooltipDefaultText) : base(rank, tooltipKey, tooltipDefaultText)
        {
        }

        public bool IsA { get; }

        public bool IsB { get; }
    }
}
