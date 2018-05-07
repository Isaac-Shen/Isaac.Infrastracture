using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    public class Action
    {
        public int action_id { get;set;}

        public string action_name { get; set; }

        public string action_url { get; set; }

        public bool is_enable { get; set; }

        public DateTime create_time { get; set; }

        public DateTime last_updated_time { get; set; }
    }
}
