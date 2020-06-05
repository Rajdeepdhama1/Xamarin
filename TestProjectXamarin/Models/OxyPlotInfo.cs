using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXamarin.Models
{
    public class OxyPlotInfo
    {
        public string info { get; set; }
        public ICollection<OxyPlotItem> Items;
    }
}
