using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected_Mimari_FarkliBaglanmaYontemleri
{
    class Tools
    {
        public static string ConnectionString
        {
            get
            {
                return @"Server =.; Data Source = WISSEN\MSSQLSRV; Initial Catalog = Northwind; User ID = sa; Password = 12345srv";
            }
        }
    }
}
