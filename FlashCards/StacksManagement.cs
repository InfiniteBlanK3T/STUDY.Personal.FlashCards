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
        UserInputs input = new();
        CrudControllers action = new();

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

        public override void Update()
        {
            var userIdInput = input.GetIntInputs("Id of stack you want to update: ");
            if (userIdInput == 0) return;

            action.Update("stacks", userIdInput);
            return;

        }

        public override void Delete()
        {

        }

    }
}
