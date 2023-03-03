using MyExplorationMVC.Data;

namespace MyExplorationMVC.Models.PersonModels
{
    public class PersonCreateVM
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonHeight? PersonHeight { get; set; }
    }
}
