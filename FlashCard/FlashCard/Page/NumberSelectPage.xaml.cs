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
	public partial class NumberSelectPage : ContentPage
	{
		public NumberSelectPage (IEnumerable<Word> words)
		{
			InitializeComponent ();
		}
	}
}