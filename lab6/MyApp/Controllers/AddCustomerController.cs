using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Data;
using System.Threading.Tasks;

public class AddCustomerController : Controller
{
    private readonly ApplicationDbContext _context;

    public AddCustomerController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        ViewBag.CustomerTypes = _context.RefCustomerTypes.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CustomerId,Name,Address,PhoneNumber,CustomerTypeCode,CompanyId")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Customers");
        }

        ViewBag.CustomerTypes = await _context.RefCustomerTypes.ToListAsync();
        return View(customer);
    }
}
