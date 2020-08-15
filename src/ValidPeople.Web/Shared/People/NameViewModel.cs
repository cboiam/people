namespace ValidPeople.Web.Shared.People
{
    public class NameViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFormattedName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
