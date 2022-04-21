using System.Text.Json.Serialization;

namespace API_Games_Genres.Models
{
    public class TeamIM
    {               
        public string Name { get; set; }
        public string Place { get; set; }
        public string  Owner { get; set; }
        public int MembersCount { get; set; }
        public int MoneyWon { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
