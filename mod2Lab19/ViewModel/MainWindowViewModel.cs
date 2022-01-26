using mod2Lab19.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mod2Lab19.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private string circleLength;
        public string CircleLength
        {
            get { return circleLength; }
            set
            {
                circleLength = value;
                OnPropertyChanged();
            }
        }

        public ICommand CircleLengthCommand { get; }
        private void OnCircleLengthCommandExecute(object p)
        {
            CircleLength = String.Format("{0:f2}",CircleOperations.Length(Radius));
        }

        private bool CanCircleLengthCommandExecuted(object p)
        {
            if (Radius!=0)
            {
                return true;
            }
            return false;
        }

        public MainWindowViewModel()
        {
            CircleLengthCommand = new RelyCommand(OnCircleLengthCommandExecute, CanCircleLengthCommandExecuted);
        }
    }
}
