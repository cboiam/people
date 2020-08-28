namespace ValidPeople.Web.Shared
{
    public class EnumerationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EnumerationViewModel model &&
                   Id == model.Id;
        }

        public override int GetHashCode() => Id;
    }
}
