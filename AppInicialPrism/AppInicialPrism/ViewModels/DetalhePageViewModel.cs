using AppInicialPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppInicialPrism.ViewModels
{
	public class DetalhePageViewModel : BindableBase, INavigationAware
	{
        private Pessoa p;
        public Pessoa P
        {
            get { return p; }
            set { SetProperty(ref p, value); }
        }
        public DetalhePageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("itemNav"))
            {
                P = (Pessoa)parameters["itemNav"]; //se eu tiver nos parametros essa chave
                // P vai receber esse parametro (ItemNav) da outra ViewModel
            }
        }
    }
}
