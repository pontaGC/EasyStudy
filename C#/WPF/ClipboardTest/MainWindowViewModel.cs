using ClipboardTest.Models.Core.Serialization;
using ClipboardTest.Models.Serialization;
using Prism.Commands;
using System.IO;
using System.Windows.Input;

namespace ClipboardTest
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string serializedInfoText;
        private string deserializedInfoText;
        private byte[] user1Cache;

        public MainWindowViewModel()
        {
            this.SerializeCommand = new DelegateCommand(this.Serialize);
            this.DeserializeCommand = new DelegateCommand(this.Deserialize);
        }

        public string SerializedInfoText
        {
            get => this.serializedInfoText;
            set => this.SetProperty(ref this.serializedInfoText, value);
        }

        public string DeserializedInfoText
        {
            get => this.deserializedInfoText;
            set => this.SetProperty(ref this.deserializedInfoText, value);
        }

        public ICommand SerializeCommand { get; }

        public ICommand DeserializeCommand { get; }

        private void Serialize()
        {
            var testUser1 = new User(
                new UserId(),
                UserType.Silver,
                new UserFullName("Taro", "Hoge")
                );

            using(var stream = new MemoryStream())
            {
                var serializer = new DDataContractoSerializaer();
                serializer.Serialize(testUser1, stream);
                this.user1Cache = stream.ToArray();
            }

            this.SerializedInfoText = testUser1.ToString();
        }

        private void Deserialize()
        {
            if (this.user1Cache is null)
            {
                return;
            }

            using (var stream = new MemoryStream(this.user1Cache))
            {
                var serializer = new DDataContractoSerializaer();
                var user1 = serializer.Deserialize<User>(stream);

                if (user1 is null)
                {
                    this.DeserializedInfoText = "Failed to deserialize.";
                }
                else
                {
                    this.DeserializedInfoText = user1.ToString();
                }
            }
        }
    }
}
