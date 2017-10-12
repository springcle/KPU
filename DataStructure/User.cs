using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.DataStructure
{
    public class User
    {
        public string id { get; private set; }
        public string pswd { get; private set; }
        public string name { get; private set; }
        public string sex { get; private set; }
        public string age { get; private set; }

        public User(string id, string pswd, string name, string sex, string age)
        {
            this.id = id;
            this.pswd = pswd;
            this.name = name;
            this.sex = sex;
            this.age = age;
        }
    }
}
