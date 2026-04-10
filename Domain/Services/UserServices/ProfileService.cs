using Core.DTO.User.Response;
using Core.Exceptions;
using Core.IServices.User;
using Core.Models;
using Core.Models.EShop;
using Core.Specifications.Core;

namespace Core.Services.UserServices;

public class ProfileService(IRepository<User> userRepository) : IProfileService
{
    private readonly IRepository<User> _userRepository = userRepository;

    public async Task<ProfileGetUserAddressDataResponse> GetUserAddressData(int id)
    {
        var userWithAddress = await GetUserWithAddress(id);

        return new ProfileGetUserAddressDataResponse()
        {
            City = userWithAddress?.Address?.City,
            Street = userWithAddress?.Address?.Street,
            PostalCode = userWithAddress?.Address?.PostalCode,
            PhonePrefix = userWithAddress?.Address?.PhonePrefix,
            PhoneNumber = userWithAddress?.Address?.PhoneNumber,
            HouseNumber = userWithAddress?.Address?.HouseNumber,
            ApartmentNumber = userWithAddress?.Address?.ApartmentNumber,
        };
    }

    public async Task UpdateUserAddressData(int id, string city, string street, int houseNumber, string postalCode, string phonePrefix, string phoneNumber, int? apartmentNumber)
    {
        var userWithAddress = await GetUserWithAddress(id);

        if(userWithAddress.Address == null)
        {
            var address = new Address(city, street, houseNumber, postalCode, phoneNumber, phonePrefix, apartmentNumber);
            userWithAddress.Address = address;
            await _userRepository.UpdateAsync(userWithAddress);
        }
        else
        {
            userWithAddress.Address.Update(city, street, postalCode, phonePrefix, phoneNumber, houseNumber, apartmentNumber);
            await _userRepository.UpdateAsync(userWithAddress);
        }

    }

    private async Task<User> GetUserWithAddress(int id)
    {
        var userWithAddressSpec = new UniversalSpecification<User>(u => u.Id == id).AddInclude(u => u.Address!);
        return await _userRepository.FirstOrDefaultAsync(userWithAddressSpec) ?? throw new BadRequestException($"Could not found user with id {id}");
    }
}
