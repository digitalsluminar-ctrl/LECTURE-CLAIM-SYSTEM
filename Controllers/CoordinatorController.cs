using Microsoft.AspNetCore.Mvc;
using CLAIM.SYSTEM.POE.Data; // Access to our ClaimRepository list
using CLAIM.SYSTEM.POE.Models;
using System.Linq;

namespace CLAIM.SYSTEM.POE.Controllers
{
    public class CoordinatorController : Controller
    {
        // GET: Coordinator/Index - Displays all claims
        public IActionResult Index()
        {
            // Fetch all claims, ordered by submission date (newest first)
            var claims = ClaimRepository.Claims.OrderByDescending(c => c.SubmissionDate).ToList();
            return View(claims);
        }

        // AUTOMATION: Approve Action
        public IActionResult Approve(int id)
        {
            // Find the claim using the ID passed from the view
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.ClaimId == id);

            if (claim != null)
            {
                // Core automation: Update the status
                claim.Status = "Approved";
            }

            // Redirect back to the dashboard to show the updated status
            return RedirectToAction("Index");
        }

        // AUTOMATION: Reject Action
        public IActionResult Reject(int id)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.ClaimId == id);

            if (claim != null)
            {
                // Core automation: Update the status
                claim.Status = "Rejected";
            }

            return RedirectToAction("Index");
        }
    }
}