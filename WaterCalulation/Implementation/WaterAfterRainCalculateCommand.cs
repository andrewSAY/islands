using System;
using System.Collections.Generic;
using System.Linq;
using Islands.Domain;
using Islands.Domain.Models;

namespace Islands.WaterCalculation.Implementation
{
    public class WaterAfterRainCalculateCommand : IParametrizedResultCommand<IEnumerable<Island>, int>
    {
        public int Execute(IEnumerable<Island> input)
        {
            var volume = 0;

            foreach(var island in input)
            {
                var emptyIslandCell = new IslandCell(height: 0);
                IslandCell currentCell = island.IslandCells.FirstOrDefault() ?? emptyIslandCell;
                while (currentCell != emptyIslandCell)
                {
                    var pool = GetPool(island, currentCell);
                    var poolVolume = GetPoolVolume(pool);
                    volume += poolVolume;
                    currentCell = pool.LastOrDefault() ?? emptyIslandCell;
                }
            }

            return volume;
        }

        private List<IslandCell> GetPool(Island island, IslandCell startCell)
        {
            var islandCells = GetCutIslandsCellsByStartCell(island.IslandCells, startCell);
            var previewCell = islandCells.FirstOrDefault() ?? new IslandCell(height: 0);
            var pool = new HashSet<IslandCell>();
            var leftPoolEdgeFound = false;
            var rightPoolEdgeFound = false;

            foreach (var currentCell in islandCells)
            {
                if (rightPoolEdgeFound)
                {
                    break;
                }

                if(leftPoolEdgeFound && previewCell.Height < currentCell.Height)
                {
                    rightPoolEdgeFound = true;
                    pool.Add(previewCell);
                    pool.Add(currentCell);
                }

                if(!leftPoolEdgeFound && previewCell.Height > currentCell.Height)
                {
                    leftPoolEdgeFound = true;
                    pool.Add(previewCell);
                    pool.Add(currentCell);
                }

                if (leftPoolEdgeFound)
                {
                    pool.Add(currentCell);
                }

                previewCell = currentCell;
            }

            return rightPoolEdgeFound && leftPoolEdgeFound ? pool.ToList() : new List<IslandCell>();
        }

        private List<IslandCell> GetCutIslandsCellsByStartCell(List<IslandCell> islandCells, IslandCell startCell)
        {
            var startCellIndex = islandCells.IndexOf(startCell);
            
            if(startCellIndex > -1)
            {
                islandCells = islandCells.ToList();
                islandCells.RemoveRange(index: 0, count: startCellIndex);
            }
            else
            {
                islandCells = new List<IslandCell>();
            }

            return islandCells;
        }

        private int GetPoolVolume(List<IslandCell> pool)
        {
            var poolVolume = 0;
            var emptyCell = new IslandCell(height: 0);
            var leftEdge = pool.FirstOrDefault() ?? emptyCell;
            var rightEdge = pool.LastOrDefault() ?? emptyCell;
            var minHeightEdge = Math.Min(leftEdge.Height, rightEdge.Height); 

            foreach (var currentCell in pool)
            {
                if(currentCell == leftEdge || currentCell == rightEdge)
                {
                    continue;
                }

                var currentVolume = minHeightEdge - currentCell.Height;
                poolVolume += currentVolume;
            }

            return poolVolume;
        }
    }
}
