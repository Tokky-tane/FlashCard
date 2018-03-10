using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCard.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage(Dictionary<string, bool> pairs)
        {
            InitializeComponent();
            allLabel.Text = pairs.Count.ToString();
            correctLabel.Text = pairs.Count(z => z.Value == true).ToString();

            foreach (var item in pairs)
            {
                if (item.Value == false)
                {
                    incorrctStack.Children.Add(new Label { Text = item.Key, HorizontalOptions = LayoutOptions.Center });
                }
            }
        }

        private void OnBackTitleButtonClicked(object sender,EventArgs e)
        {
            App.Current.MainPage = new StartPage();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}