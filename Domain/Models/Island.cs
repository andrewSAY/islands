using System;
using System.Linq;
using System.Collections.Generic;

namespace Islands.Domain.Models
{
    public class Island
    {
        private readonly List<IslandCell> _islandCells = new List<IslandCell>();
        public List<IslandCell> IslandCells => _islandCells.ToList();

        public Island() 
        { }

        public Island(List<IslandCell> islandCells)
        {
            _islandCells = islandCells ?? throw new ArgumentNullException(nameof(islandCells));
        }

        public void AddCell(IslandCell islandCell)
        {
            _islandCells.Add(islandCell);
        }
    }
}
