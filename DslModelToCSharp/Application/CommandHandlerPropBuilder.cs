﻿using System.Collections.Generic;
using DslModel.Domain;

namespace DslModelToCSharp.Application
{
    public class CommandHandlerPropBuilder
    {
        public IList<Property> Build(DomainClass domainClass)
        {
            return new List<Property>
            {
                new Property {Name = "EventStore", Type = "IEventStore"},
                new Property {Name = $"{domainClass.Name}Repository", Type = $"I{domainClass.Name}Repository"}
            };
        }
    }
}