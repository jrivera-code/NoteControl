using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace NoteControl.Source.MVVM.ViewModel.Commands
{
    public class Command : ICommand
    {
        public Action methodToExecute = null;
        public Func<bool> methodToDetectCanExecute = null;
        public DispatcherTimer canExecuteChangeEventTimer = null;
        public object parameters = null;

        //recibe como parametros el metodo que ejecutará el comando y un boolean si 
        //puede o ejecutarlo
        public Command(Action methodToExecute,Func<bool> methodToDetectCanExecute) {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;
            //activa un intervalo para ejecutar el evento CanExecuteChanged
            activeTemporizador(new TimeSpan(0,0,1));
        }
       

        //meto si es ejecutable o no
        public bool CanExecute(object parameter)
        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else {

                return this.methodToDetectCanExecute();
            }
        }
        //metodo ejecutar
        public void Execute(object parameter)
        {
            //guarda los controles que se envian por el CommandParameter desde la vista
            this.parameters = parameter;
            this.methodToExecute();
        }
       public event EventHandler CanExecuteChanged;
       public void CanExecuteChangedEvent(object sender , object e){
            if (this.CanExecuteChanged != null) {
                this.CanExecuteChanged(this,EventArgs.Empty);
            }
        }

      void activeTemporizador(TimeSpan timespan){
            this.canExecuteChangeEventTimer = new DispatcherTimer();
            this.canExecuteChangeEventTimer.Tick += CanExecuteChangedEvent;
            this.canExecuteChangeEventTimer.Interval = timespan;
            this.canExecuteChangeEventTimer.Start();
        }
    }
}
