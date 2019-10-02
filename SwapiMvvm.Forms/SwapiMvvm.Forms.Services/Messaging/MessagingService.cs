using System;

namespace SwapiMvvm.Forms.Services.Messaging
{
    public class MessagingService
    {
        #region Fields

        // TODO

        #endregion

        #region Constructors

        // TODO

        #endregion

        #region Public

        public void SendErrorMessage(Exception exception)
        {
            // TEMP
            ServiceManager.LoggingService?.WriteException(exception);
        }

        // TODO

        #endregion

        #region Private

        // TODO

        #endregion
    }
}