using Microsoft.AspNetCore.Mvc;
using CLAIM.SYSTEM.POE.Data;
using System.Linq;

namespace CLAIM.SYSTEM.POE.Controllers
{
    public class HRUserController : Controller
    {
        // GET: HRUser/Index - Displays a report of all approved claims
        public IActionResult Index()
        {
            // Filter claims to show only those that have been approved
            var approvedClaims = ClaimRepository.Claims
                                    .Where(c => c.Status == "Approved")
                                    .OrderByDescending(c => c.SubmissionDate)
                                    .ToList();

            // This list can be used to generate a simple "invoice" or payment report
            return View(approvedClaims);
        }

        // You can add other reporting actions here, like a Summary report
        public IActionResult SummaryReport()
        {
            // Example of a reporting calculation: Total money paid out
            double totalPaid = ClaimRepository.Claims
                                .Where(c => c.Status == "Approved")
                                .Sum(c => c.TotalAmount);

            ViewBag.TotalPaid = totalPaid;

            return View();
        }
    }
}