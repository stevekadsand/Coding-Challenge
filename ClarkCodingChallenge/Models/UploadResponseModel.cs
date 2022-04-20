using System.Collections.Generic;

namespace ClarkCodingChallenge.Models
{
    public class UploadResponseModel
    {
        public string ResponseId { get; set; }

        public List<string> Errors { get; set; }

        public ContactViewModel Contact { get; set; }
    }
}