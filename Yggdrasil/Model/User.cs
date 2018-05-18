using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Model
{
    class User
    {
        private int user_id;
        private String user_name;
        private String passwd;
        private String nick_name;
        private int privilege;
        private DateTime register_date;

        public int User_id { get { return user_id; } set { user_id = value; } }
        public string User_name { get { return user_name; } set { user_name = value; } }
        public string Passwd { get { return passwd; } set { passwd = value; } }
        public string Nick_name { get { return nick_name; } set { nick_name = value; } }
        public int Privilege { get { return privilege; } set { privilege = value; } }
        public DateTime Register_date { get { return register_date; } set { register_date = value; } }


    }
}
