using System;

namespace H3LibraryProject.API.DTOs
{
    public class LoanResponse
    {
        public int LoanId { get; set; }
        public int LoanerId { get; set; }
        public int MaterialId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public LoanLoanerResponse Loaner { get; set; }
        public LoanMaterialResponse Material { get; set; }
    }

    public class LoanLoanerResponse
    {
        public int LoanerId { get; set; }
        public int LoanerTypeId { get; set; }
        public string Name { get; set; }
        public string LoanerTypeName { get; set; }
    }

    public class LoanMaterialResponse
    {
        public int MaterialId { get; set; }
        public int TitleId { get; set; }
        public int LocationId { get; set; }
        public string TitleName { get; set; }

    }
}
