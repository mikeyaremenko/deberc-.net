using System.ComponentModel.DataAnnotations;

namespace debercApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Index { get; set; }
    }
}
