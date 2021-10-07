using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurserTest8.Models
{
    public class Kurser
    {
        public int id { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public int Rate { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}