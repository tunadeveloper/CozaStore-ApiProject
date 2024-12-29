using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.DtoLayer.MessageDtos
{
    public class CreateMessageDto
    {
        public string UserEmail { get; set; }
        public string UserMessage { get; set; }
    }
}
