using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQpro
{
    class ClassB
    {
        private string name_PrivetField = "NitzanFromClassB";
        public string Name_Public { get; } = "oliaFromClassB";

        public string Name_WithGetAndSet { get; set; }
        public string Name_ReadOnly { get; private set; }

        public ClassB(string name)
        {
            name_PrivetField = name;
            Name_Public = name;
            Name_WithGetAndSet = name;
            Name_ReadOnly = name;
        }

        public override string ToString()
        {
            return $"name_PrivetField: {name_PrivetField}, Name_Public: {Name_Public}, Name_WithGetAndSet: {Name_WithGetAndSet}, Name_ReadOnly: {Name_ReadOnly}";
        }
    }
}
