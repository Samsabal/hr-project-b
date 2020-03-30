using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class User
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Username")]
        public string Username { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
    
    class JSONUserList
    {
        [JsonProperty("users")]
        public List<User> users { get; set; }
    }
}
