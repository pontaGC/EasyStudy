using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

namespace ToolbarBuilder.UserInterface.Core
{
    public interface IToolbarBuilder
    {
        void Build(IEnumerable<ToolBar> toolBars);
    }
}
