namespace Islands.WaterCalculation.Tests.Attributes
{
    public class InlineAutoMoqDataAttribute : AutoFixture.Xunit2.InlineAutoDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] objects) : base(new AutoMoqDataAttribute(), objects) { }
    }
}
