namespace UserAPI.Data_View_Model
{
    public class UserVM
    {
        public string Id { get; set; }= null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Status { get; set; }
    }
}
