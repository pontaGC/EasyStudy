using Prism.Mvvm;

namespace MultiColumnHeader.MultiColumnHeaderDataGrids
{
    internal class User : BindableBase
    {
        private int rank;
        private string id;
        private string name;
        private string nickName;
        private string nationality;

        #region User

        public string Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }

        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        #endregion

        #region Detail

        public int Rank
        {
            get => this.rank;
            set => this.SetProperty(ref this.rank, value);
        }

        public string Nickname
        {
            get => this.nickName;
            set => this.SetProperty(ref this.nickName, value);
        }


        public string Nationality
        {
            get => this.nationality;
            set => this.SetProperty(ref this.nationality, value);
        }

        #endregion
    }
}
