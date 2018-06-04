using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Model
{
    public class Publisher
    {
        private int publisher_id;
        private string publisher_name;

        public int Publisher_id { get { return publisher_id; } set { publisher_id = value; } }
        public string Publisher_name { get { return publisher_name; } set { publisher_name = value; } }

        public static Publisher noSuchPublisher = new Publisher();
    }
}
