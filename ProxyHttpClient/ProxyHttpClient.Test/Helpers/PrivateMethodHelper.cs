using System;
using System.Linq;
using System.Reflection;

namespace SimpleHttpClient.Test.Helpers
{
    public static class PrivateMethodHelper
    {
        /// <summary>
        /// Invokes static/nonstatic internal/private/protected methods and returns the expected result
        /// </summary>
        /// <typeparam name="T">Type of the class that contains the method.</typeparam>
        /// <typeparam name="TResult">Return type of the method.</typeparam>
        /// <param name="instance">Instance of the class that contains the method</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">Parameters expected by the method.</param>
        /// <returns></returns>
        public static TResult InvokePrivateMethodWithName<T,TResult>(T instance, string methodName, object[] parameters) where T : class
        {
            try
            {
                var type = typeof(T);
                var method = GetMethod<T>(methodName);
                if(method is null)
                {
                    throw new NullReferenceException("Method not found.");
                }

                return (TResult)method.Invoke(instance, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static MethodInfo GetMethod<T>(string methodName) where T : class
        {
            var methods = typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.NonPublic);
            methods = methods ?? throw new NullReferenceException($"No private methods found in class {typeof(T).Name}");
            methodName = methodName ?? throw new ArgumentNullException($"Methodname cannot be null");
            return methods.FirstOrDefault(n => n.Name == methodName);
        }
    }
}
