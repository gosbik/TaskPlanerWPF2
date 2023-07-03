using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisk
{
    public class users
    {
        public string Name { get; set; }
        public Dictionary<string,userTasks> Tasks { get; set; }
    }
}
