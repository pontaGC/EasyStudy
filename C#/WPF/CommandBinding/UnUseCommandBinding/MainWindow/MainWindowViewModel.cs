using Prism.Mvvm;

namespace CommandBinding
{
    internal sealed class MainWindowViewModel : BindableBase
    {
        private TaskListViewModel taskList = new TaskListViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.LoadSampleTasks();
        }

        /// <summary>
        /// Gets or sets the <see cref="TaskList"/>.
        /// </summary>
        public TaskListViewModel TaskList
        {
            get => this.taskList;
            set => this.SetProperty(ref this.taskList, value);
        }

        private void LoadSampleTasks()
        {
            this.TaskList.Items.Add(new TaskListItem() { Number = 1, Severity = Severity.A, TaskName = $"TestTask{1}" });
            this.TaskList.Items.Add(new TaskListItem() { Number = 2, Severity = Severity.B, TaskName = $"TestTask{2}" });
            this.TaskList.Items.Add(new TaskListItem() { Number = 3, Severity = Severity.C, TaskName = $"TestTask{3}" });
        }
    }
}
