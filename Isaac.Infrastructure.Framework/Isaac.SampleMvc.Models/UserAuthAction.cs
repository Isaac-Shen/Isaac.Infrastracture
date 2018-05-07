using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    public class UserAuthAction
    {
        public int staff_id { get; set; }

        public string staff_name { get; set; }

        public string role_name { get; set; }

        public string action_name { get; set; }

        public string action_url { get; set; }
    }
}
