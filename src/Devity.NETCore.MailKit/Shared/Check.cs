using System;
using System.Collections.Generic;

namespace Devity.NETCore.MailKit.Shared
{
    internal class Check
    {
        internal class Argument
        {
            internal static void IsNotEmpty(string argument, string argumentName)
            {
                if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
                {
                    throw new ArgumentException(
                        $"\"{argumentName}\" cannot be emtpy .",
                        argumentName
                    );
                }
            }

            internal static void IsNotNull(
                object argument,
                string argumentName,
                string message = ""
            )
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName, message);
                }
            }

            internal static void IsNotEmpty<T>(ICollection<T> argument, string argumentName)
            {
                IsNotNull(argument, argumentName, "collection not be null");

                if (argument.Count == 0)
                {
                    throw new ArgumentException("collection not be empty.", argumentName);
                }
            }
        }
    }
}
