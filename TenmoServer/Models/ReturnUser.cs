namespace TenmoServer.Models
{
    /// <summary>
    /// Model to return upon successful login
    /// </summary>
    public class ReturnUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        //public string Role { get; set; } don't need role-based authentication
        public string Token { get; set; }

        public decimal Balance { get; set; }
    }
}
