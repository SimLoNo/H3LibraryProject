using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class LoanerResponse
    {
        public int LoanerId {get; set;}
        public string LoanerName {get; set;}

        public List<LoanerLoanResponse> Loans { get; set; } = new List<LoanerLoanResponse>();
        //Sådan har den virket i mit program tidligere.

    }

    public class LoanerLoanResponse
    {
        public int LoanerId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int RYear { get; set; }
        public int Pages { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
    }
}
