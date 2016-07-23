using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQpro
{
    public static class MyExtensions
    {
        public static void CopyTo(this object source, object target)
        {
            var CopyInfo = from firstProperty in source.GetType().GetProperties()
                where firstProperty.CanRead
                from secondProperty in target.GetType().GetProperties()
                where secondProperty.CanWrite 
                where firstProperty.Name == secondProperty.Name
                select new
                {
                    sourceProperties = firstProperty,
                    targetProperties = secondProperty
                };
            foreach (var item in CopyInfo)
            {
                item.targetProperties.SetValue(target, item.sourceProperties.GetValue(source));
            }
        }
    }
}
