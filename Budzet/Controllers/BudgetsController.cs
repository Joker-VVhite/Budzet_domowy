using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budzet.Data;
using Budzet.Models;

namespace Budzet.Controllers
{
    public class BudgetsController : Controller
    {
        private readonly BudzetContext _context;

        public BudgetsController(BudzetContext context)
        {
            _context = context;
        }

        // GET: Budgets
        public async Task<IActionResult> Index()
        {
            // Pobierz transakcje z załadowanymi kategoriami
            var transactions = await _context.Transaction
                .Include(t => t.Category) // Ładujemy kategorię przez relację klucza obcego
                .ToListAsync();

            // Oblicz całkowity budżet
            decimal totalBudget = transactions
                .Where(t => t.Type == "Wpłata").Sum(t => t.Amount)
                - transactions.Where(t => t.Type == "Wypłata").Sum(t => t.Amount);

            // Grupowanie transakcji według kategorii
            var groupedData = transactions
                .Where(t => t.Category != null) // Ignoruj transakcje bez kategorii
                .GroupBy(t => t.Category.Name)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(t => t.Amount)
                })
                .ToList();

            // Przygotowanie danych do ViewBag
            ViewBag.TotalBudget = totalBudget; // Całkowity budżet
            ViewBag.LastTransactions = transactions.OrderByDescending(t => t.Date).Take(5); // Ostatnie 5 transakcji
            ViewBag.ChartLabels = groupedData.Select(g => g.Category).ToArray();
            ViewBag.ChartData = groupedData.Select(g => g.Total).ToArray();
            ViewBag.ChartColors = groupedData.Select(_ => $"#{new Random().Next(0x1000000):X6}").ToArray(); // Losowe kolory

            return View(transactions); // Przekazujemy transakcje do widoku
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget
                .FirstOrDefaultAsync(m => m.BudgetId == id);
            if (budget == null)
            {
                return NotFound();
            }

            var transactions = await _context.Set<Transaction>().ToListAsync();
            decimal totalAmount = transactions.Where(t => t.Type == "Wpłata").Sum(t => t.Amount) - transactions.Where(t => t.Type == "Wypłata").Sum(t => t.Amount);

            ViewBag.TotalAmount = totalAmount;
            ViewBag.LastTransactions = transactions.Take(5);

            return View(budget);
        }


        // GET: Budgets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BudgetId,TotalAmount")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BudgetId,TotalAmount")] Budget budget)
        {
            if (id != budget.BudgetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.BudgetId))
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
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget
                .FirstOrDefaultAsync(m => m.BudgetId == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budget = await _context.Budget.FindAsync(id);
            if (budget != null)
            {
                _context.Budget.Remove(budget);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetExists(int id)
        {
            return _context.Budget.Any(e => e.BudgetId == id);
        }
    }
}
