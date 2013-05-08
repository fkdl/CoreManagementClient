using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LP.Shared
{
    class GetBuildVersionAndDate
    {
        public static string GetVersion()
        {
            string s;
            try
            {
                // Get the version of the executing assembly (that is, this assembly).
                Assembly assem = Assembly.GetEntryAssembly();
                AssemblyName assemName = assem.GetName();
                Version ver = assemName.Version;

                //CALCULATE THE DATE OF THE BUILD
                DateTime dt = new DateTime(2000, 1, 1, 00, 00, 00);
                dt = dt.AddDays(ver.Build);
                //System.Windows.MessageBox.Show(dt.ToLongDateString());

                //ANOTHER (SHORTER) WAY OF COLLECTING THE DATA
                string versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //System.Windows.MessageBox.Show(versionString);

                versionString = ver.ToString() + " " + dt.ToShortDateString();
                s = versionString;

            }
            catch (Exception ex)
            {
                s = "Version Error";
            }
            return s;
        }
    }

    

}
