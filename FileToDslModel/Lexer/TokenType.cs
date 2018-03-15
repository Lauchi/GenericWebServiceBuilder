﻿namespace FileToDslModel.Lexer
{
    public enum TokenType
    {
        ObjectBracketOpen,
        ObjectBracketClose,
        DomainClass,
        ListBracketOpen,
        ListBracketClose,
        Value,
        ParameterBracketOpen,
        ParameterBracketClose,
        TypeDefSeparator,
        ParamSeparator,
        CreateMethod,
        SynchronousDomainHook,
        DomainHookEventDefinition,
        DomainHookOn
    }
}