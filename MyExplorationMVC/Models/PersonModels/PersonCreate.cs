using Microsoft.AspNetCore.Mvc.Rendering;
using MyExplorationMVC.Data;


namespace MyExplorationMVC.Models.PersonModels
{
    public class PersonCreate
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public PersonHeight? PersonHeight { get; set; }

        public IEnumerable<SelectListItem> PersonHeightSelection { get; set; }
    }
}
