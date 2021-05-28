using System;
using NutriApp.Dominio;
using NutriApp.Percistencia;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Btn_Login_Click(object sender, EventArgs args)
        {

            if (vazios() == false)
            {
                //Removendo Mascara CPF
                string txtcpf = txt_cpf.Text.Replace(",", "");
                txtcpf = txtcpf.Trim().Replace("-", "");

                ClienteBO cliBO = new ClienteBO();
                ClienteDAO cliDAO = new ClienteDAO();
                cliBO = cliDAO.Select(txtcpf);

                if (cliBO.Nome != "")
                {
                    if (cliBO.Email == txt_email.Text.ToUpper())
                    {

                        ////Valor_Login = txtcpf;
                        //var x = new FrmPainelAdm(usuBO.Cpf);
                        //Visible = false;
                        //x.Show();
                    }
                    else
                    {
                        //Alert("CPF e SENHA não conferem, favor verificar!");
                    }
                }
            }
        }

        private bool vazios()
        {
            bool vazio = false;

            //Removendo Mascara CPF
            string txtcpf = txt_cpf.Text.Replace(".", "");
            txtcpf = txtcpf.Trim().Replace("-", "");

            if (txtcpf == "")
            {
                DisplayAlert("Atenção!","Favor preencher o campo CPF!","");
                vazio = false;
            }

            if (txt_email.Text.Trim() == "")
            {
                DisplayAlert("Atenção!","Favor preencher o campo Email!","");
                vazio = false;
            }

            return vazio;

        }
    }
}