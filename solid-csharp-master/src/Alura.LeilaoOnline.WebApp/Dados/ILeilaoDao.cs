using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        public Leilao BuscaPorId(int id);

        IEnumerable<Leilao> BuscarLeiloes();

        IEnumerable<Categoria> BuscarCategorias();

        void Incluir(Leilao obj);

        void Alterar(Leilao obj);

        void Excluir(Leilao leilao);
    }
}
