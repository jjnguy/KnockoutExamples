using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_C___Knockout_Intro.Models
{
    public class City
    {
        public string Name;
        public long Id;
        public string CountryCode;
        public long Population;
        public string District;

        public bool Editable
        {
            get
            {
                return Id > 4079;
            }
        }
    }
}
