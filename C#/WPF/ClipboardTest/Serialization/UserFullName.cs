using ClipboardTest.Models.Core.Serialization;
using System.Runtime.Serialization;

namespace ClipboardTest.Models.Serialization
{
    [DataContract]
    internal class UserFullName : IUserFullName
    {
        public UserFullName(
            string firstName,
            string lastname)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
