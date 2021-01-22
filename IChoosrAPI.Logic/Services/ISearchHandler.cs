using IChoosrAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public interface ISearchHandler
    {
        void ShowCamerasByName(string name);
        List<CameraModel> GetNames(string name);
        List<CameraModel> GetNames();
    }
}
