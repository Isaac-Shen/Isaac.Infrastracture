using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dtos
{
    public class UserAuth
    {
        public int WorkId { get; set; }

        public List<AuthAction> AuthActions { get; set; }
    }
}
