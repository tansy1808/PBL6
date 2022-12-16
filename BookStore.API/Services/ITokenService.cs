namespace BookStore.API.Services
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}