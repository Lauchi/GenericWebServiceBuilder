﻿using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microwave.LanguageParser.Lexer;
using Microwave.LanguageParser.ParseAutomat;

namespace Microwave.LanguageParser.Tests.ParseAutomat.Members
{
    [TestClass]
    public class AsyncHookTests
    {
        [TestMethod]
        public void SynchronousHook()
        {
            var tokens = new Collection<DslToken>
            {
                new DslToken(TokenType.AsyncDomainHook, "SynchronousDomainHook", 1),
                new DslToken(TokenType.Value, "SendWelcomeMail", 1),
                new DslToken(TokenType.DomainHookOn, "on", 1),
                new DslToken(TokenType.DomainHookEventDefinition, "User.Create", 1),
            };

            var parser = new MicrowaveLanguageParser();
            var domainTree = parser.Parse(tokens);

            Assert.AreEqual("User", domainTree.AsyncDomainHooks[0].ClassType);
            Assert.AreEqual("Create", domainTree.AsyncDomainHooks[0].MethodName);
            Assert.AreEqual("SendWelcomeMail", domainTree.AsyncDomainHooks[0].Name);
        }

        [TestMethod]
        public void SynchronousHook_NameNotFoundException()
        {
            var tokens = new Collection<DslToken>
            {
                new DslToken(TokenType.AsyncDomainHook, "SynchronousDomainHook", 1),
                new DslToken(TokenType.SynchronousDomainHook, "SynchronousDomainHook", 1),
            };

            var parser = new MicrowaveLanguageParser();
            try
            {
                parser.Parse(tokens);
            }
            catch (NoTransitionException e)
            {
                Assert.IsTrue(e.Message.Contains("Unexpected Token"));
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void SynchronousHook_OnKeywordNotFoundException()
        {
            var tokens = new Collection<DslToken>
            {
                new DslToken(TokenType.AsyncDomainHook, "SynchronousDomainHook", 1),
                new DslToken(TokenType.Value, "SendPasswordMail", 1),
                new DslToken(TokenType.Value, "SendPasswordMail", 1),
            };

            var parser = new MicrowaveLanguageParser();
            try
            {
                parser.Parse(tokens);
            }
            catch (NoTransitionException e)
            {
                Assert.IsTrue(e.Message.Contains("Unexpected Token"));
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void SynchronousHook_EventListenetNotFoundException()
        {
            var tokens = new Collection<DslToken>
            {
                new DslToken(TokenType.AsyncDomainHook, "SynchronousDomainHook", 1),
                new DslToken(TokenType.Value, "SendPasswordMail", 1),
                new DslToken(TokenType.DomainHookOn, "on", 1),
                new DslToken(TokenType.DomainHookOn, "on", 1),
            };

            var parser = new MicrowaveLanguageParser();
            try
            {
                parser.Parse(tokens);
            }
            catch (NoTransitionException e)
            {
                Assert.IsTrue(e.Message.Contains("Unexpected Token"));
                return;
            }

            Assert.Fail();
        }
    }
}