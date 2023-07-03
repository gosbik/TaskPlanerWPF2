using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Poisk
{
    public class userTasks
    {
        public string Date { get; set; }
        public string DateClose { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }

    [JsonIgnore]
        public users user { get; set; }
    }
}
