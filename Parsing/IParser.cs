using System;
using System.Collections.Generic;

namespace Islands.Parsing
{
    public interface IParser<in Tin, Tout>
    {
         IEnumerable<Tout> Parse(IEnumerable<Tin> input);
    }
}
