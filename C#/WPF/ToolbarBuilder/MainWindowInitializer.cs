using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

using ToolbarBuilder.UserInterface.Core;

namespace ToolbarBuilder
{
    /// <summary>
    /// The initializer of the main window.
    /// </summary>
    internal sealed class MainWindowInitializer : IMainWindowInitializer
    {
        private readonly IToolbarBuilder toolbarBuilder;

        public MainWindowInitializer(IToolbarBuilder toolbarBuilder)
        {
            this.toolbarBuilder = toolbarBuilder;
        }

        /// <summary>
        /// Initializes the main window.
        /// </summary>
        public void Initialize()
        {
            // toolbarのインスタンスを生成して、コレクションを作る
            this.toolbarBuilder.Build(Enumerable.Empty<ToolBar>()); // 今回は空
        }
    }
}
