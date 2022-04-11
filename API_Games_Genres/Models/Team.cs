using System.Text.Json.Serialization;

namespace API_Games_Genres.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [JsonIgnore]
        public ICollection<Player> Players { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string  Owner { get; set; }
        public int MembersCount { get; set; }
        public int MoneyWon { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
