using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructsHelper
{
    public class TypesDB
    {
        public class TypeInfo
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

            //  For internal use only. For example, when a search is required.
            public TypeInfo(string name)
            {
                TypeName = name;
                TypeSize = -1;
                IsBuiltin = false;
            }

            public override string ToString()
            {
                return TypeName + " (" + TypeSize.ToString() + " byte" + (TypeSize % 10 != 1 || TypeSize > 10 ? "s" : "") + ")";
            }

            public void SetSize(int newSize)
            {
                if (IsBuiltin)
                    return;

                TypeSize = newSize;
            }
        }

        TypesDB()
        {
            typeslist = new List<TypeInfo>();

            //  Register builtin types.
            RegisterBuiltinType("char", 1);
            RegisterBuiltinType("bool", 1);
            RegisterBuiltinType("short", 2);
            RegisterBuiltinType("int", 4);
        }

        public List<TypeInfo> typeslist;

        public int GetSizeByTypeName(string name)
        {
            TypeInfo tiresult = typeslist.Find(ti => ti.TypeName == name);
            return tiresult.TypeSize;
        }

        public int GetSizeByTypeId(int id)
        {
            if (id < 0 || id >= typeslist.Count)
                return -1;
            else
                return typeslist[id].TypeSize;
        }

        public string GetTypeNameById(int id)
        {
            if (id < 0 || id >= typeslist.Count)
                return null;
            else
                return typeslist[id].TypeName;
        }

        public void UnRegisterType(string name)
        {
            TypeInfo ti = typeslist.Find(tyinf => tyinf.TypeName == name);
            if (ti != null)
                typeslist.Remove(ti);
        }

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