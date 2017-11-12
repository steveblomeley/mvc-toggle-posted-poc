using System;
using System.Collections.Generic;

namespace SwitchMode.Models
{
    public class Model
    {
        public IEnumerable<Day> Days { get; set; }
    }

    public class Day
    {
        public DateTime Date { get; set; }
        public string Iso8601Date => $"{Date:yyyy-MM-dd}";
        public IEnumerable<Value> Values { get; set; }
    }

    public class Value
    {
        public string Description { get; set; }
        public int ActualValue { get; set; }
        public bool Posted { get; set; }
    }
}