namespace BookStore.API.Services.IServices
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}