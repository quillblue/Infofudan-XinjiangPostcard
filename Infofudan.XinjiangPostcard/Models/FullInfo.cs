using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infofudan.XinjiangPostcard.Models
{
    public class FullInfo
    {
        public String CardId;
        public Postcard CardContent;
        public Place SenderPlace;
        public Place PhotoPlace;

        public FullInfo() 
        {
            CardContent = new Postcard();
            SenderPlace = new Place();
            PhotoPlace = new Place();
        }
    }
}