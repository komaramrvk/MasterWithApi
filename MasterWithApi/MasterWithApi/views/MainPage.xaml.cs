using MasterWithApi.models;
using MasterWithApi.views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterWithApi
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        List<MasterList> items= new List<MasterList>();
        //program execution starts from here 
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            InitList();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Employeepage)));
            
        }


        private void InitList()
        {
            items.Add(new MasterList { typeofapi = "Employee API", TargetType = typeof(Employeepage) });
            items.Add(new MasterList { typeofapi = "Marvel API", TargetType = typeof(MarvelPage) });
            items.Add(new MasterList { typeofapi = "Website API", TargetType = typeof(WebsitePage) });
            lvmaster.ItemsSource = items;
            lvmaster.ItemTapped += Lvmaster_ItemTapped;
        }

        private  void Lvmaster_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MasterList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }

           
           
        

       

    }
}
