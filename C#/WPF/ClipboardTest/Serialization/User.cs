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
    internal class User : IUser
    {
        public User(
            IUserId id,
            UserType type,
            IUserFullName name
            )
        {
            this.Id = id;
            this.UserType = type;
            this.Name = name;

            this.InternalModel = new OldUserModel(
                name.ToString(),
                id.Id,
                type);
        }

        public IUserId Id { get; }

        public UserType UserType { get; }

        public IUserFullName Name { get; }

        [DataMember]
        internal OldUserModel InternalModel { get; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"Id is null: {this.Id == null}");
            builder.AppendLine($"Name is null: {this.Name == null}");
            builder.AppendLine($"InternalModel is null: {this.InternalModel == null}");

            builder.Append(Environment.NewLine);

            builder.AppendLine($"Id: {this.Id?.Id}");
            builder.AppendLine($"Type: {this.UserType}");
            builder.AppendLine($"Name: {this.Name?.ToString()}");

            builder.Append(Environment.NewLine);

            builder.AppendLine($"InternalModel.Id: {this.InternalModel?.Id}");
            builder.AppendLine($"InternalModel.FullName: {this.InternalModel?.FullName}");
            builder.AppendLine($"InternalModel.Type: {this.InternalModel?.Type}");

            return builder.ToString();
        }
    }
}
