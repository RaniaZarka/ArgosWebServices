using System;
using System.Collections.Generic;
using System.Text;

namespace BookAssignmet
{
    public class TitleLenghtException: Exception
    {
        public TitleLenghtException() : base("Title should be at least 2 characters") { }

        public TitleLenghtException(string message) : base(message) { }

        public TitleLenghtException(string message, Exception inner) : base(message, inner) { }
    }
}
