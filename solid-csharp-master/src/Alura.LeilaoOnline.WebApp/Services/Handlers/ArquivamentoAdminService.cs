using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {

        IAdminService _defaultService;

        public ArquivamentoAdminService(ILeilaoDao dao)
        {
            _defaultService = new DefaultAdminService(dao);
        }
        public void CadastrarLeilao(Leilao leilao)
        {
            _defaultService.CadastrarLeilao(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _defaultService.ConsultaCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _defaultService.ConsultaLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _defaultService.ConsultaLeiloes()
                .Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            _defaultService.FinalizaPregaoDoLeilaoComId(id);
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            _defaultService.IniciaPregaoDoLeilaoComId(id);
        }

        public void ModificarLeilao(Leilao leilao)
        {
            _defaultService.ModificarLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao !=null && leilao.Situacao !=
                SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.ModificarLeilao(leilao);
            }
        }
    }
}
