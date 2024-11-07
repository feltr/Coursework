using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.DataAccess.Entites
{
    public class PechEntity
    {
        public Guid Id { get; set; }
        public float tPech { get; set; }
        public float diametr { get; set; }
        public float tNach { get; set; }
        public float kTeplo { get; set; }
        public float p { get; set; }
        public float tPov { get; set; }
        public float kPer { get; set; }
    }
}
