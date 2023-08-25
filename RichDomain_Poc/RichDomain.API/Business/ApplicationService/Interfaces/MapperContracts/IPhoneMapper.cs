using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.PhoneRequest;
using RichDomain.API.Business.Domain.ValueObjects;

namespace RichDomain.API.Business.ApplicationService.Interfaces.MapperContracts;

public interface IPhoneMapper
{
    Phone DtoRegisterToDomain(PhoneCustomerRegisterRequest dtoPhone);
}
