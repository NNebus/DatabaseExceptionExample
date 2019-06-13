using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shared.Models.Services
{
    /// <summary>
    /// Wrapper for xamarins DependencyService.
    /// This class will be used in a Xamarin-Application.
    /// Purpose for this wrapper is testing. While using tests the xamarin DependencyService cannot be used.
    /// With this implementation it's possible to use a different dependency service for tests caused by the "IDependencyService"-Inferface all dependency services should use.
    /// </summary>
    public class DependencyServiceWrapper : IDependencyService
    {
        /// <summary>
        /// Calls the Xamarins DependencyService-Method "Get" with given type.
        /// </summary>
        /// <typeparam name="T">Type of the object which should be returned.</typeparam>
        /// <returns>Returns an object of given type.</returns>
        public T Get<T>() where T : class
        {
            return DependencyService.Get<T>();
        }

        /// <summary>
        /// Not Implemented.
        /// To Register an object use Attributes (https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/introduction#registration)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="impl"></param>
        public void Register<T>(object impl)
        {
            throw new NotImplementedException("Do not use \"Register<T>(object impl)\". \nTo Register an object use Attributes (https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/introduction#registration).");
        }
    }
}
