using System;

namespace BookAssignmet
{
    public class Book
    {
		/// <summary>
		/// instance fields 
		/// </summary>
		private string author;
		private string title;
		private int pageNumber;
		private string isbn13;

		/// <summary>
		/// default constructor public 
		/// </summary>
		public Book() { }
		/// <summary>
		/// public constrauctor with 4 parameters 
		/// </summary>
		/// <param name="Isbn13"></param>
		/// <param name="Author"></param>
		/// <param name="Title"></param>
		/// <param name="PageNumber"></param>
		public Book(string Isbn13, string Author, String Title, int PageNumber)
		{
			author = Author;
			title = Title;
			pageNumber = PageNumber;
			isbn13 = Isbn13;
		}

		/// <summary>
		/// public property that get and set the value of the Isbn13 property that should have 13 characters
		/// </summary>
		public string Isbn13
		{
			get { return isbn13; }
			set
			{
				if (value.Length != 13)
					throw new IsbnLengthException();
				else
					isbn13 = value;
			}
		}

		/// <summary>
		/// public property that get and set the value of Title that shoudl be more than 2 characters
		/// </summary>
		public string Title
		{
			get { return title; }
			set
			{
				if (value.Length < 2)
					throw new TitleLenghtException();
				else
					title = value;
			}
		}
		/// <summary>
		/// public property that get and set the value of the Author 
		/// </summary>
		public string Author
		{
			get { return author; }
			set { author = value; }
		}

		/// <summary>
		/// public property that get and set the value of the PageNumber that should be between 11 and 1000 
		/// </summary>
		public int PageNumber
		{
			get { return pageNumber; }
			set
			{
				if (value <= 10 || value > 1000)
					throw new PageNumberException();
				else
					pageNumber = value;
			}
		}

	}
}
