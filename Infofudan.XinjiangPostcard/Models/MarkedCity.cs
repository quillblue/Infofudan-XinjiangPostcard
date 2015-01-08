using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infofudan.XinjiangPostcard.Models
{
    public class MarkedCity
    {
        public string name;
        public int value;

        public MarkedCity(Place p) {
            this.name = p.CityName;
            if (p.Type == 0) {
                this.name += p.Detail;
            }
            this.value =Convert.ToInt32(p.Count);
        }
    }


}