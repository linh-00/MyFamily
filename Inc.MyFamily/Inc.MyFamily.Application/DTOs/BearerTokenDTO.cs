namespace Inc.MyFamily.Application.DTOs
{
    public class BearerTokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
