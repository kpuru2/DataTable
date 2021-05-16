using System;

namespace DataTable.BE
{
    /// <summary>
    /// Payement Details
    /// </summary>
    public class PayementDetails
    {
        /// <summary>
        /// AccountNumber
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Tax Year
        /// </summary>
        public int TaxYear { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Vendor Number
        /// </summary>
        public long VendorNumber { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Paid Date
        /// </summary>
        public DateTime? PaidDate { get; set; }

        /// <summary>
        /// Total Rows Count
        /// </summary>
        public int TotalRowsCount { get; set; }
    }
}
