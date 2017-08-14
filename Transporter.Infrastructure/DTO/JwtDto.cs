namespace Transporter.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        
        //ticks
        public long Expiry { get; set; }
    }
}