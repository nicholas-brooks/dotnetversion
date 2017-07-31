using System;
using Microsoft.Win32;

namespace dotnetver
{
    class Program
    {
        static void Main(string[] args)
        {
            Get45PlusFromRegistry();
        }

	// Code from : https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed

        private static void Get45PlusFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    int key = (int)ndpKey.GetValue("Release");
                    Console.WriteLine(string.Format(".NET Framework Version: {0} ({1})", CheckFor45PlusVersion(key), key));
                }
                else
                {
                    Console.WriteLine(".NET Framework Version 4.5 or later is not detected.");
                }
            }
        }

        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 460798)
                return "4.7 or later";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
            {
                return "4.6.1";
            }
            if (releaseKey >= 393295)
            {
                return "4.6";
            }
            if ((releaseKey >= 379893))
            {
                return "4.5.2";
            }
            if ((releaseKey >= 378675))
            {
                return "4.5.1";
            }
            if ((releaseKey >= 378389))
            {
                return "4.5";
            }

            return "No 4.5 or later version detected";
        }
    }
}
