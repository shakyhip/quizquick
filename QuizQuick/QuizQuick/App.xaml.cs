using System;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;


namespace QuizQuick
{
	public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }
        public static TodoItemManager TodoManager { get; private set; }

        public App ()
		{
			InitializeComponent();


            TodoManager = new TodoItemManager(new RestService());

            bool isLoggedIn = Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(Current.Properties["IsLoggedIn"]) : false;

            if (!isLoggedIn)
            {
                //Load if Not Logged In
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                //Load if Logged In
                MainPage = new NavigationPage(new MainPage());
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
