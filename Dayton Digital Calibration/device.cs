using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayton_Digital_Calibration
{


    public class device
    {
        public string Company { get; set; }
        public string Technician { get; set; }
        public string Serial { get; set; }
        public Dictionary<int, List<float>> Response_bef { get; set; }
        public Dictionary<int, List<float>> Response_aft { get; set; }
        public string Notes { get; set; }
        public DateTime InsDate { get; set; }

        public device()
        {
            Response_bef = new Dictionary<int, List<float>>();
            Response_aft = new Dictionary<int, List<float>>();
            List<int> Frequencies = new List<int>() { 3, 4, 10, 20, 30, 40, 50, 60, 100 };
            foreach (int f in Frequencies)
            {
                Response_bef.Add(f, new List<float>() { 0, 1, 2 });
                Response_aft.Add(f, new List<float>() { 3, 4, 5 });
            }
        }
    }
}
