using IChoosrAPI.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Logic.Services.Implementations
{
    public class SearchHandler : ISearchHandler
    {
        private readonly ILogger<SearchHandler> logger;
        private readonly ICSVHelper csvHelper;
        public SearchHandler(ILogger<SearchHandler> logger, ICSVHelper csvHelper)
        {
            this.logger = logger;
            this.csvHelper = csvHelper;
        }

        public void ShowCamerasByName(string name)
        {
            GetNames(name);
        }
        public List<CameraModel> GetNames(string name)
        {
            try
            {
                var cameras = csvHelper.GetListFromCSV<CameraModel>();
                var filteredCamerasByName = cameras.Where(c => c.Camera.Contains(name)).ToList();
                return filteredCamerasByName;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
        }

        public List<CameraModel> GetNames()
        {
            try
            {
                var cameras = csvHelper.GetListFromCSV<CameraModel>();
                return cameras;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
