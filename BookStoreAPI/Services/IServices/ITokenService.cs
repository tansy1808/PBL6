namespace BookStoreAPI.Services.IServices
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}