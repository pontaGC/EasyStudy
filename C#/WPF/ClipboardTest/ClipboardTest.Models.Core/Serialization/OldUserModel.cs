using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTest.Models.Core.Serialization
{
    [DataContract]
    public class OldUserModel
    {
        public OldUserModel(
            string fullName,
            string id,
            UserType type)
        {
            this.FullName = fullName;
            this.Id = id;
            this.Type = type;
        }

        public string FullName { get; }

        public string Id { get; }

        public UserType Type { get; }
    }
}
