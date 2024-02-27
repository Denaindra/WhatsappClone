using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.DB
{
    public class Threads
    {
        [AutoIncrement]
        public int ID { get; set; }
        [PrimaryKey]
        public int ThreadID { get; set; }
        public string Title { get; set; }
        [AllowNull]
        public string Name { get; set; }
        public int PictureID { get; set; }
        public bool DUO { get; set; }
        public string Note { get; set; }
        public bool Archive { get; set; }
        public bool Pinned { get; set; }
        public bool Deleted { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
