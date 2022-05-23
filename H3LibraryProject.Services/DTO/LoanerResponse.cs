using System;
using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class LoanerResponse
    {
        public int LoanerId {get; set;}
        public string LoanerName {get; set;}
        public string Password { get; set; }

        public List<LoanerLoanResponse> Loans { get; set; } = new List<LoanerLoanResponse>();
        //Sådan har den virket i mit program tidligere.

    }

    public class LoanerLoanResponse
    {
        public int LoanerId { get; set; }        
        public int MaterialId { get; set; }
        public int PublisherId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
