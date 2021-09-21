using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    
    public class RepositorySeries : IRepository<Serie>
    {
        private List<Serie> seriesList_ = new List<Serie>();
        public void Exclude(int id)
        {
            seriesList_[id].Exclude();
        }

        public void Insert(Serie entity)
        {
            seriesList_.Add(entity);
        }

        public List<Serie> List()
        {
            return seriesList_;
        }

        public int NextId()
        {
            return seriesList_.Count;
        }

        public Serie ReturnById(int id)
        {
            return seriesList_[id];
        }

        public void Update(int id, Serie entity)
        {
            seriesList_[id] = entity;
        }
    }
}