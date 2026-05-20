using Microsoft.AspNetCore.Mvc;
using CLAIM.SYSTEM.POE.Models;
using CLAIM.SYSTEM.POE.Data; // This allows us to access ClaimRepository
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace CLAIM.SYSTEM.POE.Controllers
{
    public class LecturerController : Controller
    {
        // GET: Show the form to submit a claim
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // POST: Process the data when the user clicks "Submit"
        [HttpPost]
        public async Task<IActionResult> SubmitClaim(Claim claim, IFormFile documentFile)
        {
            // ---------------------------------------------------------
            // AUTOMATION REQUIREMENT [Part 3]: Auto-calculate payment
            // ---------------------------------------------------------
            claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;

            // Set the initial status to "Pending"
            claim.Status = "Pending";

            // ---------------------------------------------------------
            // FILE UPLOAD REQUIREMENT
            // ---------------------------------------------------------
            if (documentFile != null && documentFile.Length > 0)
            {
                // 1. specific path to save files (wwwroot/uploads)
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                // Ensure the folder exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // 2. Create a unique file name to avoid duplicates
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + documentFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // 3. Save the file stream
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await documentFile.CopyToAsync(stream);
                }

                // 4. Save the filename in the database (list)
                claim.FileName = uniqueFileName;
            }

            // ---------------------------------------------------------
            // DATA STORAGE (Using List as per instructions)
            // ---------------------------------------------------------
            // Assign a simple ID (Current Count + 1)
            claim.ClaimId = ClaimRepository.Claims.Count + 1;

            // Add to the global list
            ClaimRepository.Claims.Add(claim);

            // Success! Go to the history page
            return RedirectToAction("ClaimHistory");
        }

        // GET: Show the list of claims submitted
        public IActionResult ClaimHistory()
        {
            // Pass the list of claims to the view
            return View(ClaimRepository.Claims);
        }
    }
}
