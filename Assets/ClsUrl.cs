using System.Collections.Generic;
using System.Linq;

namespace CMAPI.CLSURL
{
    public class ClsURl
    {
        private static string _tenant;
        private static string _uatProd;
        private static string _domain;
        private static string _clsId;
        private static List<string> configDatKey = new List<string>();
        private static List<string> configDatValue = new List<string>();

        private static void ParseConfigDat(List<string> configDatLines)
        {
            foreach (var line in configDatLines)
            {
                // Parse left hand values from config.dat
                configDatKey.Add(line.Split('=').First().Trim());
                // right hand values
                configDatValue.Add(line.Split('=').Last().Trim());
            }
        }

        private static void AssignClsConfigDat()
        {
            if (string.IsNullOrEmpty(configDatValue[0]))
            {
                _tenant = "[tenant-missing]";
            }

            else
            {
                _tenant = configDatValue[0];
            }

            if (string.IsNullOrEmpty(configDatValue[1]))
            {
                _uatProd = "-uat";
            }

            else
            {
                _uatProd = configDatValue[1];
            }

            if (string.IsNullOrEmpty(configDatValue[2]))
            {
                _domain = "com";
            }

            else
            {
                _domain = configDatValue[2];
            }

            if (string.IsNullOrEmpty(configDatValue[3]))
            {
                _clsId = "[clsId-missing]";
            }

            else
            {
                _clsId = configDatValue[3];
            }
        }

        private static void FormatUatAndDomain()
        {
            if (_uatProd != "false")
            {
                _uatProd = "-uat";
            }

            else
            {
                _uatProd = string.Empty;
            }

            if(_domain == "eu")
            {
                _domain = "eu";
            }

            else
            {
                _domain = "com";
            }
        }

        public static string Url()
        {
            string url;

            ParseConfigDat(ConfigDat.ConfigDatReader.ConfigDatLines());
            AssignClsConfigDat();
            FormatUatAndDomain();

            //https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/{{CLSIDFLEX}}/access_request
            url = @"https://flex" + _tenant + _uatProd + ".compliance.flexnetoperations." + _domain + "/api/1.0/instances/" + _clsId;

            return url;
        }    
    }
}

