namespace SocketProject.Api.Models
{
    public class HubModel
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<string> GroupNames { get; set; } = new List<string>();
    }
}
