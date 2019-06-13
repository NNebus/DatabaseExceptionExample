using Shared.Models;
using Shared.Models.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLAppConfig;
using Shared.Models.Repositories;
using System.Reflection;

namespace DatabaseExceptionExample
{
    public partial class App : Application
    {
        private IDependencyService _dependencyService;

        public App()
        {
            InitializeComponent();

            _dependencyService = new DependencyServiceWrapper();
            try {
                Assembly assembly = Assembly.GetExecutingAssembly();
                // Load Config File Ressource
                string configResourceName = Path.Combine(assembly.GetManifestResourceNames()[0]);
                Stream ConfigStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(configResourceName);
                ConfigurationManager.Initialise(ConfigStream);
                ConfigurationHelper configurationHelper = _dependencyService.Get<ConfigurationHelper>();

                // Get the DB Path
                configurationHelper.DatabasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), ConfigurationManager.AppSettings["localDatabaseName"]);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Creating an instance of a TicketRepo (for making DB access possible)
            // The TicketRepository instantiates a DatabaseContext which makes sure the DB is Created / Migrated / Deleted. 
            // !!!!! At this point the exception is happening !!!!!
            TicketRepository ticketRepository = new TicketRepository();
            DependencyService.Register<TicketRepository>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
