using System;
using System.Data.SqlClient;

namespace ConexaoBD
{
    class Program
    {   
        static void Sucesso()
        {
            Console.WriteLine("\nOperação executada com êxito!\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
        static int Menu()
        {
            Console.Write("Digite:\n1 - Mostrar tabela\n2 - Editar dado\n3 - Deletar dado\n4 - Inserir dado\n5 - Sair\nSeleção: ");
            int selecao = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return selecao;
        }
        static void Main(string[] args)
        {
            SqlConnection conexao = new SqlConnection(@"data source=DESKTOP-OIR89FS\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=ExemploBD");
            conexao.Open();

            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        string strQuerySelect = "SELECT * FROM usuarios";
                        SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, conexao);
                        SqlDataReader dados = cmdComandoSelect.ExecuteReader();

                        while (dados.Read()) 
                            Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", dados["usuarioId"], dados["nome"], dados["cargo"], dados["date"]);

                        dados.Close();
                        Sucesso();
                        break;

                    case 2:
                        Console.Write("Digite o id do funcionário a ser alterado: ");
                        string id = Console.ReadLine();
                        Console.Write("Digite o novo nome: ");
                        string novoNome = Console.ReadLine();

                        string strQueryUpdate = string.Format("UPDATE usuarios SET nome = '{0}' WHERE usuarioId = '{1}'", novoNome, id);
                        SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, conexao);
                        cmdComandoUpdate.ExecuteNonQuery();

                        Sucesso();
                        break;

                    case 3:
                        Console.Write("Digite o id do funcionário a ser deletado: ");
                        id = Console.ReadLine();

                        string strQueryDelete = string.Format("DELETE FROM usuarios WHERE usuarioId = '{0}'", id);
                        SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, conexao);
                        cmdComandoDelete.ExecuteNonQuery();

                        Sucesso();
                        break;

                    case 4:
                        Console.Write("Digite o nome do funcionario a ser inserido: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite o cargo do funcionario a ser inserido: ");
                        string cargo = Console.ReadLine();
                        Console.Write("Digite a data de inserção: ");
                        string data = Console.ReadLine();

                        string strQueryInsert = string.Format("INSERT INTO usuarios(nome, cargo, date) VALUES('{0}', '{1}', '{2}')", nome, cargo, data);
                        SqlCommand cmdComandoInsert = new SqlCommand(strQueryInsert, conexao);
                        cmdComandoInsert.ExecuteNonQuery();

                        Sucesso();
                        break;

                    case 5:
                        return;
                }
            }           
        }
    }
}
