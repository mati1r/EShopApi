namespace ApiTemplate.Models;

public class Tokens
{
    public int Id { get; set; } 
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; } 

    public bool IsValid { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }


    public Tokens()
    {
        AccessToken = "";
        RefreshToken = "";
        IsValid = true;
    }
}
