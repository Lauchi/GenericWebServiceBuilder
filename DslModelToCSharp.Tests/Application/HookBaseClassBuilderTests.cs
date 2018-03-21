﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using DslModel.Application;
using DslModelToCSharp.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DslModelToCSharp.Tests.Application
{
    [TestClass]
    public class HookBaseClassBuilderTests : TestBase
    {
        [TestMethod]
        public void Write()
        {
            var hookResultBuilder = new HookBaseClassBuilder(ApplicationNameSpace);

            var codeNamespace = hookResultBuilder.Build(new DomainHookBaseClass());

            new FileWriter(ApplicationBasePath).WriteToFile(codeNamespace.Types[0].Name, "Base", codeNamespace);

            new PrivateSetPropertyHackCleaner().ReplaceHackPropertyNames(ApplicationBasePath);

            Assert.AreEqual(Regex.Replace(File.ReadAllText("../../../ApplicationExpected/Generated/Base/IDomainHook.g.cs"), @"\s+", String.Empty),
                Regex.Replace(File.ReadAllText("Application/Base/IDomainHook.g.cs"), @"\s+", String.Empty));
        }
    }
}