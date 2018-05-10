using AppInicialPrism.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppInicialPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Global
        INavigationService _navigationService;
        #endregion

        public DelegateCommand ClickButton { get; set; }
        public DelegateCommand<Pessoa> ClickedItem { get; set; }
        public ObservableCollection<Pessoa> ListaPessoas { get; set; }
        public string NomePessoa { get; set; }
        public string CPFPessoa { get; set; }
        public string NomeLabel { get; set; }
        public string CPFLabel { get; set; }


        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            _navigationService = navigationService;
            ListaPessoas = new ObservableCollection<Pessoa>();
            
            
            //ListaPessoas.Add(new Pessoa { ID = 0, Nome = "", CPF = "" });

            Title = "Tela Incial";

            ClickButton = new DelegateCommand(ExecuteClickCommand);
            ClickedItem = new DelegateCommand<Pessoa>(ExecuteClickedItem);
        }

        private void ExecuteClickedItem(Pessoa obj)
        {

            var item = new NavigationParameters
            {
                {"itemNav",obj }
            };


            _navigationService.NavigateAsync("DetalhePage", item);
        }

        private void ExecuteClickCommand()
        {
            //Aviso de espaço em branco 
            if (string.IsNullOrEmpty(NomePessoa) ||
              string.IsNullOrEmpty(CPFPessoa))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Preencha todos os dados", "Ok");
                return;
            }
            //pegando ID do último elemento 
            var lastItem = new Pessoa();
            if (ListaPessoas.Count == 0)
            {
                lastItem.ID = -1;
            }
            else
            {
                lastItem = ListaPessoas.Last();
            }

            //criando novo elemento 
            Pessoa p = new Pessoa
            {
                ID = lastItem.ID + 1,
                Nome = NomePessoa,
                CPF = CPFPessoa

            };
            //Adicionando novo Elemento
            ListaPessoas.Add(p);
            
            //limpando tela
            NomePessoa = "";
            CPFPessoa = "";

        }
    }
}
