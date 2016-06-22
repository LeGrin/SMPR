using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;

namespace Common
{
    /// <summary>
    /// NOTE: scoped by user, so different users must get different storages.
    /// </summary>
    public static class IsolatedStorageHelper
    {
        private static IsolatedStorageFile GetUserStore()
        {
            return IsolatedStorageFile.GetStore(IsolatedStorageScope.Machine | IsolatedStorageScope.Assembly, null, null);
        }

        public static void Save(String fileName, byte[] content)
        {
            using (var isoStore = GetUserStore())
            {
                using (var writer = new IsolatedStorageFileStream(fileName, FileMode.Create, isoStore))
                {
                    writer.Write(content, 0, content.Length);
                }
            }
        }

        public static byte[] Load(String fileName)
        {
            using (var isoStore = GetUserStore())
            {
                using (var reader = new IsolatedStorageFileStream(fileName, FileMode.Open, isoStore))
                {
                    byte[] result = new byte[reader.Length];
                    for (int done = 0; reader.Length - done > 0; )
                    {
                        done += reader.Read(result, done, (int)Math.Min(reader.Length - done, 256));
                    }
                    return result;
                }
            }
        }
        
        /// <returns>True if deleted, False if not found.</returns>
        public static bool Delete(String fileName)
        {
            using (var store = GetUserStore())
            {
                if (Exists(fileName, store))
                {
                    store.DeleteFile(fileName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool Exists(String fileName, IsolatedStorageFile isoStore)
        {
            if (isoStore.GetFileNames(fileName).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Exists(String fileName)
        {
            using (var isoStore = GetUserStore())
            {
                return Exists(fileName, isoStore);
            }
        }
    }
}
