using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace NoteControl.Source.MVVM.ViewModel.Commands
{
    public class CommandBinding : ICommand
    {
        //delegate command to register method to be executed
        private readonly Action handler;
        private bool isEnabled;
   

        /// <summary>
        /// Bind method to be executed to the handler
        /// So that it can direct on event execution
        /// </summary>
        /// <param name="handler"></param>
        public CommandBinding(Action handler)
        {
            // Assign the method name to the handler
            this.handler = handler;
        }
        
        //Property that helps to
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// method to specify if the event will execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        // Helps to execute the respective method using the handler
        public void Execute(object parameter)
        {
            //calls the respective method that has been registered with the handler
            handler();
           
        }
    }
}
