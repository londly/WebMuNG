using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebMuNG.Models
{
    [Keyless]
    public class Character
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public int cLevel { get; set; }
        public int Class { get; set; }
        public int MapNumber { get; set; }
        public int resets { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }
    }
}