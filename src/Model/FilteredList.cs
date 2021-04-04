using System.Collections.Generic;

namespace Model
{
    public class FilteredList<T>
    {

        public Filter FilterUsed { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> List { get; set; }

    }
}