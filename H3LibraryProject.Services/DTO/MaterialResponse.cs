using System;
using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class MaterialResponse
    {
        public int MaterialId { get; set; }
        public bool Home { get; set; }
        public int LocationId { get; set; }
        public int TitleId { get; set; }


        public List<MaterialLoanResponse> Loans { get; set; } = new List<MaterialLoanResponse>();
        //Sådan har den virket i mit program tidligere.
        public MaterialTitleResponse Title { get; set; }
        public MaterialLocationResponse Location { get; set; }

    }

    public class MaterialLoanResponse
    {
        public int LoanerId { get; set; }
        public int MaterialId { get; set; }
        public int PublisherId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class MaterialTitleResponse
    {
        public int TitleId { get; set; }
        public string Name { get; set; }

        public int RYear { get; set; }
        public int Pages { get; set; }

    }

    public class MaterialLocationResponse
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}
