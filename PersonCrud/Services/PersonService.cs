using PersonCrud.Interface;
using PersonCrud.Model;

namespace PersonCrud.Services
{
    public class PersonService
    {
        private readonly IPerson _personInterface;
        public PersonService(IPerson personInterface)
        {
            _personInterface = personInterface;
        }
        public List<PersonModel> GetPerson()
        {
            List<PersonModel> personModels = new List<PersonModel>();

            var personsFound = _personInterface.GetPersons();
            foreach ( var person in personsFound )
            {
                personModels.Add(person);
            }

            return personModels;

        }
        public PersonModel GetPersonById(int id)
        {
            PersonModel result = _personInterface.GetPersonById(id);
            
            return result;
        }

        public bool InsertPersonToTable(PersonWrapper personModel)
        {
            PersonModel person = new PersonModel();
            if(personModel != null)
            {
                person.FirstName = personModel.FirstName;
                person.LastName = personModel.LastName;
                person.Gender = personModel.Gender;

                var result = _personInterface.InsertPerson(person);
                if (result)
                    return true;

                return false;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePersonToTable(PersonModel personModel)
        {
            var result = _personInterface.UpdatePerson(personModel);

            return result;
        }

        public bool DeletePersonById(int id)
        {
            var result = _personInterface.DeletePersonById(id);
            return result ? true : false;
        }
    }
}
