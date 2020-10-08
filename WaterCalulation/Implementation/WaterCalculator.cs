using System;
using System.Collections.Generic;
using System.Text;
using Islands.Domain;
using Islands.Domain.Models;
using Islands.Parsing;

namespace Islands.WaterCalculation.Implementation
{
    public class WaterCalculator : IWaterCalculator
    {
        private readonly IParser<int, Island> _intToIslandCellParser;
        private readonly IParametrizedResultCommand<IEnumerable<Island>, int> _waterAfterRainCalculateCommand;

        public WaterCalculator(IParser<int, Island> parser,
                IParametrizedResultCommand<IEnumerable<Island>, int> command)
        {
            _intToIslandCellParser = parser ?? throw new ArgumentNullException(nameof(parser));
            _waterAfterRainCalculateCommand = command ?? throw new ArgumentNullException(nameof(command));

        }

        public int GetWaterVolumeAfterRain(int[] heights)
        {
            var islands = _intToIslandCellParser.Parse(heights);
            var volume = _waterAfterRainCalculateCommand.Execute(islands);
            return volume;
        }
    }
}
