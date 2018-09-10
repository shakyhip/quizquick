using Newtonsoft.Json;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizQuick
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("user_login") && Application.Current.Properties["user_login"] != null && (Boolean)Application.Current.Properties["user_login"])
            {
                loginCorrecto();
            }
        }

        public static bool IsPageInNavigationStack<TPage>(INavigation navigation) where TPage : Page
        {
            if (navigation.NavigationStack.Count > 1)
            {
                var last = navigation.NavigationStack[navigation.NavigationStack.Count - 2];

                if (last is TPage)
                {
                    return true;
                }
            }
            return false;
        }

        public void loginCorrecto()
        {
            App.IsUserLoggedIn = true;
            Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString;


            Navigation.InsertPageBefore(new MainPage(), this);
            Navigation.PopAsync();
        }

        public async void OnLoginButtonClicked(object sender, EventArgs args)
        {

            var notificator = DependencyService.Get<IToastNotificator>();

            var options = new Notification()
            {
                Title = "Title",
                Description = "Description"
            };

            if (txtUsuario.Text == null || txtContrasena.Text == null)
            {
                await notificator.Notify(ToastNotificationType.Error, "Login Incorrecto...", "Por favor ingrese usuario y contraseña.", TimeSpan.FromSeconds(2));
                return;
            }

            JsonLogin jsonLogin = await App.TodoManager.GetTaskAsync(txtUsuario.Text, txtContrasena.Text);

            if (jsonLogin != null && jsonLogin.status == 200)
            {
                Usuario usuario = jsonLogin.data;
                Application.Current.Properties["user_id"] = usuario.usu_id;
                Application.Current.Properties["user_nombre"] = usuario.rol_id;
                Application.Current.Properties["user_token"] = usuario.token;
                Application.Current.Properties["user_login"] = true;

                Application.Current.Properties["user"] = JsonConvert.SerializeObject(jsonLogin);

                await Application.Current.SavePropertiesAsync();

                await notificator.Notify(ToastNotificationType.Success, jsonLogin.title == null ? "Login" : jsonLogin.title, jsonLogin.message, TimeSpan.FromSeconds(0.7));

                loginCorrecto();


            }
            else
            {
                if (jsonLogin != null && jsonLogin.status != 0)
                    await notificator.Notify(ToastNotificationType.Error, jsonLogin != null ? jsonLogin.title : "Error", jsonLogin != null ? jsonLogin.message : "Ocurrio un error.", TimeSpan.FromSeconds(2));
                else
                    await notificator.Notify(ToastNotificationType.Error, "Error de Red...", "Datos no validados.", TimeSpan.FromSeconds(1));
            }
        }
    }
}