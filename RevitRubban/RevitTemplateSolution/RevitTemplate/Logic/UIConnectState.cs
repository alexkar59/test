using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTemplate.Logic
{
    class UIConnectState : UIState
    {
        public override string NameRightButton => "Continuer";

        public override void Cancel(ViewModel viewModel)
        {
            
        }

        public override void EnterState(ViewModel viewModel)
        {
            viewModel.StateName = "ConnectState";
            viewModel.MainPage.ShowStatusPage("La maquette n'est pas connectée à un modèle, veuillez selectionner un modèle en cliquant sur le bouton Continuer ");
        }

        public override void Submit(ViewModel viewModel)
        {
            viewModel.TransitionToState(new UISynchronisationState());
        }
    }
}
