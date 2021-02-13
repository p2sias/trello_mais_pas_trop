using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trello_mais_pas_trop.DAL.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string state { get; set; }

        [JsonIgnore] 
        public ICollection<TaskUser> TaskUser { get; set; }
    }
}
