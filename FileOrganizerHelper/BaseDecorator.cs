using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizerHelper
{
    public abstract class BaseDecorator : IFileOrganizerHelper
    {
        private IFileOrganizerHelper fileOrganizerHelper;
        public BaseDecorator(IFileOrganizerHelper fileOrganizerHelper)
        {
            this.fileOrganizerHelper = fileOrganizerHelper;
        }

        public void OrganizeFiles(string sourceFolderPath, string destinationFolderPath)
        {
            throw new Exception();
            this.fileOrganizerHelper.OrganizeFiles(sourceFolderPath, destinationFolderPath);
        }

        public abstract double UpdateSuccessCount();
        public abstract double UpdateFailureCount();
        public abstract double SaveReportCount();
        public abstract string GetReportCount(string id);
        public abstract string GetAllReportCount();
    }
}
