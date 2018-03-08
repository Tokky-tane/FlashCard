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
        List<Word> words;
		public NumberSelectPage (IEnumerable<Word> _words)
		{
			InitializeComponent ();
            AddButton(_words, blocknum: 5);

            words = _words.OrderBy(x => Guid.NewGuid()).ToList();
		}

        void AddButton(IEnumerable<Word> words, int blocknum)
        {
            for (int i = 1; i <= words.Count(); i++)
            {
                if (i % blocknum == 0)
                {
                    var button = new Button { Text = $"{i}問", StyleId = i.ToString() };
                    button.Clicked += OnSelectedButtonClicked;
                    selectedButtonStack.Children.Add(button);
                }
            }
        }

        private void OnSelectedButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var selectedNum = int.Parse(button.StyleId);
            var selectedWords = words.Take(selectedNum);
            Navigation.PushModalAsync(new QuestionPage(selectedWords));
        }

        private void OnAllButtonClicked(object sender,EventArgs e)
        {
            Navigation.PushModalAsync(new QuestionPage(words));
        }
    }
}