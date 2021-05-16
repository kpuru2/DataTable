namespace DataTable.DL
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        public struct StoredProcedure
        {
            public struct GetPaymentDetails
            {
                public const string Name = "usp_GetPaymentsDetails";
                public struct Parameters
                {
                    public const string PageNumber = "@pageNumber";
                    public const string PageSize = "@pageSize";
                    public const string AccountSearch = "@accountSearch";
                    public const string SortColumn = "@sortColumn";
                    public const string SortOrder = "@sortOrder";
                }
            }
        }
    }
}
