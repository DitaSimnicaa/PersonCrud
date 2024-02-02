using PersonCrud.DbConfigFile;
using PersonCrud.Interface;
using PersonCrud.Model;

namespace PersonCrud.Repository
{
    public class PersonRepository : IPerson
    {
        private readonly MyAppDbContext _context;
        public PersonRepository(MyAppDbContext context) 
        {  
            _context = context; 
        }

        public List<PersonModel> GetPersons()
        {
            return  _context.PersonModel.ToList();
            
        }

        public PersonModel GetPersonById(int id)
        {
            return _context.PersonModel.Where(x => x.Id == id).FirstOrDefault();            
        }

        public bool InsertPerson(PersonModel person)
        {            
            _context.Add(person);
            var saved = _context.SaveChanges();
            if(saved >  0)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePerson(PersonModel person)
        {
            var personFound = _context.PersonModel.Find(person.Id);
            if (personFound != null)
            {
                personFound.FirstName = person.FirstName;
                personFound.LastName = person.LastName;
                personFound.Gender = person.Gender;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePersonById(int id)
        {
            var personToDelete = _context.PersonModel.Find(id);
            if(personToDelete != null)
            {
                _context.Remove(personToDelete);
                var result = _context.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
