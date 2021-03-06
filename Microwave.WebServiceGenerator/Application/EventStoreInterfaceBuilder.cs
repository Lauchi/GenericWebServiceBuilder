﻿using System.CodeDom;
using System.Collections.Generic;
using Microwave.LanguageModel;
using Microwave.WebServiceGenerator.Util;
using Microwave.WebServiceModel.Application;
using Microwave.WebServiceModel.Domain;

namespace Microwave.WebServiceGenerator.Application
{
    public class EventStoreInterfaceBuilder
    {
        private readonly string _nameSpace;
        private readonly NameSpaceBuilderUtil _nameSpaceBuilderUtil;
        private readonly InterfaceBuilderUtil _interfaceBuilderUtil;

        public EventStoreInterfaceBuilder(string nameSpace)
        {
            _nameSpace = nameSpace;
            _interfaceBuilderUtil = new InterfaceBuilderUtil();
            _nameSpaceBuilderUtil = new NameSpaceBuilderUtil();
        }

        public CodeNamespace Build(EventStoreInterface eventStore)
        {
            var codeNamespace = _nameSpaceBuilderUtil.WithName(_nameSpace).WithDomain().WithTask().WithList().Build();
            var codeTypeDeclaration = _interfaceBuilderUtil.Build(eventStore);
            codeNamespace.Types.Add(codeTypeDeclaration);
            return codeNamespace;
        }
    }

    public class EventStoreInterface : DomainClass
    {
        public EventStoreInterface()
        {
            Name = "IEventStore";
            Methods = new List<DomainMethod>
            {
                new DomainMethod
                {
                    Name = "AppendAll",
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "domainEvents",
                            Type = $"List<{new DomainEventBaseClass().Name}>"
                        }
                    },
                    ReturnType = $"Task<{new HookResultBaseClass().Name}>"
                }
            };
        }
    }
}