using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Model
{
    class Type
    {
        private int type_id;
        private int ptype_id;
        private string type_name;

        public int Type_id { get { return type_id; } set { type_id = value; } }
        public int Ptype_id { get { return ptype_id; } set { ptype_id = value; } }
        public string Type_name { get { return type_name; } set { type_name = value; } }

        public static Type noSuchType = new Type();
    }
}
