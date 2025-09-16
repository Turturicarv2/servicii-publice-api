namespace ServiciiPubliceBackend.TokenManagers
{
    public interface ITokenManager
    {
        string GenerateJWTToken(string role);
    }
}