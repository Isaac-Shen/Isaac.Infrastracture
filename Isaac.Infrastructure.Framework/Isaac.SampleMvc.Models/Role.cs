using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    public class Role
    {
        public int role_id { get; set; }

        public string role_name { get; set; }

        public bool is_enabled { get; set; }

        public DateTime create_time { get; set; }

        public DateTime last_updated_time { get; set; }
    }
}
