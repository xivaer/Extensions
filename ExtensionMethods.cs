/*------------------------------------------------------------------
Author:: LAN
------------------------------------------------------------------*/

using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

public static class Extensions
{
    public static T DeepClone<T>(this T item)
    {
        if (item != null)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, item);
                stream.Seek(0, SeekOrigin.Begin);
                var result = (T)formatter.Deserialize(stream);
                return result;
            }
        }

        return default(T);
    }

    public static T ShallowCopy<T>(this T item)
    {
        MethodInfo method = item.GetType().GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
        return (T)method.Invoke(item, null);
    }
}
