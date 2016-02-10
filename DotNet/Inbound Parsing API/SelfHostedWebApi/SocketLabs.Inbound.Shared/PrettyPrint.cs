using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SocketLabs.Inbound.Shared
{
    public static class PrettyPrint
    {
        /// <summary>
        /// Converts object to nice string.
        /// </summary>
        /// <returns></returns>
        public static string ToString(object dataObject)
        {
            if (dataObject == null)
                return "";

            var content = new StringBuilder();
            var allProperties = dataObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);
            foreach (var member in allProperties)
            {
                var value = member.GetValue(dataObject, null);
                if (value == null)
                    continue;

                if (member.PropertyType.IsArray)
                {
                    var array = value as Array;
                    if (array != null)
                        foreach (var item in array)
                        {
                            content.Append(
                                ToString(item)
                                );
                        }
                }
                else if (!member.PropertyType.IsValueType && member.PropertyType != typeof(string))
                {
                    content.Append(
                        ToString(value)
                        );
                }
                else
                {
                    content.Append(string.Format("{0}:{1}\r\n", member.Name,
                        value.ToString()));
                }
            }
            return content.ToString();
        }
        
    }
}
