using System;
using System.Linq;
using System.Reflection;

namespace RESTy.Common.Extensions
{
    public static class EnumExtentions
    {
        #region Public Methods

        /// <summary>
        /// Will retrieve the DisplayName of an enum
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T enumValue) where T : IConvertible => enumValue.GetType()
                            .GetMember(enumValue.ToString())?
                            .First()?
                            .GetCustomAttribute<Description>()?
                            .GetDescription();

        /// <summary>
        /// Will get any input and check if mactches with any given Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T MatchFromDisplay<T>(this Array array, string input) where T : IConvertible
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
