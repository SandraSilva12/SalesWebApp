using System;

namespace SalesWebMVC2.Services.Exceptions
{
	public class DbConcurrencyException : ApplicationException
	{
		public DbConcurrencyException(string message) : base(message)
		{

		}
	}
}
