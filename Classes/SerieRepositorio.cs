using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;
using Dio.Series;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> ListaSeries = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            ListaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaSeries[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            ListaSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return ListaSeries;;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}