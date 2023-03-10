using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace Problemm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Credentials = new string[]
            {
                "001231,1002",
                "001232,1004",
                "001233,1002",
                "001234,1004",
                "001235,1007"

            };

            Dictionary<string, int> Bitmasks = new Dictionary<string, int>()
            {
                {"1002",02 },
                {"1004",05 },
                {"1007",01 }
            };

            List<string> ConvertedCredentials = new List<string>();
            int successfulConversion = 0;

            foreach (string credential in Credentials)
            {
                string[] part=credential.Split(',');
                string CredentialValue = part[0];
                string tenantId=part[1];

                if (!Bitmasks.ContainsKey(tenantId))
                {
                    throw new BitMaskConversionException("No bitmask found for Tenant Id: " + tenantId);
                }

                int bitmask=Bitmasks[tenantId];
                int Conversion = int.Parse(CredentialValue) ^ bitmask;
                string ConversionCred= Conversion.ToString();

                ConvertedCredentials.Add($"{ConversionCred},{tenantId}");
                
                successfulConversion++;

            }
            foreach(string cred in ConvertedCredentials)
            {
                Console.WriteLine(cred);
            }

            int totalConversion=Credentials.Length;
            Console.WriteLine("Total number of Credentials Converted: "+totalConversion);
            Console.WriteLine("Numer of Successful Conversions: "+successfulConversion);

        }


        
    }

  
}