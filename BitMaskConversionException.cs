using System.Runtime.Serialization;

namespace Problemm
{
    [Serializable]
    internal class BitMaskConversionException : Exception
    {
        public BitMaskConversionException(string message):base(message)
        {
        }

        
    }
}