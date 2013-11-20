using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataModelBase<T>
    {
        public static string SelectCmd(string filter = null)
        {
            return string.Format("SELECT {0} FROM [{1}]{2}",
                SelectList(),
                typeof(T).Name,
                filter.SafeFilter());
        }

        public static string SelectList(bool ignoreKey = false)
        {
            var properties = typeof(T)
                .GetProperties()
                .Where(p => !p.PropertyType.IsGenericType ||
                    (p.PropertyType.IsGenericType && p.PropertyType.IsValueType));

            if (ignoreKey)
            {
                properties = properties
                    .Where(p => p.Name != typeof(T).KeyField());
            }

            return string.Join(", ",
                properties.Select(p => string.Format("[{0}]", p.Name)));
        }
    }
}
