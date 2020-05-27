using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTemplate.Logic
{
    class UILoginState : UIState, INotifyPropertyChanged
    {
        public override string NameRightButton => "Login";

        public override void Cancel(ViewModel viewModel)
        {
           
        }

        public override void EnterState(ViewModel viewModel)
        {
            viewModel.StateName = "LoginState";
            viewModel.MainPage.ShowEntryPage();
        }

        public override void Submit(ViewModel viewModel)
        {
            viewModel.TransitionToState(new UIAccueilState());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
