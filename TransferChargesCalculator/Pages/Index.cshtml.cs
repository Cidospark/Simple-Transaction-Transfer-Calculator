using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Newtonsoft.Json;

namespace TransferChargesCalculator.Pages
{
    public class IndexModel : PageModel
    {

        public AllFees CollectionofFees { get; set; }

        [BindProperty]
        public int Transfer { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string filePath = "./wwwroot/file/fees.config.json";
                try
                {
                    string jsonRecord;
                    using (var readerObj = new StreamReader(filePath))
                    {
                        jsonRecord = readerObj.ReadToEnd();
                        CollectionofFees = JsonConvert.DeserializeObject<AllFees>(jsonRecord);
                    }

                    var transferCharge = from t in CollectionofFees.Fees
                                         where Transfer <= t.maxAmount && Transfer >= t.minAmount
                                         select t.feeAmount;

                    ViewData["result"] = transferCharge.FirstOrDefault().ToString();
                    ViewData["tranferAmount"] = Transfer;


                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
            return Page();
        }
    }

    // amount object
    public class FeeObject
    {
        public int minAmount { get; set; }
        public int maxAmount { get; set; }
        public int feeAmount { get; set; }
    }

    // amount collection objects
    public class AllFees
    {
        public IEnumerable<FeeObject> Fees { get; set; }
    }
}
