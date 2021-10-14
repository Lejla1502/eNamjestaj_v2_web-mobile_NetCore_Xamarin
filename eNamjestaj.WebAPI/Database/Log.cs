using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Ipaddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
