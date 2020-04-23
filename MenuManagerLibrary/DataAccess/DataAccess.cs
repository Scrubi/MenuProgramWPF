using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace MenuManagerLibrary.DataAccess
{
    public static class DataAccess
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
