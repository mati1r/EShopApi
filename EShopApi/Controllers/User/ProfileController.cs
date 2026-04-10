using Application.DTO.User.Profile;
using Core.DTO.User.Response;
using Core.IServices.User;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.User;

public class ProfileController(IProfileService profileService) : UserController
{
    private readonly IProfileService _profileService = profileService;

    [HttpGet]
    [Route("GetUserAddressData")]
    public async Task<ProfileGetUserAddressDataResponse> GetUserAddressData()
    {
        return await _profileService.GetUserAddressData(CurrentUserId);
    }

    [HttpGet]
    [Route("UpdateUserAddressData")]
    public async Task UpdateUserAddressData([FromBody] ProfileUpdateUserAddressData data)
    {
        await _profileService.UpdateUserAddressData(CurrentUserId, data.City, data.Street, data.HouseNumber, data.PostalCode, data.PhonePrefix, data.PhoneNumber, data.ApartmentNumber);
    }
}
