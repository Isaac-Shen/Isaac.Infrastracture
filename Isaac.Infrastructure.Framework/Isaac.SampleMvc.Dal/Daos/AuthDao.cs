using Dapper;
using Isaac.SampleMvc.Dtos;
using Isaac.SampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dal.Daos
{
    public class AuthDao : CommonDao<UserAuth>
    {
        public UserAuth GetAuthActions(int userId)
        {
            var sql = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                "select e.staff_id,e.staff_name,f.role_name,f.action_name,f.action_url from ",
                "per_staff e join(Select d.role_id, d.role_name, c.action_name, c.action_url from ",
                "config_action c join ",
                "(Select a.action_id, b.role_id, b.role_name from config_role_authentication a join config_role b on a.role_id = b.role_id) d ",
                "on c.action_id = d.action_id) f ",
                "on e.role_id = f.role_id ",
                "Where e.staff_id = @Id");

            var result = Database.Connection.Query<UserAuthAction>(sql, new { Id = userId });

            if (result != null)
            {
                var auth = new UserAuth()
                {
                    UserId = result.FirstOrDefault().staff_id,
                    UserName = result.FirstOrDefault().staff_name,
                    UserActions = new List<UserAction>()
                };

                foreach (var item in result)
                {
                    var action = new UserAction()
                    {
                        ActionName = item.action_name,
                        ActionUrl = item.action_url
                    };

                    auth.UserActions.Add(action);
                }

                return auth;
            }

            return null;
        }
    }
}
