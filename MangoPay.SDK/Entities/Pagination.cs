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

        /// <summary>Number of total pages.</summary>
        public int TotalPages;

        /// <summary>Number of total items.</summary>
        public int TotalItems;

        /// <summary>
        /// Four-elements array with links to navigation. All values are optional. Format:
        /// Links[0] -> first, 
        /// Links[1] -> previous, 
        /// Links[2] -> next, 
        /// Links[3] -> last.
        /// </summary>
        public String[] Links;

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
            this.Links = new String[4];
            this.Page = page;
            this.ItemsPerPage = itemsPerPage;
        }
    }
}
