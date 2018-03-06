using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCard
{
    interface IChildren<T>
    {
        List<T> List { get; set; }
    }
}
