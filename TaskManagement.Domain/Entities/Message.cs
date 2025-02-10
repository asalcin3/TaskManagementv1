using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class Message
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Subject { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Body { get; set; }

        // we use this to schedule messages
        public DateTime ToSendOn { get; set; }
        public DateTime? WasSentOn { get; set; }
        public EMessageStatus Status { get; set; }
        public MessagePriority Priority { get; set; }
        public required EDeliveryMethod DeliveryMethod { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string ErrorMessage { get; set; }
        public EEmailTemplate EmailTemplateType { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string From { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string FromEmail { get; set; }
        public int RetryCount { get; set; }

        /* =================== Navigation properties =================== */
        public long? SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public long? ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
    }
}
