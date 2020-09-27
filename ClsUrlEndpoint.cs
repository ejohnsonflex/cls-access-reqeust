using System;
using System.Collections.Generic;
using UnityEngine;

namespace CMAPIConfiguration
{
    public class ClsUrlEndpoint
    {
        private static string tenant;
        private static string uatProd;
        private static string comEu;
        private static string clsId;
        private static List<string>  url = new List<string>();

        public void Eric()
        {
            url = CMAPIConfiguration.ConfigDatReader.GetConfigData();

            tenant = url[0];
            tenant.Split('=');
            Debug.Log(tenant);

            // split and read only right hand side of '=' sign in config.dat
            //foreach (var line in configLines)
            //{
            //    list.Add(line.Split('=').Last().Trim());
            //}

            //parsedConfigLines = list.ToArray();
        }
    }
}
