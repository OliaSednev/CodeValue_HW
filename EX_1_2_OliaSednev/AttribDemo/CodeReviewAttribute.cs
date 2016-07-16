using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CodeReviewAttribute: System.Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public bool IsApproved { get; set; }

        public CodeReviewAttribute() { }

        public CodeReviewAttribute(string name, string date, bool isApproved)
        {
            Name = name;
            Date = date;
            IsApproved = isApproved;
        }
    }
}
