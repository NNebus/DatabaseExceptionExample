using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ConfigurationHelper))]
namespace Shared.Models
{
    public class ConfigurationHelper
    {
        public string DatabasePath { get; set; }
    }
}
