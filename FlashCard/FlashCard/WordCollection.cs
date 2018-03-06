using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FlashCard2
{
    [XmlRoot("Words")]
    public class WordCollection
    {
        [XmlElement(Type = typeof(Word), ElementName = "Word")]
        public List<Word> Words { get; set; }
    }
}
