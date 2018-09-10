using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuick
{

    public class MasterPageMenuItem
    {
        public MasterPageMenuItem()
        {
            TargetType = typeof(Inicio);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}