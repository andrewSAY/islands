using System;
using Islands.WaterCalculation.Tests.Attributes;
using Islands.WaterCalculation.Implementation;
using Xunit;

namespace Islands.WaterCalculation.Tests
{
    

    public class WaterCalculatorTests
    {
        [Theory]
        [InlineAutoMoqData(new int[] { 3, 4, 3, 2, 5, 2, 4 }, 5)]
        [InlineAutoMoqData(new int[] { 3, 4, 3, 2, 5, 2, 4, 0, 0, 0, 5, 2, 5 }, 8)]
        [InlineAutoMoqData(new int[] { 1, 3, 1 }, 0)]
        [InlineAutoMoqData(new int[] { 3, 2, 1, 0 }, 0)]
        [InlineAutoMoqData(new int[] { 1, 2, 3, 0 }, 0)]
        [InlineAutoMoqData(new int[] { 1, 2, 3, 0, 2, 1, 2}, 1)]
        [InlineAutoMoqData(new int[] { }, 0)]
        public void GetWaterVolumeAfterRain_Default_ReturnsExpectedVolume
            (int[] heights,
            int expectedWaterVolume,
            WaterCalculator waterCalculator)
        {
            var calculatedWaterVolume = waterCalculator.GetWaterVolumeAfterRain(heights);

            Assert.Equal(expectedWaterVolume, calculatedWaterVolume);
        }
    }
}
