using System.ComponentModel;

namespace RichDomain.API.Business.Domain.Enums;

public enum ECustomerType : ushort
{
    [Description("Client Ativo")]
    Active = 1,

    [Description("Client Passivo")]
    Passive
}
