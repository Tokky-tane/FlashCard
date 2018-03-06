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
        List<Word> words;
		public FieldSelectPage ()
		{
			InitializeComponent ();
            words = GetList<WordCollection, Word>("FlashCard.Data.words.xml");

            var fields = words.Select(x => x.Name).Distinct();
            foreach (var field in fields)
            {
                var button = new Button { Text = field };
                button.Clicked += OnSelectButtonClicked;
            }

		}

        private void OnAllButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void OnSelectButtonClicked(object sender, EventArgs e)
        {

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