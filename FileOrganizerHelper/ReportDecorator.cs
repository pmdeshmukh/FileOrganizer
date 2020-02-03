using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizerHelper
{
    public class ReportDecorator : BaseDecorator
    {
        private int totalCount = 0;
        private int failureCount = 0;
        private int successCount = 0;
        private readonly string path;
        public ReportDecorator() : base(null)
        {
            path = @"D:\ReportCount.txt";
        }
        public ReportDecorator(IFileOrganizerHelper fileOrganizerHelper) : base(fileOrganizerHelper)
        {
            path = @"D:\ReportCount.txt";
        }

        public override string GetAllReportCount()
        {
            using (StreamReader sr = new StreamReader(File.Open(this.path, FileMode.OpenOrCreate)))
            {
                return sr.ReadToEnd();
            }
        }

        public override string GetReportCount(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var temp = string.Empty;
                using (StreamReader sr = new StreamReader(File.Open(this.path, FileMode.OpenOrCreate)))
                {
                    temp = sr.ReadToEnd();
                }

                var allData = temp.Split(',');
                return allData.Where(a => string.Equals(a?.Split(':')?[0]?.Trim(), id, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault()?.Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        public override double SaveReportCount()
        {
            this.totalCount = this.successCount + this.failureCount;
            using (StreamWriter sw = new StreamWriter(File.Open(this.path, FileMode.Append)))
            {
                Random rnd = new Random();
                sw.WriteLine($"{rnd.Next() + ": Success Count " + this.successCount.ToString() + " Failure Count " + this.failureCount.ToString() + " Total Count " + this.totalCount.ToString()},");
            }

            return this.totalCount;
        }

        public override double UpdateFailureCount()
        {
            this.failureCount += 1;
            return this.failureCount;
        }

        public override double UpdateSuccessCount()
        {
            this.successCount += 1;
            return this.successCount;
        }
    }
}
