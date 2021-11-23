using _02.Repositorys;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace _02.Controllers
{
    [EnableCors("cors")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        MovimentacaoRepository movimentacaorepositorys = new MovimentacaoRepository();

        [HttpGet]
        [Route("/home")]
        //getall
        public string Index()
        {

            return movimentacaorepositorys.getall();
        }
        //get
        [HttpGet]
        [Route("/details")]
        //getall
        public string details(int id)
        {

            return movimentacaorepositorys.details(id);
        }
        //get
        [HttpGet]
        [Route("/movtype")]
        //getall
        public string tipomovimentacao(string mov)
        {

            return movimentacaorepositorys.tipomovimentacao(mov);
        }
        //save
        [HttpPost]
        [Route("/save")]
        public void save(string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            movimentacaorepositorys.save(clientecontainer, numerocontainer, tipocontainer, statuscontainer, categoriacontainer, tipomovimentacao, iniciomovimentacao, fimmovimentacao);
        }
        //update
        [HttpPut]
        [Route("/update")]
        public void update(int idcontainer, int idmov, string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            movimentacaorepositorys.update(idcontainer, idmov, clientecontainer, numerocontainer, tipocontainer, statuscontainer, categoriacontainer, tipomovimentacao, iniciomovimentacao, fimmovimentacao);
        }
        //deletar
        [HttpDelete]
        [Route("/deletar")]
        public void deletar(int id)
        {
            movimentacaorepositorys.deletar(id);
        }
    }
}

