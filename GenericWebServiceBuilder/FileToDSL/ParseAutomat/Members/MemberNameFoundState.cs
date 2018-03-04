﻿using GenericWebServiceBuilder.DomainSpecificGrammar;
using GenericWebServiceBuilder.FileToDSL.Lexer;

namespace GenericWebServiceBuilder.FileToDSL.ParseAutomat.Properties
{
    public class MemberNameFoundState : ParseState
    {
        public MemberNameFoundState(Parser parser) : base(parser)
        {
        }

        public override ParseState Parse(DslToken token)
        {
            switch (token.TokenType)
            {
                case TokenType.TypeDefSeparator:
                    return PropertySeparatorFound();
                case TokenType.ParameterBracketOpen:
                    return MethodParamOpenFound();
                default:
                    throw new NoTransitionException(token);
            }
        }

        private ParseState MethodParamOpenFound()
        {
            Parser.CurrentMethod = new DomainMethod {Name = Parser.CurrentMemberName};
            return new MethodParamOpenState(Parser);
        }

        private ParseState PropertySeparatorFound()
        {
            Parser.CurrentProperty = new Property {Name = Parser.CurrentMemberName};
            return new PropertySeparatorFoundState(Parser);
        }
    }
}