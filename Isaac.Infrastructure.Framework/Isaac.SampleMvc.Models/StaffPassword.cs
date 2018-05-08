using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    public class StaffPassword
    {
        public int pass_id { get; set; }

        public int staff_id { get; set; }

        public string pass { get; set; }

        public bool is_expired { get; set; }

        public DateTime expire_time { get; set; }

        public DateTime create_time { get; set; }

        public DateTime last_updated_time { get; set; }
    }
}
