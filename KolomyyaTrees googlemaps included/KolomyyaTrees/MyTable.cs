using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolomyyaTrees
{
    class MyTable
    {
        public MyTable(int t_id, float t_vik, string t_stan, string t_poroda, string t_plodu, string t_positionN, string t_positionE, string t_info)
        {
            this.t_id = t_id;
            this.t_vik = t_vik;
            this.t_stan = t_stan;
            this.t_poroda = t_poroda;
            this.t_plodu = t_plodu;
            this.t_positionN = t_positionN;
            this.t_positionE = t_positionE;
            this.t_info = t_info;
        }
        public int t_id { get; set; }
        public float t_vik { get; set; }
        public string t_stan { get; set; }
        public string t_poroda { get; set; }
        public string t_plodu { get; set; }
        public string t_positionN { get; set; }
        public string t_positionE { get; set; }
        public string t_info { get; set; }
    }
}
