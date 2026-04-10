using Core.DTO.User.Response;

namespace Core.IServices.User;

public interface IProfileService
{
    public Task<ProfileGetUserAddressDataResponse> GetUserAddressData(int id);
    public Task UpdateUserAddressData(int id, string city, string street, int houseNumber, string postalCode, string phonePrefix, string phoneNumber, int? apartmentNumber);
}
