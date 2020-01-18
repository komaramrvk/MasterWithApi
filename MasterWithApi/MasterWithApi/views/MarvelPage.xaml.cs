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
    public partial class MarvelPage : ContentPage
    {
       
        public  MarvelPage()
        {
            InitializeComponent();
            getMarvelsList();
        }

        private async void getMarvelsList()
        {
            HttpClient objHttpClient = new HttpClient();
            var data = await objHttpClient.GetStringAsync("https://simplifiedcoding.net/demos/marvel/");
            var moviesdata = JsonConvert.DeserializeObject<List<Marvel>>(data.ToString());
            lvmarvellist.ItemsSource = moviesdata;
            lvmarvellist.ItemTapped += Lvmarvellist_ItemTapped;
            
        }

        private void Lvmarvellist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Marvel;
            Navigation.PushAsync(new MarvelDetails(item));
        }
    }
}