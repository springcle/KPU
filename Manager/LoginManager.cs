using Offline.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.Manager
{
    //SingleTone Proputy
    public partial class LoginManager
    {
        private static LoginManager Instance;
        public static LoginManager getInstance
        {
            get
            {
                if (Instance == null) Instance = new LoginManager();
                return Instance;
            }
        }
        private LoginManager() { }
    }
    public partial class LoginManager
    {
        public User currentLoginUser;

        public void signIn(string id)
        {
            currentLoginUser = new User(id, "temp", "temp", "temp", "temp");
        }
    
    }
}