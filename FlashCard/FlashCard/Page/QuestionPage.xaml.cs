﻿using System;
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
        bool isQuestionMode = true;
        Dictionary<string, bool> pairs = new Dictionary<string, bool>();
        List<Word> words;

        public QuestionPage(IEnumerable<Word> _words)
        {
            InitializeComponent();
            
            words = _words.ToList();
            SetWord(words.First());
        }

        private void OnPageTapped(object sender, EventArgs e)
        {
            if (isQuestionMode)
            {
                swich.IsToggled = false;
                meamLabel.Opacity = 1;
                swichStack.Opacity = 1;
                isQuestionMode = false;
            }
            else
            {
                pairs.Add(words.First().Name, swich.IsToggled);
                isQuestionMode = true;
                if (words.Count != 1)
                {
                    words.RemoveAt(0);
                    SetWord(words.First());
                    meamLabel.Opacity = 0;
                    swichStack.Opacity = 0;
                    isQuestionMode = true;
                }
                else
                {
                    Navigation.PushModalAsync(new ResultPage(pairs));
                }
            }
        }


        void SetWord(Word word)
        {
            nameLabel.Text = word.Name;
            meamLabel.Text = word.Mean;
        }
    }
}