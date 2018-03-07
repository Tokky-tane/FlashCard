using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCard.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FieldSelectPage : ContentPage
	{
        IEnumerable<Word> words;
		public FieldSelectPage ()
		{
			InitializeComponent ();
            words = GetList<WordCollection, Word>("FlashCard.Data.words.xml");

            var fields = words.Select(x => x.Field).Distinct();

            foreach (var field in fields)
            {
                var button = new Button { Text = field };
                button.Clicked += OnSelectButtonClicked;
                selectedButtonStack.Children.Add(button);
            }

		}

        private void OnAllButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NumberSelectPage(words));
        }

        private void OnSelectButtonClicked(object sender, EventArgs e)
        {
            var field = ((Button)sender).Text;
            var selected = words.Where(x => x.Field == field);
            Navigation.PushAsync(new NumberSelectPage(selected));
        }

        List<TChild> GetList<TChildren, TChild>(string resourseID)
            where TChildren : class, IChildren<TChild>
            where TChild : class
        {
            List<TChild> list = new List<TChild>();

            var assembly = GetType().GetTypeInfo().Assembly;
            using (var stream=assembly.GetManifestResourceStream(resourseID))
            {
                var serializer = new XmlSerializer(typeof(TChildren));
                var collection = serializer.Deserialize(stream) as TChildren;

                foreach (var item in collection.List)
                {
                    list.Add(item);
                }
            }
            return list;
        }
	}
}