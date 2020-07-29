using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMS.DataManage
{
    public class hnData
    {
        public string hnid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Prefix { get; set; }
        public string Age { get; set; }
        public string Birthdate { get; set; }
        public string Nationality { get; set; }
        public string ptype { get; set; }


        public string gethnData
        {
            get
            {
                return $"{hnid}{FirstName}{LastName})";

            }
        }

    }
}
