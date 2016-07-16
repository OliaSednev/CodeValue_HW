using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Analayze_Assembly
    {
        public bool AnalayzeAssembly(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            var flag = true;

            var allTypes = assembly.GetTypes().Where(x => x.IsDefined(typeof(CodeReviewAttribute)));
            foreach (var _type in allTypes)
            {
               var attributesArray = _type.GetCustomAttributes(typeof(CodeReviewAttribute));

                foreach (var att in attributesArray)
                {
                    // if not all reviewed types are approved will return false
                    if (!((CodeReviewAttribute)att).IsApproved)
                    {
                        flag = false;
                    }
                    Console.WriteLine("{0}, {1}, {2}", 
                        ((CodeReviewAttribute)att).Name, 
                        ((CodeReviewAttribute)att).Date, 
                        ((CodeReviewAttribute)att).IsApproved);
                }
            }
            return flag;
        }
    }
}