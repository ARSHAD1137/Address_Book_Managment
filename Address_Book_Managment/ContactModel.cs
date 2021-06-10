using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Managment
{
    public class ContactModel
    {
        public int Contact_Id { get; set; }
        public string Contact_Address { get; set; }
        public string Contact_City { get; set; }
        public int Contact_ZipCode { get; set; }
    }
}
