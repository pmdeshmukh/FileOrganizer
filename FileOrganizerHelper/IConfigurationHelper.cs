namespace FileOrganizerHelper
{
    /// <summary>
    /// IConfigurationHelper interface.
    /// </summary>
    public interface IConfigurationHelper
    {
        /// <summary>
        /// Gets the destination file path.
        /// </summary>
        /// <returns>Destination file path.</returns>
        string GetDestinationFilePath();

        /// <summary>
        /// Gets the source file path.
        /// </summary>
        /// <returns>Source file path.</returns>
        string GetSourceFilePath();
    }
}