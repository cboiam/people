using System.Collections.Generic;

namespace ValidPeople.Domain.Enumerations
{
    public class HobbyEnumeration : Enumeration
    {
        public static HobbyEnumeration None = new HobbyEnumeration(0, "None");
        public static HobbyEnumeration Gaming = new HobbyEnumeration(1, "Gaming");
        public static HobbyEnumeration Sports = new HobbyEnumeration(2, "Sports");
        public static HobbyEnumeration Fishing = new HobbyEnumeration(3, "Fishing");
        public static HobbyEnumeration Camping = new HobbyEnumeration(4, "Camping");
        public static HobbyEnumeration Yoga = new HobbyEnumeration(5, "Yoga");
        public static HobbyEnumeration Travel = new HobbyEnumeration(6, "Travel");
        public static HobbyEnumeration Calligraphy = new HobbyEnumeration(7, "Calligraphy");
        public static HobbyEnumeration Painting = new HobbyEnumeration(8, "Painting");
        public static HobbyEnumeration Drawing = new HobbyEnumeration(9, "Drawing");
        public static HobbyEnumeration Dancing = new HobbyEnumeration(10, "Dancing");
        public static HobbyEnumeration Music = new HobbyEnumeration(11, "Music");
        public static HobbyEnumeration Photography = new HobbyEnumeration(12, "Photography");
        public static HobbyEnumeration Pottery = new HobbyEnumeration(13, "Pottery");
        public static HobbyEnumeration Writing = new HobbyEnumeration(14, "Writing");
        public static HobbyEnumeration Magic = new HobbyEnumeration(15, "Magic");
        public static HobbyEnumeration Podcasting = new HobbyEnumeration(16, "Podcasting");
        public static HobbyEnumeration Blogging = new HobbyEnumeration(17, "Blogging");
        public static HobbyEnumeration Origami = new HobbyEnumeration(18, "Origami");
        public static HobbyEnumeration Woodworking = new HobbyEnumeration(19, "Woodworking");
        public static HobbyEnumeration BeerBrewing = new HobbyEnumeration(20, "Beer Brewing");
        public static HobbyEnumeration Coffee = new HobbyEnumeration(21, "Coffee");
        public static HobbyEnumeration Cooking = new HobbyEnumeration(22, "Cooking");
        public static HobbyEnumeration Gardening = new HobbyEnumeration(22, "Gardening");
        public static HobbyEnumeration Mixology = new HobbyEnumeration(23, "Mixology");
        public static HobbyEnumeration Astronomy = new HobbyEnumeration(24, "Astronomy");
        public static HobbyEnumeration Linguistics = new HobbyEnumeration(25, "Linguistics");
        public static HobbyEnumeration Meditation = new HobbyEnumeration(26, "Meditation");
        public static HobbyEnumeration Volunteering = new HobbyEnumeration(27, "Volunteering");

        public HobbyEnumeration() { }

        public HobbyEnumeration(int id, string name) 
            : base(id, name) { }

        public static IEnumerable<HobbyEnumeration> GetAll() => GetAll<HobbyEnumeration>();
    }
}