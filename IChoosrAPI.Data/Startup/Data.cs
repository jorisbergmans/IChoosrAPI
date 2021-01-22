using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IChoosrAPI.Data.Startup
{
    internal class Data : DbContext, IData
    {
        public Data(DbContextOptions options) : base(options)
        {

        }

        //DBSets
    }
}
