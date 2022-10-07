using System;
namespace CampeonatoTKD.Services.Exceptions
{ 
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
