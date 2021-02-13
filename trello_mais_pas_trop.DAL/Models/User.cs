using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace trello_mais_pas_trop.DAL.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //[JsonIgnore]
        public ICollection<TaskUser> TaskUser { get; set; }

    }
}
