using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;
using RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;
using RichDomain.API.Business.Domain.Extensions;
using RichDomain.API.Business.Domain.ValueObjects;

namespace RichDomain.API.Business.ApplicationService.Mappers;

public sealed class PhoneMapper : IPhoneMapper
{
    public Phone DtoRegisterToDomain(PhoneCustomerRegisterRequest dtoPhone) =>
        new(dtoPhone.CellPhoneNumber,
            dtoPhone.TelephoneNumber);
}
