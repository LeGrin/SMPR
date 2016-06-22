using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Common
{
    public static class SerializationHelper
    {
        public static void Serialize<T>(T obj, Stream serializationStream)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, obj);
        }

        public static byte[] Serialize<T>(T obj)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }    
    
        public static T Deserialize<T>(Stream serializationStream)
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(serializationStream);            
        }

        public static T Deserialize<T>(byte[] data)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream(data))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
