using System;

namespace MurderByDeath.Utilities
{
    public static class ExtensionMethods
    {
        #region Array extensions

        public static bool IsNullOrEmpty( this Array array )
        {
            return array == null || array.Length == 0;
        }

        #endregion

        #region string extensions

        public static bool IsNullOrEmpty( this string str )
        {
            return str == null || str == "";
        }

        #endregion
    }
}
