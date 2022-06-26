using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using ToolbarBuilder.UserInterface.Core;
using ToolbarBuilder.UserInterface.MainWindow;

namespace ToolbarBuilder.UserInterface.Toolbar
{
    // ビルダーって名前だけど、ビルドしていない(登録処理のみ）
    internal sealed class ToolbarBuilder : IToolbarBuilder
    {
        public void Build(IEnumerable<ToolBar> toolBars)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow.MainWindow;
            if (mainWindow is null)
            {
                return;
            }

            foreach(var toolBar in toolBars)
            {
                mainWindow.ToolBarTray.ToolBars.Add(toolBar);
            }
        }
    }
}
