using CsvHelper;
using Logic.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logic.Implementations
{
    public class CSVHelper : ICSVHelper
    {
        private readonly ILogger<CSVHelper> logger;
        public CSVHelper(ILogger<CSVHelper> logger)
        {
            this.logger = logger;
        }

        public List<T> GetListFromCSV<T>()
        {
            List<T> records = new List<T>();
            try
            {
                using (var reader = new StreamReader(".\\cameras-defb.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.IgnoreBlankLines = true;
                    csv.Configuration.ShouldSkipRecord = x => x[0].StartsWith("ERROR");
                    records = csv.GetRecords<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            

            return records;
        }
    }
}
