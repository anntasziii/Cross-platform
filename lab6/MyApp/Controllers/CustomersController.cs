using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using System.Linq;
using System.Threading.Tasks;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _context.Customers
                                       .Include(c => c.RefCustomerType)
                                       .Include(c => c.EndUser)
                                       .Include(c => c.Company)
                                       .Include(c => c.CustomerMachines)
                                       .ToListAsync();

        return View(customers);
    }

    public IActionResult Create()
    {
        ViewBag.CustomerTypes = _context.RefCustomerTypes.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.CustomerTypes = await _context.RefCustomerTypes.ToListAsync();
        return View(customer);
    }

    public async Task<IActionResult> Details(int id)
    {
        var customer = await _context.Customers
                                      .Include(c => c.RefCustomerType)
                                      .Include(c => c.EndUser)
                                      .Include(c => c.Company)
                                      .Include(c => c.CustomerMachines)
                                      .FirstOrDefaultAsync(c => c.CustomerId == id);

        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _context.Customers
                                      .FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null)
        {
            return NotFound();
        }

        ViewBag.CustomerTypes = await _context.RefCustomerTypes.ToListAsync();
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.CustomerTypes = await _context.RefCustomerTypes.ToListAsync();
        return View(customer);
    }
    private async Task<bool> CustomerExists(int id)
    {
        return await _context.Customers.AnyAsync(c => c.CustomerId == id);
    }
}
