using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructsHelper
{
    public class TypesDB
    {
        public struct TypeInfo
        {
            public int TypeSize;
            public string TypeName;
            public bool IsBuiltin;

            public TypeInfo(string name, int size, bool builtin = false)
            {
                TypeSize = size;
                TypeName = name;
                IsBuiltin = builtin;
            }

            public override string ToString()
            {
                return TypeName + " (" + TypeSize.ToString() + " byte" + (TypeSize % 10 != 1 || TypeSize > 10 ? "s" : "") + ")";
            }

        }

        TypesDB()
        {
            typeslist = new List<TypeInfo>();
        }

        public List<TypeInfo> typeslist;

        public void RegisterType(string name, int size)
        {
            if (typeslist.Contains(new TypeInfo(name, size, false)) == false)
                typeslist.Add(new TypeInfo(name, size, false));
        }

        public void RegisterType(TypeInfo ti)
        {
            if (typeslist.Contains(new TypeInfo(ti.TypeName, ti.TypeSize, false)) == false)
                typeslist.Add(new TypeInfo(ti.TypeName, ti.TypeSize, false));
        }

        public void RegisterBuiltinType(string name, int size)
        {
            if (typeslist.Contains(new TypeInfo(name, size, true)) == false)
                typeslist.Add(new TypeInfo(name, size, true));
        }

        public void RegisterBuiltinType(TypeInfo ti)
        {
            if (typeslist.Contains(new TypeInfo(ti.TypeName, ti.TypeSize, true)) == false)
                typeslist.Add(new TypeInfo(ti.TypeName, ti.TypeSize, true));
        }

        static public TypesDB Instance = new TypesDB();
    }
}
