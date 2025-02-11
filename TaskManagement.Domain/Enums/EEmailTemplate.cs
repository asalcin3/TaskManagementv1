using System.ComponentModel;

namespace TaskManagement.Domain.Enums;

public enum EEmailTemplate
{
    [Description("TM - Task created email")]
    TaskCreated = 1,
    [Description("TM - Task deleted email")] 
    TaskDeleted = 2,
    [Description("TM - Task completed email")]
    TaskCompleted = 3,

}