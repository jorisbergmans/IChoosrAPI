using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public interface ICSVHelper
    {
        List<T> GetListFromCSV<T>();
    }
}
