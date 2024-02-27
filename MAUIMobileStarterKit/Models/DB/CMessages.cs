using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.DB
{
    public class CMessages
    {
        [AutoIncrement]
        public int ID { get; set; }
        [PrimaryKey]
        public int MessageID { get; set; }
        public DateTime TimeSpan { get; set; }
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public bool Delete { get; set; }
    }
}
