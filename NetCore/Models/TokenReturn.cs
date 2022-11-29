namespace NetCore.Models
{
    public class TokenReturn
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public int ExpiredIn { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
