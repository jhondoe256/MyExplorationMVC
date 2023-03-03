using Microsoft.EntityFrameworkCore;
using MyExplorationMVC.Data;
using MyExplorationMVC.Models.PersonModels;

namespace MyExplorationMVC.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPerson(PersonCreate person)
        {
            var entity = new Person
            {
                Name= person.Name,
                Age= person.Age,
                PersonHeight= person.PersonHeight,
            };
            await _context.People.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PersonListItem>> GetPeople()
        {
            return await _context.People.Select(p => new PersonListItem
            {
                Id= p.Id,
                Name = p.Name,
            }).ToListAsync();
        }

        public async Task<PersonDetails> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if(person == null) { return null; }
            return new PersonDetails
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
            };
        }

        public async Task<bool> RemovePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null) { return false; }

            _context.People.Remove(person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePerson(int id, PersonEdit model)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null) { return false; }
            person.Name= model.Name;
            person.Age= model.Age;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
