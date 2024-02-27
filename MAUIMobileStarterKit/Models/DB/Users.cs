using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.DB
{
    public class Users
    {
        [AutoIncrement]
        public int ID { get; set; }
        [PrimaryKey]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public byte[] UserProfileImg { get; set; }
        public string Role { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
