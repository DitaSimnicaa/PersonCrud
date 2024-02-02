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
        public ModelToReturn GetPerson()
        {
            ModelToReturn modelToReturn = new ModelToReturn();

            var personsFound = _personInterface.GetPersons();
            if (personsFound.Count > 0)
            {
                foreach (var person in personsFound)
                {
                    modelToReturn.PersonModelList.Add(person);
                }
            }
            else
            {
                modelToReturn.Error = "No person found in database!";
            }

            return modelToReturn;

        }
        public ModelToReturn GetPersonById(int id)
        {
            ModelToReturn modelToReturn = new ModelToReturn();
            PersonModel personModel = _personInterface.GetPersonById(id);
            if (personModel != null)
                modelToReturn.PersonModelList.Add(personModel);
            else
                modelToReturn.Error = "No person found with that Id!";
            
            return modelToReturn;
        }

        public ModelToReturn InsertPersonToTable(PersonWrapper personModel)
        {
            ModelToReturn modelToRetrun = new ModelToReturn();
            PersonModel person = new PersonModel();
            if(personModel != null)
            {
                person.FirstName = personModel.FirstName;
                person.LastName = personModel.LastName;
                person.Gender = personModel.Gender;

                var result = _personInterface.InsertPerson(person);
                if (result)
                    modelToRetrun.Success = "Person inserted successfully!";
                else
                    modelToRetrun.Error = "Something failed to insert the person!";                
            }
            else
            {
                modelToRetrun.Error = "Person can't be null";
            }
            return modelToRetrun;
        }

        public ModelToReturn UpdatePersonToTable(PersonModel personModel)
        {
            ModelToReturn modelToReturn = new ModelToReturn();
            var result = _personInterface.UpdatePerson(personModel);
            if (result)
                modelToReturn.Success = "Person updated successfully";
            else
                modelToReturn.Error = "Something failed to update the person!";

            return modelToReturn;
        }

        public ModelToReturn DeletePersonById(int id)
        {   
            ModelToReturn modelToReturn = new ModelToReturn();
            var result = _personInterface.DeletePersonById(id);

            if (result)
                modelToReturn.Success = "Person deleted successfully!";
            else
                modelToReturn.Error = "Something failed to update the person!";

            return modelToReturn;

        }
    }
}
