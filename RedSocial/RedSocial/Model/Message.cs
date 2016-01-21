using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Model
{
    public class Message
    {
        public string IdOwner { get; set; }
        public string IdFriend { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
    }
}
