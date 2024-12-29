using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID { get; set; }
        public string UserEmail { get; set; }
        public string UserMessage { get; set; }
    }
}
