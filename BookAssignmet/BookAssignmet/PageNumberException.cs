using System;
using System.Collections.Generic;
using System.Text;

namespace BookAssignmet
{
    public class PageNumberException: Exception
    {
        public PageNumberException() : base("Should between 11 and 1000 pages ") { }

        public PageNumberException(string message) : base(message) { }
        public PageNumberException(string message, Exception inner) : base(message, inner) { }
    }
}
