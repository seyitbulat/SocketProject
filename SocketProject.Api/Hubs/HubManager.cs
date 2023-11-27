using SocketProject.Api.Models;

namespace SocketProject.Api.Hubs
{
    public class HubManager
    {
        public HubModel hubModel { get; set; }

        public HubManager(HubModel hubModel)
        {
            this.hubModel = hubModel;
        }

        public void AddUser(string user1, string user2)
        {
            hubModel.Users.AddRange(new List<User> { new User { UserName = user1 }, new User { UserName = user2 } });
        }

        public string AddGroup(string user1, string user2)
        {

            AddUser(user1, user2);

            var groupName = "";

            if (hubModel.GroupNames.Any(e => e.Equals($"{user2}-{user1}")))
            {
                groupName = $"{user2}-{user1}";
            }
            else
            {
                groupName = $"{user1}-{user2}";
                hubModel.GroupNames.Add(groupName);
            }

            return groupName;
        }
        

        public string FindGroupByUsers(string user1, string user2)
        {

            var finded = hubModel.GroupNames.Where(e => e.Contains(user1)).Where(e => e.Contains(user2)).FirstOrDefault();
            return finded;
        }
    }
}
