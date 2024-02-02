using PersonCrud.Model;

namespace PersonCrud.Interface
{
    public interface IPerson
    {
        List<PersonModel> GetPersons();
        PersonModel GetPersonById(int id);
        bool InsertPerson(PersonModel person);
        bool UpdatePerson(PersonModel person);
        bool DeletePersonById(int id);
    }
}
