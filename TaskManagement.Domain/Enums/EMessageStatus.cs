using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Enums
{
    public enum EMessageStatus
    {
        ReadyForSending = 10,
        Sent = 20,
        Error = 30,
        Fatal = 40
    }
}
