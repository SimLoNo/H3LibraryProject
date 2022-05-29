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
    }
}
