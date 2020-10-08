using System;

namespace Islands.Domain.Models
{
    public class IslandCell
    {
        public int Height { get; private set; }

        public IslandCell(int height)
        {
            Height = height >= 0 ? height : throw new ArgumentException($"{nameof(height)} has to be greater than 0");
        }

    }
}
