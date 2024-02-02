namespace PersonCrud.Model
{
    public class ModelToReturn
    {
        public List<PersonModel> PersonModelList { get; set; } = new List<PersonModel>();
        public string Error { get; set; } = null;
        public string Success { get; set; } = null;
    }
}
