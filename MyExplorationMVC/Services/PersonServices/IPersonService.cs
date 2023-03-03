using MyExplorationMVC.Models.PersonModels;

namespace MyExplorationMVC.Services.PersonServices
{
    public interface IPersonService
    {
        Task<bool> AddPerson(PersonCreate person);
        Task<bool> RemovePerson(int id);
        Task<bool> UpdatePerson(int id,PersonEdit model);
        Task<List<PersonListItem>> GetPeople();
        Task<PersonDetails> GetPerson(int id);
    }
}
