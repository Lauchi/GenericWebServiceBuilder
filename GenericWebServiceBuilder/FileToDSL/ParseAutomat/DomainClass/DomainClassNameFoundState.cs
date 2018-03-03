﻿using GenericWebServiceBuilder.FileToDSL.Lexer;

namespace GenericWebServiceBuilder.FileToDSL.ParseAutomat
{
    public class DomainClassNameFoundState : ParseState
    {
        public DomainClassNameFoundState(Parser parser) : base(parser)
        {
        }

        private ParseState BracketOpeneFound()
        {
            return new DomainClassOpenedState(Parser);
        }

        public override ParseState Parse(DslToken token)
        {
            switch (token.TokenType)
            {
                case TokenType.ObjectBracketOpen:
                    return BracketOpeneFound();
                default:
                    throw new NoTransitionException(token);
            }
        }
    }
}