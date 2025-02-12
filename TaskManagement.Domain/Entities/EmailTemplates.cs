using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    [Index(nameof(EmailTemplate), IsUnique = true)]
    public class EmailTemplates
    {
        [Key]
        public long Id { get; set; }
        public string Subject { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Body { get; set; }
        public EEmailTemplate EmailTemplate { get; set; }

    }
}
