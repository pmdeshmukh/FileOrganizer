namespace FileOrganizerHelper
{
    using System.Configuration;

    /// <summary>
    /// ConfigurationHelper class.
    /// </summary>
    /// <seealso cref="FileOrganizerHelper.IConfigurationHelper" />
    public sealed class ConfigurationHelper : IConfigurationHelper
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static ConfigurationHelper instance = null;

        /// <summary>
        /// The lock object
        /// </summary>
        private static readonly object lockObj = new object();

        /// <summary>
        /// Prevents a default instance of the <see cref="ConfigurationHelper"/> class from being created.
        /// </summary>
        ConfigurationHelper()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ConfigurationHelper Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationHelper();
                    }
                    return instance;
                }
            }
        }
        /// <summary>
        /// Gets the source file path.
        /// </summary>
        /// <returns>Source File Path.</returns>
        public string GetSourceFilePath()
        {
            try
            {
                return ConfigurationManager.AppSettings["SourceFilePath"];
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the destination file path.
        /// </summary>
        /// <returns>Destination File Path.</returns>
        public string GetDestinationFilePath()
        {
            try
            {
                return ConfigurationManager.AppSettings["DestinationFilePath"];
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
