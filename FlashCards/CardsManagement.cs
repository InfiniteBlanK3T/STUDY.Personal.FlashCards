using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards
{
    public class CardsManagement : TableType
    {        
        private string _cardFront;
        private string _cardBack;

        public string CardFront
        {
            get
            {
                return _cardFront;
            }
            set
            {
                _cardFront= value;
            }
        }
        
        public string CardBack
        {
            get
            {
                return _cardBack;
            }
            set
            {
                _cardFront = value;
            }
        }

        public void Insert()
        {

        }

        public override void Update()
        {

        }

        public override void Delete()
        {

        }
    }
}
