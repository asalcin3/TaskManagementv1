using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
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
