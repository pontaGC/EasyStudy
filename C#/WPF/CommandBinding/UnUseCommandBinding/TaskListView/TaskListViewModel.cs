using System.Collections.ObjectModel;
using System.Windows.Input;

using Prism.Commands;
using Prism.Mvvm;

namespace CommandBinding
{
    internal sealed class TaskListViewModel : BindableBase
    {
        private TaskListItem copiedItem;
        private TaskListItem selectedItem;
        private DelegateCommand copyCommand;
        private DelegateCommand pasteCommand;

        #region Properties

        /// <summary>
        /// Gets or sets a current selected item.
        /// </summary>
        /// <value>The current selected item.</value>
        public TaskListItem SelectedItem 
        {
            get => this.selectedItem;
            set
            {
                if (this.SetProperty(ref this.selectedItem, value))
                {
                    this.copyCommand.RaiseCanExecuteChanged();
                    this.pasteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Gets the copy command.
        /// </summary>
        public ICommand CopyCommand
        {
            get
            {
                if (this.copyCommand == null)
                {
                    this.copyCommand = new DelegateCommand(this.Copy, this.CanCopy);
                }

                return this.copyCommand;
            }
        }

        /// <summary>
        /// Gets the paste command.
        /// </summary>
        public ICommand PasteCommand
        {
            get
            {
                if (this.pasteCommand == null)
                {
                    this.pasteCommand = new DelegateCommand(this.Paste, this.CanPaste);
                }

                return this.pasteCommand;
            }
        }

        /// <summary>
        /// Gets a collection of the task item.
        /// </summary>
        public ObservableCollection<TaskListItem> Items { get; } = new ObservableCollection<TaskListItem>();

        #endregion

        #region Methods

        private bool CanCopy()
        {
            return this.selectedItem != null;
        }

        private void Copy()
        {
            this.copiedItem = this.SelectedItem;
            this.pasteCommand.RaiseCanExecuteChanged();
        }

        private bool CanPaste()
        {
            return this.copiedItem != null && this.SelectedItem != null;
        }

        private void Paste()
        {
            var pastingItem = new TaskListItem()
            {
                Number = this.copiedItem.Number,
                Severity = this.copiedItem.Severity,
                TaskName = $"{this.copiedItem.TaskName}_Copy",
            };

            // Inserts copied item to the next row of the selected item
            this.Items.Insert((this.Items.IndexOf(this.SelectedItem) + 1), pastingItem);
        }

        #endregion
    }
}
