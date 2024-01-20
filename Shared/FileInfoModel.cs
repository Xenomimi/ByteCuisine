using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class FileInfoModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public long LastModified { get; set; }
    }
}
