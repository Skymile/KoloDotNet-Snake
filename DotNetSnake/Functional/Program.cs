using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional
{
	class Randomizer
	{
		public static IEnumerable<int> GetRandomNumbers(
				int count, 
				int cap,
				int seed = 0
			)
		{
			var random = new Random(seed);
			for (int i = 0; i < count; i++)
				yield return random.Next() % cap;
		}
	}

	class RefType
	{
		public int Property { get; set; }
	}


	// Ref Types
	// Value Types

	// Pass-by-value
	// Pass-by-reference
	class Author
	{
		public int    Id   { get; set; }
		public string Name { get; set; }
	}

	class Book
	{
		public int    Id    { get; set; }
		public string Title { get; set; }
	}

	class BookAuthor
	{
		public int AuthorId { get; set; }
		public int BookId   { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{

			Author[] authors =
			{
				new Author { Id = 1, Name = "Author1" },
				new Author { Id = 2, Name = "Author2" },
				new Author { Id = 3, Name = "Author3" },
			};

			Book[] books =
			{
				new Book { Id = 14, Title = "14 Book" },
				new Book { Id = 15, Title = "15 Book" },
				new Book { Id = 16, Title = "16 Book" },
				new Book { Id = 17, Title = "17 Book" },
				new Book { Id = 18, Title = "18 Book" },
				new Book { Id = 19, Title = "19 Book" },
				new Book { Id = 20, Title = "20 Book" },
				new Book { Id = 21, Title = "21 Book" },
			};

			BookAuthor[] bookAuthors =
			{
				new BookAuthor { AuthorId = 1, BookId = 14 },
				new BookAuthor { AuthorId = 1, BookId = 15 },
				new BookAuthor { AuthorId = 1, BookId = 16 },
				new BookAuthor { AuthorId = 2, BookId = 17 },
				new BookAuthor { AuthorId = 2, BookId = 19 },
			};
			/*
			SELECT i.Name 
			FROM Authors
			JOIN bookAuthors link ON i.Id = link.AuthorId
			JOIN books book ON book.Id = link.AuthorId
			WHERE i.Id = 1
			*/
var listQuery = (
	from i in authors
	where i.Id == 1
	join link in bookAuthors on i.Id equals link.AuthorId
	join book in books on link.BookId equals book.Id
	orderby i.Name
	group book by i.Name 
).ToDictionary(i => i.Key, i => i.ToArray());

			foreach (var i in list)
				Console.WriteLine(i.Key);
			Console.ReadLine();
		}
	}
}
