using System.ComponentModel;

namespace TaskManagement.Domain.Enums;

public enum EEmailTemplate
{
    [Description("TM - Task reminder email")]
    TaskReminder = 5,
    [Description("TM - Task finished email")] 
    TaskFinished = 10,
    
}