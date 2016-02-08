using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace SocketLabs.Notification.Shared.Events
{
    public class EventBase
    {
        public EventBase()
        {}
        /// <summary>
        /// Takes key value pairs and populates the object.
        /// </summary>
        /// <param name="formDataCollection"></param>
        public EventBase(IEnumerable<KeyValuePair<string, string>> formDataCollection)
        {
            var allFields = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite);
            foreach (var pair in formDataCollection)
            {
                foreach (var field in allFields)
                {
                    if (field.Name.Equals(pair.Key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (field.PropertyType == typeof (string))
                        {
                            field.SetValue(this, pair.Value, null);
                            break;
                        }
                        if (field.PropertyType == typeof (int))
                        {
                            field.SetValue(this, Convert.ToInt32(pair.Value), null);
                            break;

                        }
                        if (field.PropertyType == typeof (DateTime))
                        {
                            field.SetValue(this, DateTime.Parse(pair.Value), null);
                            break;
                        }
                    }
                }
                
            }
        }
        /// <summary>
        /// Converts object to nice string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var content = new StringBuilder();
            var allProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);
            foreach (var member in allProperties)
            {
                content.Append(string.Format("{0}:{1}\r\n", member.Name, member.GetValue(this, null).ToString()));
            }
            return content.ToString();
        }
        /// <summary>
        /// Converts object to content encoded string safe to send as the post body.
        /// </summary>
        /// <returns></returns>
        public FormUrlEncodedContent ToEncodedContent()
        {
            var allItems = new List<KeyValuePair<string, string>>();
            var allProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);
            foreach (var member in allProperties)
            {
                allItems.Add(new KeyValuePair<string, string>(member.Name, member.GetValue(this, null).ToString()));  
            }
            return new FormUrlEncodedContent(allItems);
        }
    }
}
