using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Games_Genres.Models
{
    public class Player
    {
        public int PlayerId { get; set; }        
        public int? TeamId { get; set; }
        [JsonIgnore]
        public Team Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int StartedPlaying { get; set; }
        public int MoneyWon { get; set; }
        public int NumberOfTournamentsPlayed { get; set; }
        public int BiggestPrizeWon { get; set; }
    }
}
