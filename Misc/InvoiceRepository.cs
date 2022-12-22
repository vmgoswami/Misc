using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class InvoiceRepository
    {
        IQueryable<Invoice> _invoices;
        public InvoiceRepository(IQueryable<Invoice> invoices)
        {
            // Console.WriteLine("Sample debug output");
            this._invoices = invoices;
        }

        /// <summary>
        /// Should return a total value of an invoice with a given id. If an invoice does not exist null should be returned.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public decimal? GetTotal(int invoiceId)
        {
            decimal total = 0;

            var t = _invoices.Where(x => x.Id == invoiceId)
                .Select(x => x.InvoiceItems);

            foreach(var x in t)
            {

                var r = t.
            }

            foreach (var invoice in _invoices)
            {

                if (invoice.Id == invoiceId)
                {
                    var invoiceItem = invoice.InvoiceItems;
                    foreach (var ini in invoiceItem)
                    {
                        total = total + ini.Price;

                    }

                    return total;

                }

            }

            return total;
        }

        /// <summary>
        /// Should return a total value of all unpaid invoices.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalOfUnpaid()
        {
            decimal total = 0;
            foreach (var invoice in _invoices)
            {

                if (invoice.AcceptanceDate == null)
                {
                    var invoiceItem = invoice.InvoiceItems;
                    foreach (var ini in invoiceItem)
                    {
                        total = total + ini.Price;

                    }



                }

            }

            return total;
        }

        /// <summary>
        /// Should return a dictionary where the name of an invoice item is a key and the number of bought items is a value.
        /// The number of bought items should be summed within a given period of time (from, to). Both the from date and the end date can be null.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            Dictionary<string, long> dic = new Dictionary<string, long>();
            foreach (var invoice in _invoices)
            {


                var invoiceItem = invoice.InvoiceItems;
                foreach (var ini in invoiceItem)
                {
                    var thisTag = dic.FirstOrDefault(t => t.Key == ini.Name);
                    if (thisTag.Value <= 0)
                    {
                        var tot = Convert.ToDecimal(thisTag.) + ini.Price;
                        dic.Remove(ini.Name);
                        dic.Add(ini.Name, tot);
                    }
                    else

                        dic.Add(ini.Name, ini.Count);

                }





            }

            return dic;
        }
    }
}
