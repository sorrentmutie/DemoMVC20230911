

namespace DemoMVC.Controllers;

public class PeopleController : Controller
{
    private readonly IPersonData data;
    private readonly IData<Person, Guid> idata;

    public PeopleController(IPersonData data, 
        IData<Person, Guid> idata)
    {
       this.data = data;
        this.idata = idata;
    }

    public IActionResult Index()
    {
        return View(idata.Get());
    }


    public IActionResult Details(Guid id)
    {
        return View(idata.Get(id));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        person.Id = Guid.NewGuid();
        idata.Add(person);
        return RedirectToAction("Index", "People");
    }


    public JsonResult GetJson() { 
        return Json(idata.Get()); } 

}
