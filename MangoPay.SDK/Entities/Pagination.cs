using System;

namespace MangoPay.SDK.Entities
{
    /// <summary>Pagination class.</summary>
    public class Pagination
    {
        /// <summary>Page number.</summary>
        public int Page;

        /// <summary>Number of items per page.</summary>
        public int ItemsPerPage;

        /// <summary>Instantiates new Pagination object.</summary>
        public Pagination() : this(1, 10) { }

        /// <summary>Instantiates new Pagination object.</summary>
        /// <param name="page">Page number.</param>
        public Pagination(int page) : this(page, 10) { }

        /// <summary>Instantiates new Pagination object.</summary>
        /// <param name="page">Page number.</param>
        /// <param name="itemsPerPage">Number of items per page.</param>
        public Pagination(int page, int itemsPerPage)
        {
            this.Page = page;
            this.ItemsPerPage = itemsPerPage;
        }
    }
}
