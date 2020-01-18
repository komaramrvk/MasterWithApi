using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterWithApi.models;

namespace MasterWithApi.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebsitePage : ContentPage
    {
        
        public WebsitePage()
        {
            InitializeComponent();
            getSitesList();
        }

        private async void getSitesList()
        {

            try
            {
                HttpClient objHttpClient = new HttpClient();
                var response = await objHttpClient.GetStringAsync("http://demos.tricksofit.com/files/json.php");
                var siteslist = JsonConvert.DeserializeObject<List<Websites>>(response);

                lvsites.ItemsSource = siteslist;
            }
            catch (Exception ex)
            {


            }

        }
    }
}