﻿using Microwave.LanguageParser.Lexer;

namespace Microwave.LanguageParser.ParseAutomat.Members.Methods
{
    internal class MethodParamTypeDefSeparatorFoundState : ParseState
    {
        public MethodParamTypeDefSeparatorFoundState(MicrowaveLanguageParser microwaveLanguageParser) : base(microwaveLanguageParser)
        {
        }

        public override ParseState Parse(DslToken token)
        {
            switch (token.TokenType)
            {
                case TokenType.Value:
                    return MethodParamTypeFound(token);
                case TokenType.LoadToken:
                    return LoadTypeFound();
                default:
                    throw new NoTransitionException(token);
            }
        }

        private ParseState LoadTypeFound()
        {
            return new LoadParamFoundState(MicrowaveLanguageParser);
        }

        private ParseState MethodParamTypeFound(DslToken token)
        {
            MicrowaveLanguageParser.CurrentParam.Type = token.Value;
            MicrowaveLanguageParser.CurrentMethod.Parameters.Add(MicrowaveLanguageParser.CurrentParam);
            return new MethodSingleParamFinishedState(MicrowaveLanguageParser);
        }
    }
}