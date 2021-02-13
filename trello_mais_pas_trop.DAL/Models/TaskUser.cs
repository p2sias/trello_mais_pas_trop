using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace trello_mais_pas_trop.DAL.Models
{
    public class TaskUser
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public Task Task { get; set; }
    }
}
