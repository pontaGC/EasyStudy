using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared;

namespace ToolbarBuilder.UserInterface.Toolbar.ViewModels
{
    internal class ToolBarComboBoxViewModel : ToolBarItemViewModelBase
    {
        public ToolBarComboBoxViewModel(
            int rank,
            string tooltipKey,
            string tooltipDefaultText,
            IEnumerable<string> comboBoxItems)
            : base(rank, tooltipKey, tooltipDefaultText)
        {
            this.Items.AddRange(comboBoxItems ?? Enumerable.Empty<string>());
        }

        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
    }
}
