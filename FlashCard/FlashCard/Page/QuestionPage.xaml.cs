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
	public partial class QuestionPage : ContentPage
	{
		public QuestionPage (IEnumerable<Word> words)
		{
			InitializeComponent ();
		}

        private void OnPageTapped(object sender ,EventArgs e)
        {
        }

        private void OnIncorrectButtonClicked(object sender, EventArgs e)
        {
        }

        private void OnCorrectButtonClicked(object sender, EventArgs e)
        {
        }
    }
}