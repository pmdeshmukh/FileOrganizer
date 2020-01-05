namespace FileOrganizerHelper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// FileOrganizerHelper class.
    /// </summary>
    /// <seealso cref="FileOrganizerHelper.IFileOrganizerHelper" />
    public class FileOrganizerHelper : IFileOrganizerHelper
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static FileOrganizerHelper instance = null;

        /// <summary>
        /// The padlock
        /// </summary>
        private static readonly object lockObj = new object();

        // default constructor
        /// <summary>
        /// Prevents a default instance of the <see cref="FileOrganizerHelper"/> class from being created.
        /// </summary>
        FileOrganizerHelper()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static FileOrganizerHelper Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new FileOrganizerHelper();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Organizes the files.
        /// </summary>
        /// <param name="sourceFolderPath">The source folder path.</param>
        /// <param name="destinationFolderPath">The destination folder path.</param>
        public void OrganizeFiles(string sourceFolderPath, string destinationFolderPath)
        {
            try
            {
                var fileNames = this.ReadAllFileNamesFromPath(sourceFolderPath);
                var extensions = this.ReadExtensionsForFiles(fileNames);
                var destinationFolderNames = this.CreateFoldersForExtensions(extensions, destinationFolderPath);
                this.MoveFilesToDestination(fileNames, destinationFolderNames);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reads all file names from path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private IEnumerable<string> ReadAllFileNamesFromPath(string path)
        {
            try
            {
                var fileNames = Directory.EnumerateFiles(path);
                return fileNames;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reads the extensions for files.
        /// </summary>
        /// <param name="fileNames">The file names.</param>
        /// <returns></returns>
        private IEnumerable<string> ReadExtensionsForFiles(IEnumerable<string> fileNames)
        {
            try
            {
                var uniqueExtensions = new List<string>();
                foreach (var fileName in fileNames)
                {
                    var extension = Path.GetExtension(fileName)?.Split('.')?.Last();
                    if (!uniqueExtensions.Contains(extension))
                    {
                        uniqueExtensions.Add(extension);
                    }
                }

                return uniqueExtensions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates the folders for extensions.
        /// </summary>
        /// <param name="extensions">The extensions.</param>
        /// <param name="destinationPath">The path.</param>
        /// <returns>New folder paths.</returns>
        private IEnumerable<string> CreateFoldersForExtensions(IEnumerable<string> extensions, string destinationPath)
        {
            try
            {
                var extensionpaths = new List<string>();
                foreach (var extension in extensions)
                {
                    // Create folder if not exists
                    var folderPath = Path.Combine(destinationPath, extension.ToUpperInvariant());
                    if (!string.IsNullOrWhiteSpace(extension) && !Directory.Exists(Path.Combine(destinationPath, extension.ToUpperInvariant())))
                    {
                        var folderInfo = Directory.CreateDirectory(folderPath);
                        extensionpaths.Add(folderInfo.FullName);
                    }
                    else
                    {
                        extensionpaths.Add(folderPath);
                    }
                }

                return extensionpaths;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Moves the files to destination.
        /// </summary>
        /// <param name="sourcesFilePaths">The sources file paths.</param>
        /// <param name="destinationFolderPaths">The destination folder paths.</param>
        private void MoveFilesToDestination(IEnumerable<string> sourcesFilePaths, IEnumerable<string> destinationFolderPaths)
        {
            try
            {
                foreach (var sourceFilePath in sourcesFilePaths)
                {
                    var extension = Path.GetExtension(sourceFilePath);
                    if (!string.IsNullOrWhiteSpace(extension))
                    {
                        var destinationPath = destinationFolderPaths?.First(p => string.Equals(p?.Split('\\')?.Last(), extension?.Split('.')?.Last(), StringComparison.OrdinalIgnoreCase));
                        File.Move(sourceFilePath, Path.Combine(destinationPath, Path.GetFileName(sourceFilePath)));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
