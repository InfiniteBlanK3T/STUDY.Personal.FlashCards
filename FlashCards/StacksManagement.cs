using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards
{
    public class StacksManagement : TableType
    {        
        private string _stackName;

        public string StackName
        {
            get
            {
                return _stackName;
            }
            set
            {
                _stackName = value;
            }
        }

        public override void Insert()
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
