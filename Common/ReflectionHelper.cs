using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class ReflectionHelper
    {
        public static IEnumerable<T> GetAttributes<T>(this Enum member)
        {
            var enumType = member.GetType();
            var mInfo = enumType.GetMember(member.ToString());
            if (mInfo.Length == 1)
            {
                return mInfo[0].GetCustomAttributes(typeof(T), inherit: false).Cast<T>();
            }

            return new T[0];
        }

        public static T GetAttribute<T>(this Enum member)
        {
            return GetAttributes<T>(member).FirstOrDefault();
        }

        public static IEnumerable<T> GetAttributes<T>(this Type type)
        {
            return type.GetCustomAttributes(typeof(T), inherit: false).Cast<T>();
        }

        public static T GetAttribute<T>(this Type type)
        {
            return GetAttributes<T>(type).FirstOrDefault();
        }
    }
}
