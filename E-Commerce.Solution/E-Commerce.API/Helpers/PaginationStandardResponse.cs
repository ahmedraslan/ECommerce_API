using E_Commerce.API.DTOs;
using System.Collections.Generic;

namespace E_Commerce.API.Helpers
{
    public class PaginationStandardResponse<T>  //Standard class for any endpoint use pagination
    {
        
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }


        public PaginationStandardResponse(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

    }
}
