using System.Collections.Generic;

namespace ClarkCodingChallenge.Models
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}