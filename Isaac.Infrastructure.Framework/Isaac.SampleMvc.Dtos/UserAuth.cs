using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dtos
{
    public class UserAuth
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public List<UserAction> UserActions { get; set; }
    }
}
