using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyExplorationMVC.Data;
using MyExplorationMVC.Models;
using MyExplorationMVC.Models.PersonModels;
using MyExplorationMVC.Services.PersonServices;

namespace MyExplorationMVC.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _personService.GetPeople());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var personCreate = new PersonCreate();

            var personHeightList = new List<PersonHeight>() {
            PersonHeight.Tall,
            PersonHeight.Average,
            PersonHeight.Small,

            };

            var personHListItem = personHeightList.Select(p => new SelectListItem
            {
                Text=p.ToString(),
                Value=p.ToString()
            });

            personCreate.PersonHeightSelection = personHListItem;

            return View(personCreate);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(PersonCreate person)
        {
            var personHeightList = new List<PersonHeight>() {
            PersonHeight.Tall,
            PersonHeight.Average,
            PersonHeight.Small,

            };

            var personHListItem = personHeightList.Select(p => new SelectListItem
            {
                Text = p.ToString(),
                Value = p.ToString()
            });
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (await _personService.AddPerson(person)) { return RedirectToAction(nameof(Index)); }
            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var person = await _personService.GetPerson(id);
            if(person != null) 
            {
                return View(person);
            }
            return NotFound();
        }

    }
}
