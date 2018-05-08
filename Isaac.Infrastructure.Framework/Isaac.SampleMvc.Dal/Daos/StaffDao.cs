using Dapper;
using Isaac.SampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dal.Daos
{
    public class StaffDao : CommonDao<Staff>
    {
        public Staff GetStaff(int staffId)
        {
            var result =
                Database.Connection.ExecuteScalar<Staff>(
                    "select * from per_staff where staff_id = @Id limit 1",
                    new { Id = staffId });

            return result;
        }

        public Staff GetStaffById(string identityId)
        {
            var result =
                Database.Connection.ExecuteScalar<Staff>(
                    "select * from per_staff where identity_id = @Id limit 1",
                    new { Id = identityId });

            return result;
        }

        public bool ValidatePhonePass(string phoneNumber, string password)
        {
            var result =
                Database.Connection.ExecuteScalar<bool>(
                    string.Format("select @Pass = (select pass from per_staff_pass where phone_number = @PhoneNumber)"),
                    new { PhoneNumber = phoneNumber, Pass = password });

            return result;
        }

        public bool ValidatePass(int staffId, string password)
        {
            var result =
                Database.Connection.ExecuteScalar<bool>(
                    string.Format("select @Pass = (select pass from per_staff_pass where staff_id = @Id)"),
                    new { Id = staffId, Pass = password });

            return result;
        }
    }
}
