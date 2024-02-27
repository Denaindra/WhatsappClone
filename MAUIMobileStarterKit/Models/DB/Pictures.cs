using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.DB
{
    public class Pictures
    {

        [AutoIncrement]
        public int ID { get; set; }
        [PrimaryKey]
        public int PictureID { get; set; }
        public byte[] Picture { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
    }
}
