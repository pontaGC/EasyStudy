using Prism.Commands;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToolbarBuilder.UserInterface.MainWindow
{
    /// <summary>
    /// The view-model for a main window.
    /// </summary>
    internal sealed  class MainWindowViewModel : BindableBase
    {
        #region Private fields

        private bool closesWindow;
        private string text;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.CloseCommand = new DelegateCommand(this.Close);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating closes a window.
        /// </summary>
        public bool ClosesWindow
        {
            get => this.closesWindow;
            set => this.SetProperty(ref this.closesWindow, value);
        }

        /// <summary>
        /// Gets or sets a text.
        /// </summary>
        public string Text
        {
            get => this.text;
            set => this.SetProperty(ref this.text, value);
        }

        /// <summary>
        /// Gets a command that closes a window.
        /// </summary>
        public ICommand CloseCommand { get; }

        #endregion

        #region Methods

        private void Close()
        {
            this.ClosesWindow = true;
        }

        #endregion
    }
}
