using ChoETL;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _02.Repositorys
{
    public class MovimentacaoRepository
    {
        SqlConnection orkconn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true");
        //getall
        public string getall()
        {
            orkconn.Open();
            SqlCommand scomm = new SqlCommand("SELECT * FROM MOVIMENTACOES INNER JOIN CONTAINERS ON CONTAINERS.IDCONTAINER = MOVIMENTACOES.FKIDCONTAINER", orkconn);
            StringBuilder sbuil = new StringBuilder();
            using (var chojsonwriter = new ChoJSONWriter(sbuil))
            {
                chojsonwriter.Write(scomm.ExecuteReader());
            }
            orkconn.Close();
            return sbuil.ToString();
        }
        //details
        public string details(int id)
        {
            orkconn.Open();
            SqlCommand scomm = new SqlCommand($"SELECT * FROM MOVIMENTACOES INNER JOIN CONTAINERS ON CONTAINERS.IDCONTAINER = MOVIMENTACOES.FKIDCONTAINER WHERE MOVIMENTACOES.IDMOVIMENTACAO {id} ", orkconn);
            StringBuilder sbuil = new StringBuilder();
            using (var chojsonwriter = new ChoJSONWriter(sbuil))
            {
                chojsonwriter.Write(scomm.ExecuteReader());
            }
            orkconn.Close();
            return sbuil.ToString();
        }

        //details
        public string tipomovimentacao(string mov)
        {
            orkconn.Open();
            SqlCommand scomm = new SqlCommand($"SELECT * FROM MOVIMENTACOES INNER JOIN CONTAINERS ON CONTAINERS.IDCONTAINER = MOVIMENTACOES.FKIDCONTAINER WHERE MOVIMENTACOES.tipomovimentacao {mov} ", orkconn);
            StringBuilder sbuil = new StringBuilder();
            using (var chojsonwriter = new ChoJSONWriter(sbuil))
            {
                chojsonwriter.Write(scomm.ExecuteReader());
            }
            orkconn.Close();
            return sbuil.ToString();
        }
        //save
        public void save(string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            orkconn.Open();
            SqlCommand scomm = new SqlCommand("INSERT INTO CONTAINERS VALUES ('" + clientecontainer + "','" + numerocontainer + "','" + tipocontainer + "','" + statuscontainer + "','" + categoriacontainer + "');" +
                                            "INSERT INTO MOVIMENTACOES VALUES ('" + tipomovimentacao + "','" + iniciomovimentacao + "','" + fimmovimentacao + "',@@IDENTITY)", orkconn);
            scomm.ExecuteNonQuery();
            orkconn.Close();
        }
        //update
        public void update(int idcontainer, int idmov, string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            orkconn.Open();
            SqlCommand scomm = new SqlCommand($"UPDATE CONTAINERS SET CLIENTECONTAINER =  {clientecontainer}, NUMEROCONTAINER = {numerocontainer}, TIPOCONTAINER = {tipocontainer}, STATUSCONTAINER = {statuscontainer}, CATEGORIACONTAINER = {categoriacontainer} WHERE CONTAINERS.IDCONTAINER = {idcontainer} ", orkconn);
            scomm.ExecuteNonQuery();
            orkconn.Close();
            orkconn.Open();
            SqlCommand scomms = new SqlCommand($"UPDATE MOVIMENTACOES SET TIPOMOVIMENTACAO = {tipomovimentacao}, INICIOMOVIMENTACAO = {iniciomovimentacao}, FIMMOVIMENTACAO = {fimmovimentacao} WHERE MOVIMENTACOES.IDMOVIMENTACAO = {idmov} ", orkconn);
            scomm.ExecuteNonQuery();
            orkconn.Close();
        }

        //delete

        public void deletar(int id)
        {
            orkconn.Open();
            SqlCommand scomm = new SqlCommand("DELETE FROM MOVIMENTACOES WHERE IDMOVIMENTACAO = " + id, orkconn);
            scomm.ExecuteNonQuery();
            orkconn.Close();
        }
    }
}
