using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siya.Madokwe.RestAPI.Models
{
    public class Ingredient
    {
        public string idIngredient { get; set; }
        public string strIngredient { get; set; }
        public string strDescription { get; set; }
        public string strType { get; set; }
        public string strAlcohol { get; set; }
        public object strABV { get; set; }
    }
}
