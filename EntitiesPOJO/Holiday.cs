using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPOJO
{
    public class Holiday : BaseEntity
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
    }
}
