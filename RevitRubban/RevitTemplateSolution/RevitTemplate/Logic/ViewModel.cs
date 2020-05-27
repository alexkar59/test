using RevitTemplate.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RevitTemplate.Logic
{
    public class ViewModel : INotifyPropertyChanged
    {
        public MainPage MainPage{ get; private set; }

        private UIState currentState;

        public UIState CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                currentState = value;
                RaisePropertyChanged("CurrentState");
            }
        }

        private string stateName;

        public string StateName
        {
            get
            {
                return stateName;
            }

            set
            {
                stateName = value;
                RaisePropertyChanged("StateName");
            }
        }

        private bool checkboxEntryPage;
        public bool CheckboxEntryPage
        {
            get
            {
                return checkboxEntryPage;
            }

            set
            {
                checkboxEntryPage = value;
                RaisePropertyChanged("CheckboxEntryPage");
            }
        }

        public ViewModel(MainPage mainPage)
        {
            MainPage = mainPage;
            TransitionToState(new UILoginState());
        }

        public void TransitionToState(UIState state)
        {
            CurrentState = state;
            CurrentState.EnterState(this);
            LoadCommands();
        }

        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private void LoadCommands()
        {
            SubmitCommand = new CustomCommand(Submit, CanSubmitCommand);
            CancelCommand = new CustomCommand(Cancel, CanCancelCommand);
        }

        private void Submit(object obj)
        {
            CurrentState.Submit(this);
        }
        private bool CanSubmitCommand(object obj)
        {
            return true;
        }

        private void Cancel(object obj)
        {
            CurrentState.Cancel(this);
        }

        private bool CanCancelCommand(object obj)
        {
            return true;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion   

    }
}
