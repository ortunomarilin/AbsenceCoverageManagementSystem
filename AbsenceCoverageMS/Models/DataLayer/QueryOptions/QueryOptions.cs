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
        public string OrderByDirection { get; set; } = "asc";


        //Properties for Paging 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        //Will hold all the where in a class with List of Where(s). 
        public WhereExpressions<T> WhereExpressions { get; set; }

        public Expression<Func<T, bool>> Where
        {
            set
            {
                //If the List that holds the where expressions is null initialize it so you can add the current Where Expression to the List.
                if (WhereExpressions == null)
                {
                    WhereExpressions = new WhereExpressions<T>();
                }
                WhereExpressions.Add(value);
            }
        }



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



        //Set Flags 
        public bool HasInclude => GetIncludes() != null;
        public bool HasWhere => WhereExpressions != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasPaging => PageNumber > 0 && PageSize > 0;

    }



    //For the pupose of workign with multiple Where clauses. 
    //This class will contain a list of where expressions. 
    public class WhereExpressions<T> : List<Expression<Func<T, bool>>> { }



}