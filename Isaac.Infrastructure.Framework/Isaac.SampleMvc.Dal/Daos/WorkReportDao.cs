using Dapper;
using Isaac.SampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dal.Daos
{
    public class WorkReportDao : CommonDao<WorkReport>
    {
        public IEnumerable<WorkReport> GetWorkReport(int authorId, int pageNum = 0, int pageLoad = 0)
        {
            return GetWorkReport(new int[] { authorId }, pageNum, pageLoad);
        }

        public IEnumerable<WorkReport> GetWorkReport(int[] authorIds, int pageNum = 0, int pageLoad = 0)
        {
            var result = Database.Connection.Query<WorkReport>(
                MySqlPagination(
                    "select * from doc_report where author_id in @AuthorIds order by author_id, create_time, last_updated_time",
                    pageNum,
                    pageLoad),
                new { AuthorIds = authorIds });

            return result;
        }

        public IEnumerable<WorkReport> GetWorkReport(Frequency frequency, DateTime capTime, DateTime floorTime, int pageNum = 0, int pageLoad = 0)
        {
            if (capTime > floorTime)
                return GetWorkReport(frequency, floorTime, capTime, pageNum, pageLoad);

            var result = Database.Connection.Query<WorkReport>(
                MySqlPagination(
                    "select * from doc_report where frequency = @Frequency and create_time >= @Cap and create_time < @Floor order by author_id, create_time, last_updated_time",
                    pageNum,
                    pageLoad),
                new { Frequency = frequency, Cap = capTime, Floor = floorTime });

            return result;
        }
    }
}
