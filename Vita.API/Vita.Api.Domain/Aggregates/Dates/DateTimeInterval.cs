using System;
using System.Collections.Generic;
using Vita.Core.Domain;

namespace Vita.Api.Domain.Aggregates.Dates
{
    public class DateTimeInterval : ValueObject
    {
        public DateTimeOffset Start { get; init; }
        public DateTimeOffset End { get; init; }

        public DateTimeInterval(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return End;
        }
    }
}
