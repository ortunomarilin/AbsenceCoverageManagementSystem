using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer
{
    public class QueryOptions<T>
    {

        //Properties for Sorting 
        public Expression<Func<T, Object>> OrderBy { get; set; }


        //Properties for Paging 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        //Properties / private Variables for Filtering 
        private List<Expression<Func<T, bool>>> WhereExpressions;

        public Expression<Func<T, bool>> Where
        {
            set
            {
                //If the List that holds the where expressions is null initialize it so you can add the current Where Expression to the List.
                if(WhereExpressions == null)
                {
                    WhereExpressions = new List<Expression<Func<T, bool>>>();
                }
                WhereExpressions.Add(value);
            }
        }

        public List<Expression<Func<T, bool>>> GetWheres()
        {
            return WhereExpressions;
        }


        //Private Variable / Property / Get Method for Includes 

        //Will hold all the includes in a string array. 
        private string[] includes;
        
        //Will Take in a string representing the includes, and store them in the includes string array.  
        public string Include
        {
            set
            {
                includes = value.Replace(" ", "").Split(",");
            }
        }
      
        //Method to get the includes string array
        public string[] GetIncludes()
        {
            return includes;
        }
    }
}
