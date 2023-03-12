using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTest
{
    internal class DDataContractoSerializaer
    {
        public void Serialize<T>(T source, Stream destination)
            where T : class
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(destination, source);
            }
            catch
            {
                throw;
            }
        }

        public T? Deserialize<T>(Stream source)
           where T : class
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(T));
                return serializer.ReadObject(source) as T;
            }
            catch
            {
                throw;
            }
        }
    }
}
