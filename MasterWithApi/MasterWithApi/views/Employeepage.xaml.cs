using MasterWithApi.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterWithApi.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employeepage : ContentPage
    {
        public Employeepage()
        {
            InitializeComponent();
            TapGestureRecognizer objlblreg = new TapGestureRecognizer();
            objlblreg.Tapped += Objlblreg_Tapped;
            lbl_register.GestureRecognizers.Add(objlblreg);
            btn_login.Clicked += Btn_login_Clicked;
            
        }

        private async void Btn_login_Clicked(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetStringAsync("http://dummy.restapiexample.com/api/v1/employee/" + et_eid.Text);
                    var data = JsonConvert.DeserializeObject<EmployeeGet>(response.ToString());
                    if (data.employee_name == et_pswd.Text)
                    {
                        await Navigation.PushAsync(new EmployeeDetails(data));
                    }
            }
            catch (Exception ex)
            {

            }
        }

        private void Objlblreg_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmployeeRegistration());
            
        }

    }
}