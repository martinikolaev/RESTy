using System;

namespace RESTy.Transaction.Extensions
{
    internal static class EnumExtentions
    {
        #region Public Methods

        /// <summary>
        /// Will get any input and check if mactches with any given Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T MatchFromDescription<T>(this Array array, string input) where T : IConvertible
        {
            Type type = typeof(T);
            if (!type.IsEnum)
                return default(T);

            foreach (T value in array)
            {
                if (value.GetDescription() == input)
                    return value;
            }

            return default(T);
        }
        #endregion
    }
}
