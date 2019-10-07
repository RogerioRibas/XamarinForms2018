using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Servico;
using App01_ConsultaCEP.Servico.Modelo;

namespace App01_ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            //Validacao
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} - Bairro {3}, {0}, {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço nao foi encontrado para o CEP informado:" + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO", e.Message, "OK");
                }

            }
   
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Invalido! CEP deve conter 8 caracteres.", "OK");
                valido = false;

            }
            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP Invalido! CEP deve conter apenas numeros", "OK");
                valido = false;

            }


            return valido;
        }
    }
        
}
