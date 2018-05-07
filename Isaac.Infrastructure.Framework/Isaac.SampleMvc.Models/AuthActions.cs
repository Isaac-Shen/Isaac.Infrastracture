using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    public class AuthActions
    {
        public int auth_id { get; set; }

        public int role_id { get; set; }

        public int action_id { get; set; }

        public bool is_enable { get; set; }

        public DateTime create_time { get; set; }

        public DateTime last_updated_time { get; set; }
    }
}
