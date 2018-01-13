using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class Constants
    {
        public const string BASE_URL = "http://www.viarail.ca/en";
        public enum Routes {ByeTicket}
        public static  Dictionary<Routes, String> ROUTES_MAPPING;

        static Constants()
        {
            ROUTES_MAPPING = new Dictionary<Routes, string>
            {
                {Routes.ByeTicket, "/travel-info/booking/buy-train-ticket"}
            };
        }

        public static string GenerateUrl(Routes route)
        {
            return BASE_URL + ROUTES_MAPPING[route];
        }
    }
}
