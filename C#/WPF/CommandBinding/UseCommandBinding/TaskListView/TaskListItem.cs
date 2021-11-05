using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;

namespace CommandBindingStudy
{
    internal sealed class TaskListItem : BindableBase
    {
        private int number;
        private string taskName;
        private Severity severity;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListItem"/> class.
        /// </summary>
        public TaskListItem()
        {
            this.SelectableSeverities.AddRange(Enum.GetValues(typeof(Severity)).OfType<Severity>());
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a number;
        /// </summary>
        public int Number
        {
            get => this.number;
            set => this.SetProperty(ref this.number, value);
        }

        /// <summary>
        /// Gets or sets the name of a task.
        /// </summary>
        public string TaskName
        {
            get => this.taskName;
            set => this.SetProperty(ref this.taskName, value);
        }

        /// <summary>
        /// Gets or sets a serverity.
        /// </summary>
        public Severity Severity
        {
            get => this.severity;
            set => this.SetProperty(ref this.severity, value);
        }

        /// <summary>
        /// Gets the selectable severities.
        /// </summary>
        public ObservableCollection<Severity> SelectableSeverities { get; } = new ObservableCollection<Severity>();

        #endregion
    }
}
