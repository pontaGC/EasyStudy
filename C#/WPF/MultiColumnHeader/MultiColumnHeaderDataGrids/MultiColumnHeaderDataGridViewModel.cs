using MultiColumnHeader.MultiColumnHeaderDataGrids;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiColumnHeader.MultiColumnDataGrids
{
    /// <summary>
    /// The view-model for the <see cref="MultiColumnHeaderDataGrid"/>.
    /// </summary>
    internal class MultiColumnHeaderDataGridViewModel : BindableBase
    {
        public MultiColumnHeaderDataGridViewModel()
        {
            this.CreateTestUsers();
        }

        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        private void CreateTestUsers()
        {
            foreach(var number in Enumerable.Range(1, 11))
            {
                var user = new User()
                {
                    Id = $"Test{number}",
                    Name = $"User{number}",
                    Rank = number,
                    Nationality = IsOddNumber(number) ? "Country1" : "Country2",
                    Nickname = $"Number{number}",
                };

                this.Users.Add(user);
            }
        }

        private static bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }
    }
}
