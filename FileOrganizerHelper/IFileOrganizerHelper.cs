namespace FileOrganizerHelper
{
    /// <summary>
    /// IFileOrganizerHelper interface.
    /// </summary>
    public interface IFileOrganizerHelper
    {
        /// <summary>
        /// Organizes the files.
        /// </summary>
        /// <param name="sourceFolderPath">The source folder path.</param>
        /// <param name="destinationFolderPath">The destination folder path.</param>
        void OrganizeFiles(string sourceFolderPath, string destinationFolderPath);
    }
}