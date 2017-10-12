
using System.Windows.Controls;
using System.Windows.Media;

namespace Offline.Frame
{
    public class BaseFrame: UserControl
    {
        public string name;

        public virtual void OnLoaded()
        {

        }
        public virtual void OnUnLoaded()
        {

        }
        public BaseFrame(string name):base()
        {
            this.name = name;
        }
    }
}
