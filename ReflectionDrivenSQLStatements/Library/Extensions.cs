using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Extensions
    {
        public static string KeyField(this Type t)
        {
            var keyField = t
                .GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(KeyAttribute)))
                .FirstOrDefault();

            if (keyField != null) { return keyField.Name; }
            return null;
        }

        public static string SafeFilter(this string filter, bool prefixSpace = true)
        {
            if (string.IsNullOrEmpty(filter)) { return null; }
            filter = filter.Trim();

            return filter
                .StartsWith("where", StringComparison.OrdinalIgnoreCase) ?
                    string.Format("{0}{1}", prefixSpace ? " " : "", filter) :
                    string.Format("{0}WHERE {1}", prefixSpace ? " " : "", filter);
        }
    }
}
