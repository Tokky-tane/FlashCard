using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FlashCard
{
    [XmlRoot("Words")]
    public class WordCollection : IChildren<Word>
    {
        [XmlElement(Type = typeof(Word), ElementName = "Word")]
        public List<Word> List { get; set; }
    }
}
