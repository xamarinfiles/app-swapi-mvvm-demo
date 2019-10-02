using System;
using FancyLogger;
using SwapiMvvm.Forms.Services.Messaging;

namespace SwapiMvvm.Forms.Services
{
    public class ServiceManager
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public ServiceManager()
        {
            try
            {
                LoggingService = new FancyLoggerService();

                MessagingService = new MessagingService();
            }
            catch (Exception exception)
            {
                LoggingService?.WriteException(exception);
            }
        }

        #endregion

        #region Public

        public static FancyLoggerService LoggingService { get; private set; }

        public static MessagingService MessagingService { get; private set; }

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