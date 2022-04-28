using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace PdsEscola
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

             private void bt_salvarcadastro_Click(object sender, RoutedEventArgs e)
             {
                string nomeFantasia = txtnomeFan.Text;
                string razao = txtrazao.Text;
                string tipo = "Privada";

                var dataCriacao = txt_boxdataCria.SelectedDate?.ToString("yyy-mm-dd");

                if ((bool)rbPublica.IsChecked)
                    tipo = "Pública";

                var conexao = new MySqlConnection("server=localhost;database=Escola_Bd;port=3306;user=root;password=R10022005");

                try
                {
                    conexao.Open();
                    var comando = conexao.CreateCommand();

                    comando.CommandText = "Insert into Escola_Bd(nome_fantasia_esc ,cnpj_esc ,razao_social_esc, " +
                    "inscricao_esc, tipo_esc, data_cria_esc, nome_responsavel_esc, rua_esc, numero_esc, bairro_esc, " +
                    "cidade_esc, estado_esc, telefone_esc, email_esc, complemento_esc, cep_esc)" +
                    "values" +
                    "@nome, @cnpj, @razao, @inscricao, @tipo, @data_criacao, @resp, @rua, @numero, @bairro, " +
                    "@cidade, @estado, @telefone, @email, @complemento, @cep);";

                    comando.Parameters.AddWithValue("@nome", nomeFantasia);
                    comando.Parameters.AddWithValue("@cnpj", txtcnpj.Text);
                    comando.Parameters.AddWithValue("@razao", razao);
                    comando.Parameters.AddWithValue("@inscricao", txtinsEst.Text);
                    comando.Parameters.AddWithValue("@tipo", tipo);
                    comando.Parameters.AddWithValue("@data_criacao", dataCriacao);
                    comando.Parameters.AddWithValue("@resp", txtnome.Text);
                    comando.Parameters.AddWithValue("@rua", txtRua.Text);
                    comando.Parameters.AddWithValue("@numero", txtNum.Text);
                    comando.Parameters.AddWithValue("@bairro", txtBairro.Text);
                    comando.Parameters.AddWithValue("@cidade", txtCid.Text);
                    comando.Parameters.AddWithValue("@estado", Estados.Text);
                    comando.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    comando.Parameters.AddWithValue("@email", txtEmail.Text);
                    comando.Parameters.AddWithValue("@complemento", txtComple.Text);
                    comando.Parameters.AddWithValue("@cep", txtCep.Text);
                    var resultado = comando.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Registro Salvo com Sucesso");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conexao.Open();
             }
    }
}
    

