using ClipboardTest.Models.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTest.Models.Serialization
{
    [DataContract]
    internal class UserId : IUserId
    {
        public UserId()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }
}
