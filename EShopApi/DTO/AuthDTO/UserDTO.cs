namespace ApiTemplate.DTO.AuthDTO;

public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }
}
