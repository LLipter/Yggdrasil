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

        public int User_id { get => user_id; set => user_id = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string Passwd { get => passwd; set => passwd = value; }
        public string Nick_name { get => nick_name; set => nick_name = value; }
        public int Privilege { get => privilege; set => privilege = value; }
        public DateTime Register_date { get => register_date; set => register_date = value; }

        public User(int user_id, String user_name, String passwd, String nick_name, int privilege, DateTime register_date)
        {
            this.User_id = user_id;
            this.User_name = user_name;
            this.Passwd = passwd;
            this.Nick_name = nick_name;
            this.Privilege = privilege;
            this.Register_date = register_date;
        }
    }
}
