using Prism.Mvvm;

namespace CommandBinding
{
    internal sealed class TaskListItem : BindableBase
    {
        private int number;
        private string taskName;
        private Severity severity;

        /// <summary>
        /// Gets or sets a number;
        /// </summary>
        public int Number
        {
            get => this.number;
            set => this.SetProperty(ref this.number, value);
        }

        /// <summary>
        /// Gets or sets name of a task.
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
    }
}
