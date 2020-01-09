namespace FileOrganizer
{
    using System;
    using System.Collections.Generic;
    using FileOrganizerHelper;
    using log4net;

    /// <summary>
    /// Program  class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                // Create instances of helper classes.
                var configurationHelper = ConfigurationHelper.Instance;
                var fileOrganizerHelper = FileOrganizerHelper.Instance;

                // Get source and destination file paths
                var sourcePath = configurationHelper.GetSourceFilePath();
                var destinationPath = configurationHelper.GetDestinationFilePath();

                // Organize the files
                fileOrganizerHelper.OrganizeFiles(sourcePath, destinationPath);
                Console.WriteLine($"Organized files successfully from \"{sourcePath}\" to \"{destinationPath}\"!! Please check \"{destinationPath}\" for output.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred. Please make sure you have set correct source and destination file names in config. Please check below error for more details!");
                Console.WriteLine();
                logger.Error("An exception occurred while organizing files! Please check stacktrace for more details.", ex);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit!");
                Console.ReadKey();
            }
        }
    }

    class MyClass
    {
        // TypesOfEnvironments = {Mac, Windows}
        // Retrieve TypesOfEnvironments based on input.
        // Pass TypesOfEnvironments to my factory class.

        //class Factory<T> where T : class
        //{
        //    public T CreateInstance<T>(string envType)
        //    {
        //        switch (envType)
        //        {
        //            case "windows":
        //                 return windowsInstance;
        //            case "mac":
        //                return macInstance;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }

    //class DerivedClass : MyClass
    //{
    //    public override int Add(int a, int b)
    //    {
    //        return Convert.ToInt32(a.ToString() + b.ToString());
    //    }
    //}
}
