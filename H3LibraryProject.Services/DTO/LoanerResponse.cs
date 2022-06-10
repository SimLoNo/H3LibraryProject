using System;
using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class LoanerResponse
    {
        public int LoanerId {get; set;}
        public string LoanerName {get; set;}
        //public string Password { get; set; }

        public List<LoanerLoanResponse> Loans { get; set; } = new List<LoanerLoanResponse>();
        public LoanerLoanerTypeResponse TypeOfLoaner { get; set; } = new LoanerLoanerTypeResponse();
        //Sådan har den virket i mit program tidligere.

    }

    public class LoanerLoanResponse
    {
        public int LoanerId { get; set; }        
        public int MaterialId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class LoanerLoanerTypeResponse
    {
        public int LoanerTypeId { get; set; }
        public string Name { get; set; }
    }
}
