using System;
using System.Collections.Generic;
using System.Linq;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Domain.Aggregates.Goals
{
    public class GoalStatus : Enumeration
    {
        public static GoalStatus ToDo => new (1, nameof(ToDo).ToLowerInvariant());
        public static GoalStatus Completed => new (2, nameof(Completed).ToLowerInvariant());

        public GoalStatus(int id, string name) : base(id, name)
        {

        }

        public static IEnumerable<GoalStatus> GetAllValues() => new[] { ToDo, Completed };

        public static GoalStatus FromName(string name)
        {
            var state = GetAllValues().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
                throw new Exception($"Possible values for GoalStatus: {string.Join(",", GetAllValues().Select(s => s.Name))}");

            return state;
        }

        public static GoalStatus From(int id)
        {
            var state = GetAllValues().SingleOrDefault(s => s.Id == id);

            if (state == null)
                throw new Exception($"Possible values for GoalStatus: {string.Join(",", GetAllValues().Select(s => s.Name))}");

            return state;
        }
    }
}
