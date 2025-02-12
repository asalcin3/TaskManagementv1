using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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

        public DateTime? WasSentOn { get; set; }
        public EMessageStatus Status { get; set; }
        public required EDeliveryMethod DeliveryMethod { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? ErrorMessage { get; set; }
        public EEmailTemplate EmailTemplateType { get; set; }


        /* =================== Navigation properties =================== */
        public long? SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public long? ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
    }
}
