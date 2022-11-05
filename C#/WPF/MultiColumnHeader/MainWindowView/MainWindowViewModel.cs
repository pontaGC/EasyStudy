using MultiColumnHeader.MultiColumnDataGrids;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiColumnHeader.MainWindowView
{
    /// <summary>
    /// The view-model of the main window.
    /// </summary>
    internal sealed class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            this.MultiColumnHeader = new MultiColumnHeaderDataGridViewModel();
        }

        public MultiColumnHeaderDataGridViewModel MultiColumnHeader { get; }
    }
}
