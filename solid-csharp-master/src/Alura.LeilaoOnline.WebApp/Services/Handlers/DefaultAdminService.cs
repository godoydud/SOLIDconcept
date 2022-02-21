using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDao _dao;

        public DefaultAdminService(ILeilaoDao dao)
        {
            _dao = dao;
        }

        public void CadastrarLeilao(Leilao leilao)
        {
            _dao.Incluir(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _dao.BuscarCategorias();
        }
        
        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _dao.BuscaPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _dao.BuscarLeiloes();
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = _dao.BuscaPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _dao.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = _dao.BuscaPorId(id);
            if (leilao !=null && leilao .Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _dao.Alterar(leilao);
            }
        }

        public void ModificarLeilao(Leilao leilao)
        {
            _dao.Alterar(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            _dao.Excluir(leilao);
        }
    }
}
