namespace Tasks.API.Domain.Dto.Token
{
    public class TokenRequest
    {
        public string RefreshToken { get; set; }
        public virtual string AccessToken { get; set; }

    }
}
