using System;
using System.Collections.Generic;
using System.Text;

namespace QuizQuick
{
    public class JsonLogin
    {
        public int status { get; set; }

        public string message { get; set; }

        public Usuario data { get; set; }

        public string title { get; set; }
    }
}
