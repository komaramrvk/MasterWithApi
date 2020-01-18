using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MasterWithApi.models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterWithApi.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeRegistration : ContentPage
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
            button_register.Clicked += Button_register_Clicked;
        }



        private async void Button_register_Clicked(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.name = entry_name.Text;
            emp.salary = entry_salary.Text;
            emp.age = entry_age.Text;
            HttpClient _httpclient = new HttpClient();
            var content = JsonConvert.SerializeObject(emp);
            var data = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpclient.PostAsync("http://dummy.restapiexample.com/api/v1/create", data);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<Employee>(result.ToString());
                await DisplayAlert(item.id+" - "+item.name, " Register succesfully","ok");
            }
          
            
        }
    }
}