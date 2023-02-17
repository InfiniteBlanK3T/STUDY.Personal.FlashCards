using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards
{
    public abstract class TableType
    {
        private int _id;

        public int Id 
        {
            set
            {
                _id = value;
            }
            get 
            {
                return _id; 
            } 
        }
        public abstract void Update();
        public abstract void Delete();

    }
}
