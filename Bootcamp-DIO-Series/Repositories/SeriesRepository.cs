using Bootcamp_DIO_Series.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp_DIO_Series.Repositories
{
    public interface ISeriesRepository
    {
        public List<Series> List();
        public Series ReturnById(int id);
        public void Insert(Series entity);
        public void Delete(int id);
        public void Update(int id, Series series);
        public int NextId();
    }

    public class SeriesRepository : ISeriesRepository
    {
        private List<Series> listSeries = new List<Series>();
        public void Delete(int id)
        {
            listSeries[id].Delete(); 
        }

        public void Insert(Series series)
        {
            listSeries.Add(series);
        }

        public List<Series> List()
        {
            return listSeries; 
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public Series ReturnById(int id)
        {
            return listSeries[id];
        }

        public void Update(int id, Series series)
        {
            listSeries[id] = series;
        }
    }
}
