using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Domain
{
    class NickNameComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {

            if (x.Equals(y)) return true;
            return false;
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
