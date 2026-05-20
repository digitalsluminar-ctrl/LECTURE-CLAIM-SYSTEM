using CLAIM.SYSTEM.POE.Models;
using System.Collections.Generic;
using System.Linq;

namespace CLAIM.SYSTEM.POE.Data
{
    // This acts as your database
    public static class ClaimRepository
    {
        public static List<Claim> Claims = new List<Claim>();
        public static List<Lecturer> Lecturers = new List<Lecturer>();

        static ClaimRepository()
        {
            // Initialize with some sample data for testing if needed
        }
    }
}
