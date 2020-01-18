using MasterWithApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterWithApi.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarvelDetails : ContentPage
    {
        public MarvelDetails( Marvel item)
        {
            InitializeComponent();
            
            InitLabels(item);
        }

        private void InitLabels(Marvel item)
        {
            lblname.Text = item.name;
            lblrealname.Text = item.realname;
            lblteam.Text = item.team;
            lblfap.Text = item.firstappearance;
            lblcreatedby.Text = item.createdby;
            lblpub.Text = item.publisher;
        }
    }
}