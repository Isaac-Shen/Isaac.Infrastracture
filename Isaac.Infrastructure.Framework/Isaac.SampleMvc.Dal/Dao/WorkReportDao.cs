using Isaac.SampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dal
{
    public class WorkReportDao : CommonDao<WorkReport>
    {
        public IEnumerable<WorkReport> GetWorkReport(string authorId, int pageNum, int pageLoad)
        {
            return null;
        }

        public IEnumerable<WorkReport> GetWorkReport(string[] authorIds, int pageNum, int pageLoad)
        {
            return null;
        }
    }
}
