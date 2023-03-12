using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTest.Models.Core.Serialization
{
    public interface IUser
    {
        IUserId Id { get; }

        UserType UserType { get; }

        IUserFullName Name { get; }
    }
}
