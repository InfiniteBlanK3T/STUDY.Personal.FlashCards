using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards
{
    public class CardsManagement : ICommonFeatures
    {
        private int _cardId;
        private string _cardFront;
        private string _cardBack;

        public CardsManagement(string cardFront, string cardBack)
        {            
            _cardFront = cardFront;
            _cardBack = cardBack;
        }

        public void GetComponent()
        {

        }

        public void UpdateComponent()
        {

        }

        public void DeleteComponent()
        {

        }
    }
}
