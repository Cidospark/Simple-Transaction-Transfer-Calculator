using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransferChargesCalculator.Pages
{
    public class IndexModel : PageModel
    {
        public AllAmounts CollectionOfAmounts { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            return Page();
        }
    }

    // amount object
    public class Amount
    {
        public int minAmount { get; set; }
        public int maxAmount { get; set; }
        public int feeAmount { get; set; }
    }

    // amount collection objects
    public class AllAmounts
    {
        public IEnumerable<Amount> Amounts { get; set; }
    }
}
