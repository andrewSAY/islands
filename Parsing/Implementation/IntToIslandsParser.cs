using System;
using System.Collections.Generic;
using System.Linq;
using Islands.Domain.Models;

namespace Islands.Parsing.Implementation
{
    public class IntToIslandsParser : IParser<int, Island>
    {
        public IEnumerable<Island> Parse(IEnumerable<int> input)
        {
            var islands = new List<Island>();
            var island = new Island();

            foreach(var height in input)
            {
                var islandCell = new IslandCell(height);
                if (CellIsLowerSeaLevel(islandCell))
                {
                    if (!IslandIsUnderWater(island))
                    {
                        islands.Add(island);
                    }

                    island = new Island();
                    continue;
                }

                island.AddCell(islandCell);
            }

            islands.Add(island);

            return islands;
        }

        private bool CellIsLowerSeaLevel(IslandCell islandCell)
        {
            return islandCell.Height == 0;
        }

        private bool IslandIsUnderWater(Island island)
        {
            return island.IslandCells.All(cell => CellIsLowerSeaLevel(cell));
        }
    }
}
