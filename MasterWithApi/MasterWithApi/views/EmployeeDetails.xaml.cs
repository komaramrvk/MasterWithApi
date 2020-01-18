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
    public partial class EmployeeDetails : ContentPage
    {
        string id;
        public EmployeeDetails(EmployeeGet item)
        {
            InitializeComponent();
            id = item.id;
            lbl_name.Text = item.employee_name;
            entry_name.Text = item.employee_name;
            entry_salary.Text = item.employee_salary;
            entry_age.Text = item.employee_age;
            btn_update.Clicked += Btn_update_Clicked;
            

        }

        private async void Btn_update_Clicked(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.name = entry_name.Text;
            emp.salary = entry_salary.Text;
            emp.age = entry_age.Text;
            HttpClient _httpclient = new HttpClient();
            var content = JsonConvert.SerializeObject(emp);
            var data = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpclient.PutAsync("http://dummy.restapiexample.com/api/v1/update/"+id, data);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                await DisplayAlert(result, "update succesfully", "ok");
            }
        }


    }
}