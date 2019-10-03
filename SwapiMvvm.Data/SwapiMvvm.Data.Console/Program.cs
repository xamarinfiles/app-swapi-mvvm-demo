using System;
using FancyLogger;

namespace SwapiMvvm.Data.Console
{
    public class Program
    {
        #region Fields

        #endregion

        #region Constructors

        static void Main(string[] args)
        {
            try
            {
                LoggingService = new FancyLoggerService();

                LoggingService.WriteLine("Hello World!");
            }
            catch (Exception exception)
            {
                LoggingService?.WriteException(exception);
            }
        }

        #endregion

        #region Public

        public static FancyLoggerService LoggingService { get; private set; }

        #endregion

        #region Interface

        #endregion

        #region Protected

        #endregion

        #region Internal

        #endregion

        #region Private

        #endregion

        #region Nested Types

        #endregion
    }
}
