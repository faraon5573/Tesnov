using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public partial class users
    {
        public bool TooOld { get => (DateTime.Now - dr).Days >= 365; }
    }

    public partial class auth
    {
        public int TooOld1 { get
            {
                if (users.name == null)
                    return 1;
                else return 0;
            }
        }
        //public bool TooOld1 { get => (users.gender == null); }
    }
}
