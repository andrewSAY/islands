using System;
using System.Collections.Generic;
using Islands.Domain;
using Islands.Domain.Models;
using Islands.Parsing;
using Islands.Parsing.Implementation;
using Islands.WaterCalculation.Implementation;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;

namespace Islands.WaterCalculation.Tests.Attributes
{
    class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                fixture.Customizations.Add(new TypeRelay(typeof(IParser<int, Island>), typeof(IntToIslandsParser)));
                fixture.Customizations.Add(new TypeRelay(typeof(IParametrizedResultCommand<IEnumerable<Island>, int>), typeof(WaterAfterRainCalculateCommand)));
                return fixture;
            })
        {
        }
    }
}
