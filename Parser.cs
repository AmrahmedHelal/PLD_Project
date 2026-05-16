
using com.calitha.commons;
using com.calitha.goldparser.lalr;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                    =  0, // (EOF)
        SYMBOL_ERROR                  =  1, // (Error)
        SYMBOL_WHITESPACE             =  2, // Whitespace
        SYMBOL_MINUS                  =  3, // '-'
        SYMBOL_MINUSMINUS             =  4, // '--'
        SYMBOL_EXCLAMEQ               =  5, // '!='
        SYMBOL_PERCENT                =  6, // '%'
        SYMBOL_LPAREN                 =  7, // '('
        SYMBOL_RPAREN                 =  8, // ')'
        SYMBOL_TIMES                  =  9, // '*'
        SYMBOL_COMMA                  = 10, // ','
        SYMBOL_DOT                    = 11, // '.'
        SYMBOL_DIV                    = 12, // '/'
        SYMBOL_COLON                  = 13, // ':'
        SYMBOL_SEMI                   = 14, // ';'
        SYMBOL_PLUS                   = 15, // '+'
        SYMBOL_PLUSPLUS               = 16, // '++'
        SYMBOL_LT                     = 17, // '<'
        SYMBOL_EQ                     = 18, // '='
        SYMBOL_EQEQ                   = 19, // '=='
        SYMBOL_GT                     = 20, // '>'
        SYMBOL_BEGIN                  = 21, // Begin
        SYMBOL_CLASS                  = 22, // class
        SYMBOL_DOUBLE                 = 23, // double
        SYMBOL_ELSE                   = 24, // else
        SYMBOL_FINISH                 = 25, // Finish
        SYMBOL_FLOAT                  = 26, // float
        SYMBOL_FOR                    = 27, // for
        SYMBOL_IDENTIFIER             = 28, // Identifier
        SYMBOL_IF                     = 29, // if
        SYMBOL_INT                    = 30, // int
        SYMBOL_INTEGER                = 31, // Integer
        SYMBOL_NEW                    = 32, // new
        SYMBOL_PRIVATE                = 33, // private
        SYMBOL_PROTECTED              = 34, // protected
        SYMBOL_PUBLIC                 = 35, // public
        SYMBOL_RETURN                 = 36, // return
        SYMBOL_STATIC                 = 37, // static
        SYMBOL_STRING                 = 38, // string
        SYMBOL_THIS                   = 39, // this
        SYMBOL_VOID                   = 40, // void
        SYMBOL_ACCESSMODIFIER         = 41, // <AccessModifier>
        SYMBOL_ARGUMENTLIST           = 42, // <ArgumentList>
        SYMBOL_ASSIGNMENT             = 43, // <Assignment>
        SYMBOL_CLASSDECLARATION       = 44, // <ClassDeclaration>
        SYMBOL_CLASSDECLARATIONS      = 45, // <ClassDeclarations>
        SYMBOL_CLASSMEMBER            = 46, // <ClassMember>
        SYMBOL_CLASSMEMBERS           = 47, // <ClassMembers>
        SYMBOL_CONDITION              = 48, // <Condition>
        SYMBOL_CONSTRUCTORDECLARATION = 49, // <ConstructorDeclaration>
        SYMBOL_EXPRESSION             = 50, // <Expression>
        SYMBOL_FACTOR                 = 51, // <Factor>
        SYMBOL_FIELDDECLARATION       = 52, // <FieldDeclaration>
        SYMBOL_IFBLOCK                = 53, // <IfBlock>
        SYMBOL_INCDEC                 = 54, // <IncDec>
        SYMBOL_ITERATION              = 55, // <Iteration>
        SYMBOL_LOOPFOR                = 56, // <LoopFor>
        SYMBOL_METHODCALL             = 57, // <MethodCall>
        SYMBOL_METHODDECLARATION      = 58, // <MethodDeclaration>
        SYMBOL_PARAMETER              = 59, // <Parameter>
        SYMBOL_PARAMETERLIST          = 60, // <ParameterList>
        SYMBOL_PROGRAM                = 61, // <Program>
        SYMBOL_REFERENCE              = 62, // <Reference>
        SYMBOL_RELOP                  = 63, // <RelOp>
        SYMBOL_RETURNSTATEMENT        = 64, // <ReturnStatement>
        SYMBOL_RETURNTYPE             = 65, // <ReturnType>
        SYMBOL_STATEMENT              = 66, // <Statement>
        SYMBOL_STATEMENTS             = 67, // <Statements>
        SYMBOL_TERM                   = 68, // <Term>
        SYMBOL_TYPE                   = 69, // <Type>
        SYMBOL_VARIABLEDECLARATION    = 70  // <VariableDeclaration>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_BEGIN_FINISH                                                =  0, // <Program> ::= <ClassDeclarations> Begin <Statements> Finish
        RULE_PROGRAM_BEGIN_FINISH2                                               =  1, // <Program> ::= Begin <Statements> Finish
        RULE_STATEMENTS                                                          =  2, // <Statements> ::= <Statements> <Statement>
        RULE_STATEMENTS2                                                         =  3, // <Statements> ::= <Statement>
        RULE_STATEMENT                                                           =  4, // <Statement> ::= <VariableDeclaration>
        RULE_STATEMENT2                                                          =  5, // <Statement> ::= <Assignment>
        RULE_STATEMENT3                                                          =  6, // <Statement> ::= <IfBlock>
        RULE_STATEMENT4                                                          =  7, // <Statement> ::= <LoopFor>
        RULE_STATEMENT_SEMI                                                      =  8, // <Statement> ::= <MethodCall> ';'
        RULE_STATEMENT5                                                          =  9, // <Statement> ::= <ReturnStatement>
        RULE_STATEMENT_SEMI2                                                     = 10, // <Statement> ::= <IncDec> ';'
        RULE_VARIABLEDECLARATION_IDENTIFIER_EQ_SEMI                              = 11, // <VariableDeclaration> ::= <Type> Identifier '=' <Expression> ';'
        RULE_VARIABLEDECLARATION_IDENTIFIER_SEMI                                 = 12, // <VariableDeclaration> ::= <Type> Identifier ';'
        RULE_ASSIGNMENT_EQ_SEMI                                                  = 13, // <Assignment> ::= <Reference> '=' <Expression> ';'
        RULE_RETURNSTATEMENT_RETURN_SEMI                                         = 14, // <ReturnStatement> ::= return <Expression> ';'
        RULE_RETURNSTATEMENT_RETURN_SEMI2                                        = 15, // <ReturnStatement> ::= return ';'
        RULE_CLASSDECLARATIONS                                                   = 16, // <ClassDeclarations> ::= <ClassDeclarations> <ClassDeclaration>
        RULE_CLASSDECLARATIONS2                                                  = 17, // <ClassDeclarations> ::= <ClassDeclaration>
        RULE_CLASSDECLARATION_CLASS_IDENTIFIER_BEGIN_FINISH                      = 18, // <ClassDeclaration> ::= <AccessModifier> class Identifier Begin <ClassMembers> Finish
        RULE_CLASSDECLARATION_CLASS_IDENTIFIER_BEGIN_FINISH2                     = 19, // <ClassDeclaration> ::= class Identifier Begin <ClassMembers> Finish
        RULE_CLASSDECLARATION_CLASS_IDENTIFIER_COLON_IDENTIFIER_BEGIN_FINISH     = 20, // <ClassDeclaration> ::= <AccessModifier> class Identifier ':' Identifier Begin <ClassMembers> Finish
        RULE_CLASSDECLARATION_CLASS_IDENTIFIER_COLON_IDENTIFIER_BEGIN_FINISH2    = 21, // <ClassDeclaration> ::= class Identifier ':' Identifier Begin <ClassMembers> Finish
        RULE_CLASSDECLARATION_STATIC_CLASS_IDENTIFIER_BEGIN_FINISH               = 22, // <ClassDeclaration> ::= <AccessModifier> static class Identifier Begin <ClassMembers> Finish
        RULE_CLASSDECLARATION_STATIC_CLASS_IDENTIFIER_BEGIN_FINISH2              = 23, // <ClassDeclaration> ::= static class Identifier Begin <ClassMembers> Finish
        RULE_ACCESSMODIFIER_PUBLIC                                               = 24, // <AccessModifier> ::= public
        RULE_ACCESSMODIFIER_PRIVATE                                              = 25, // <AccessModifier> ::= private
        RULE_ACCESSMODIFIER_PROTECTED                                            = 26, // <AccessModifier> ::= protected
        RULE_CLASSMEMBERS                                                        = 27, // <ClassMembers> ::= <ClassMembers> <ClassMember>
        RULE_CLASSMEMBERS2                                                       = 28, // <ClassMembers> ::= <ClassMember>
        RULE_CLASSMEMBER                                                         = 29, // <ClassMember> ::= <FieldDeclaration>
        RULE_CLASSMEMBER2                                                        = 30, // <ClassMember> ::= <MethodDeclaration>
        RULE_CLASSMEMBER3                                                        = 31, // <ClassMember> ::= <ConstructorDeclaration>
        RULE_FIELDDECLARATION_STATIC_IDENTIFIER_SEMI                             = 32, // <FieldDeclaration> ::= <AccessModifier> static <Type> Identifier ';'
        RULE_FIELDDECLARATION_IDENTIFIER_SEMI                                    = 33, // <FieldDeclaration> ::= <AccessModifier> <Type> Identifier ';'
        RULE_FIELDDECLARATION_STATIC_IDENTIFIER_SEMI2                            = 34, // <FieldDeclaration> ::= static <Type> Identifier ';'
        RULE_FIELDDECLARATION_IDENTIFIER_SEMI2                                   = 35, // <FieldDeclaration> ::= <Type> Identifier ';'
        RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH        = 36, // <ConstructorDeclaration> ::= <AccessModifier> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
        RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH2       = 37, // <ConstructorDeclaration> ::= <AccessModifier> Identifier '(' ')' Begin <Statements> Finish
        RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH3       = 38, // <ConstructorDeclaration> ::= Identifier '(' <ParameterList> ')' Begin <Statements> Finish
        RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH4       = 39, // <ConstructorDeclaration> ::= Identifier '(' ')' Begin <Statements> Finish
        RULE_CONSTRUCTORDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH = 40, // <ConstructorDeclaration> ::= static Identifier '(' ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH      = 41, // <MethodDeclaration> ::= <AccessModifier> static <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH2     = 42, // <MethodDeclaration> ::= <AccessModifier> static <ReturnType> Identifier '(' ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH3     = 43, // <MethodDeclaration> ::= static <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH4     = 44, // <MethodDeclaration> ::= static <ReturnType> Identifier '(' ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH             = 45, // <MethodDeclaration> ::= <AccessModifier> <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH2            = 46, // <MethodDeclaration> ::= <AccessModifier> <ReturnType> Identifier '(' ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH3            = 47, // <MethodDeclaration> ::= <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
        RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH4            = 48, // <MethodDeclaration> ::= <ReturnType> Identifier '(' ')' Begin <Statements> Finish
        RULE_RETURNTYPE                                                          = 49, // <ReturnType> ::= <Type>
        RULE_RETURNTYPE_VOID                                                     = 50, // <ReturnType> ::= void
        RULE_PARAMETERLIST_COMMA                                                 = 51, // <ParameterList> ::= <ParameterList> ',' <Parameter>
        RULE_PARAMETERLIST                                                       = 52, // <ParameterList> ::= <Parameter>
        RULE_PARAMETER_IDENTIFIER                                                = 53, // <Parameter> ::= <Type> Identifier
        RULE_METHODCALL_LPAREN_RPAREN                                            = 54, // <MethodCall> ::= <Reference> '(' <ArgumentList> ')'
        RULE_METHODCALL_LPAREN_RPAREN2                                           = 55, // <MethodCall> ::= <Reference> '(' ')'
        RULE_ARGUMENTLIST_COMMA                                                  = 56, // <ArgumentList> ::= <ArgumentList> ',' <Expression>
        RULE_ARGUMENTLIST                                                        = 57, // <ArgumentList> ::= <Expression>
        RULE_IFBLOCK_IF_LPAREN_RPAREN_BEGIN_FINISH                               = 58, // <IfBlock> ::= if '(' <Condition> ')' Begin <Statements> Finish
        RULE_IFBLOCK_IF_LPAREN_RPAREN_BEGIN_FINISH_ELSE_BEGIN_FINISH             = 59, // <IfBlock> ::= if '(' <Condition> ')' Begin <Statements> Finish else Begin <Statements> Finish
        RULE_LOOPFOR_FOR_LPAREN_IDENTIFIER_EQ_SEMI_SEMI_RPAREN_BEGIN_FINISH      = 60, // <LoopFor> ::= for '(' <Type> Identifier '=' <Expression> ';' <Condition> ';' <Iteration> ')' Begin <Statements> Finish
        RULE_INCDEC_PLUSPLUS                                                     = 61, // <IncDec> ::= '++' <Reference>
        RULE_INCDEC_PLUSPLUS2                                                    = 62, // <IncDec> ::= <Reference> '++'
        RULE_INCDEC_MINUSMINUS                                                   = 63, // <IncDec> ::= '--' <Reference>
        RULE_INCDEC_MINUSMINUS2                                                  = 64, // <IncDec> ::= <Reference> '--'
        RULE_ITERATION                                                           = 65, // <Iteration> ::= <IncDec>
        RULE_ITERATION_EQ                                                        = 66, // <Iteration> ::= <Reference> '=' <Expression>
        RULE_CONDITION                                                           = 67, // <Condition> ::= <Expression> <RelOp> <Expression>
        RULE_RELOP_EQ                                                            = 68, // <RelOp> ::= '='
        RULE_RELOP_LT                                                            = 69, // <RelOp> ::= '<'
        RULE_RELOP_GT                                                            = 70, // <RelOp> ::= '>'
        RULE_RELOP_EQEQ                                                          = 71, // <RelOp> ::= '=='
        RULE_RELOP_EXCLAMEQ                                                      = 72, // <RelOp> ::= '!='
        RULE_EXPRESSION_PLUS                                                     = 73, // <Expression> ::= <Expression> '+' <Term>
        RULE_EXPRESSION_MINUS                                                    = 74, // <Expression> ::= <Expression> '-' <Term>
        RULE_EXPRESSION                                                          = 75, // <Expression> ::= <Term>
        RULE_TERM_TIMES                                                          = 76, // <Term> ::= <Term> '*' <Factor>
        RULE_TERM_DIV                                                            = 77, // <Term> ::= <Term> '/' <Factor>
        RULE_TERM_PERCENT                                                        = 78, // <Term> ::= <Term> '%' <Factor>
        RULE_TERM                                                                = 79, // <Term> ::= <Factor>
        RULE_FACTOR_LPAREN_RPAREN                                                = 80, // <Factor> ::= '(' <Expression> ')'
        RULE_FACTOR                                                              = 81, // <Factor> ::= <Reference>
        RULE_FACTOR_INTEGER                                                      = 82, // <Factor> ::= Integer
        RULE_FACTOR2                                                             = 83, // <Factor> ::= <MethodCall>
        RULE_FACTOR_NEW_IDENTIFIER_LPAREN_RPAREN                                 = 84, // <Factor> ::= new Identifier '(' <ArgumentList> ')'
        RULE_FACTOR_NEW_IDENTIFIER_LPAREN_RPAREN2                                = 85, // <Factor> ::= new Identifier '(' ')'
        RULE_FACTOR3                                                             = 86, // <Factor> ::= <IncDec>
        RULE_REFERENCE_IDENTIFIER                                                = 87, // <Reference> ::= Identifier
        RULE_REFERENCE_THIS                                                      = 88, // <Reference> ::= this
        RULE_REFERENCE_DOT_IDENTIFIER                                            = 89, // <Reference> ::= <Reference> '.' Identifier
        RULE_TYPE_INT                                                            = 90, // <Type> ::= int
        RULE_TYPE_FLOAT                                                          = 91, // <Type> ::= float
        RULE_TYPE_STRING                                                         = 92, // <Type> ::= string
        RULE_TYPE_DOUBLE                                                         = 93, // <Type> ::= double
        RULE_TYPE_IDENTIFIER                                                     = 94  // <Type> ::= Identifier
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox l;
        ListBox ls;

        public MyParser(string filename, ListBox listboxoutput, ListBox lst2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);

            this.l = listboxoutput;
            this.ls = lst2;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //Begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINISH :
                //Finish
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //private
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //protected
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //public
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATIC :
                //static
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THIS :
                //this
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSMODIFIER :
                //<AccessModifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTLIST :
                //<ArgumentList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSDECLARATION :
                //<ClassDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSDECLARATIONS :
                //<ClassDeclarations>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSMEMBER :
                //<ClassMember>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSMEMBERS :
                //<ClassMembers>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<Condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDECLARATION :
                //<ConstructorDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIELDDECLARATION :
                //<FieldDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFBLOCK :
                //<IfBlock>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCDEC :
                //<IncDec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ITERATION :
                //<Iteration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOPFOR :
                //<LoopFor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODCALL :
                //<MethodCall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODDECLARATION :
                //<MethodDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<Parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERLIST :
                //<ParameterList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REFERENCE :
                //<Reference>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RELOP :
                //<RelOp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT :
                //<ReturnStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNTYPE :
                //<ReturnType>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTS :
                //<Statements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<Term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<VariableDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_BEGIN_FINISH :
                //<Program> ::= <ClassDeclarations> Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_BEGIN_FINISH2 :
                //<Program> ::= Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS :
                //<Statements> ::= <Statements> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS2 :
                //<Statements> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <IfBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <LoopFor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<Statement> ::= <MethodCall> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <ReturnStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI2 :
                //<Statement> ::= <IncDec> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER_EQ_SEMI :
                //<VariableDeclaration> ::= <Type> Identifier '=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER_SEMI :
                //<VariableDeclaration> ::= <Type> Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_EQ_SEMI :
                //<Assignment> ::= <Reference> '=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI :
                //<ReturnStatement> ::= return <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI2 :
                //<ReturnStatement> ::= return ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATIONS :
                //<ClassDeclarations> ::= <ClassDeclarations> <ClassDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATIONS2 :
                //<ClassDeclarations> ::= <ClassDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATION_CLASS_IDENTIFIER_BEGIN_FINISH :
                //<ClassDeclaration> ::= <AccessModifier> class Identifier Begin <ClassMembers> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATION_CLASS_IDENTIFIER_BEGIN_FINISH2 :
                //<ClassDeclaration> ::= class Identifier Begin <ClassMembers> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATION_CLASS_IDENTIFIER_COLON_IDENTIFIER_BEGIN_FINISH :
                //<ClassDeclaration> ::= <AccessModifier> class Identifier ':' Identifier Begin <ClassMembers> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATION_CLASS_IDENTIFIER_COLON_IDENTIFIER_BEGIN_FINISH2 :
                //<ClassDeclaration> ::= class Identifier ':' Identifier Begin <ClassMembers> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATION_STATIC_CLASS_IDENTIFIER_BEGIN_FINISH :
                //<ClassDeclaration> ::= <AccessModifier> static class Identifier Begin <ClassMembers> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECLARATION_STATIC_CLASS_IDENTIFIER_BEGIN_FINISH2 :
                //<ClassDeclaration> ::= static class Identifier Begin <ClassMembers> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSMODIFIER_PUBLIC :
                //<AccessModifier> ::= public
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSMODIFIER_PRIVATE :
                //<AccessModifier> ::= private
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSMODIFIER_PROTECTED :
                //<AccessModifier> ::= protected
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSMEMBERS :
                //<ClassMembers> ::= <ClassMembers> <ClassMember>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSMEMBERS2 :
                //<ClassMembers> ::= <ClassMember>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSMEMBER :
                //<ClassMember> ::= <FieldDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSMEMBER2 :
                //<ClassMember> ::= <MethodDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSMEMBER3 :
                //<ClassMember> ::= <ConstructorDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIELDDECLARATION_STATIC_IDENTIFIER_SEMI :
                //<FieldDeclaration> ::= <AccessModifier> static <Type> Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIELDDECLARATION_IDENTIFIER_SEMI :
                //<FieldDeclaration> ::= <AccessModifier> <Type> Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIELDDECLARATION_STATIC_IDENTIFIER_SEMI2 :
                //<FieldDeclaration> ::= static <Type> Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIELDDECLARATION_IDENTIFIER_SEMI2 :
                //<FieldDeclaration> ::= <Type> Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH :
                //<ConstructorDeclaration> ::= <AccessModifier> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH2 :
                //<ConstructorDeclaration> ::= <AccessModifier> Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH3 :
                //<ConstructorDeclaration> ::= Identifier '(' <ParameterList> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH4 :
                //<ConstructorDeclaration> ::= Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH :
                //<ConstructorDeclaration> ::= static Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH :
                //<MethodDeclaration> ::= <AccessModifier> static <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH2 :
                //<MethodDeclaration> ::= <AccessModifier> static <ReturnType> Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH3 :
                //<MethodDeclaration> ::= static <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_STATIC_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH4 :
                //<MethodDeclaration> ::= static <ReturnType> Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH :
                //<MethodDeclaration> ::= <AccessModifier> <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH2 :
                //<MethodDeclaration> ::= <AccessModifier> <ReturnType> Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH3 :
                //<MethodDeclaration> ::= <ReturnType> Identifier '(' <ParameterList> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_BEGIN_FINISH4 :
                //<MethodDeclaration> ::= <ReturnType> Identifier '(' ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNTYPE :
                //<ReturnType> ::= <Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNTYPE_VOID :
                //<ReturnType> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_COMMA :
                //<ParameterList> ::= <ParameterList> ',' <Parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST :
                //<ParameterList> ::= <Parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_IDENTIFIER :
                //<Parameter> ::= <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_LPAREN_RPAREN :
                //<MethodCall> ::= <Reference> '(' <ArgumentList> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_LPAREN_RPAREN2 :
                //<MethodCall> ::= <Reference> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST_COMMA :
                //<ArgumentList> ::= <ArgumentList> ',' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST :
                //<ArgumentList> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFBLOCK_IF_LPAREN_RPAREN_BEGIN_FINISH :
                //<IfBlock> ::= if '(' <Condition> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFBLOCK_IF_LPAREN_RPAREN_BEGIN_FINISH_ELSE_BEGIN_FINISH :
                //<IfBlock> ::= if '(' <Condition> ')' Begin <Statements> Finish else Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOPFOR_FOR_LPAREN_IDENTIFIER_EQ_SEMI_SEMI_RPAREN_BEGIN_FINISH :
                //<LoopFor> ::= for '(' <Type> Identifier '=' <Expression> ';' <Condition> ';' <Iteration> ')' Begin <Statements> Finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_PLUSPLUS :
                //<IncDec> ::= '++' <Reference>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_PLUSPLUS2 :
                //<IncDec> ::= <Reference> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_MINUSMINUS :
                //<IncDec> ::= '--' <Reference>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_MINUSMINUS2 :
                //<IncDec> ::= <Reference> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATION :
                //<Iteration> ::= <IncDec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATION_EQ :
                //<Iteration> ::= <Reference> '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<Condition> ::= <Expression> <RelOp> <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_EQ :
                //<RelOp> ::= '='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_LT :
                //<RelOp> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_GT :
                //<RelOp> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_EQEQ :
                //<RelOp> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_EXCLAMEQ :
                //<RelOp> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<Expression> ::= <Expression> '+' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<Expression> ::= <Expression> '-' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<Term> ::= <Term> '*' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<Term> ::= <Term> '/' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<Term> ::= <Term> '%' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<Term> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<Factor> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <Reference>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_INTEGER :
                //<Factor> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<Factor> ::= <MethodCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NEW_IDENTIFIER_LPAREN_RPAREN :
                //<Factor> ::= new Identifier '(' <ArgumentList> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NEW_IDENTIFIER_LPAREN_RPAREN2 :
                //<Factor> ::= new Identifier '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR3 :
                //<Factor> ::= <IncDec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REFERENCE_IDENTIFIER :
                //<Reference> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REFERENCE_THIS :
                //<Reference> ::= this
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REFERENCE_DOT_IDENTIFIER :
                //<Reference> ::= <Reference> '.' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_FLOAT :
                //<Type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<Type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_DOUBLE :
                //<Type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_IDENTIFIER :
                //<Type> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + " in line" +
                args.UnexpectedToken.Location.LineNr;
            string m2 = "Expected token" + args.ExpectedTokens.ToString();
            l.Items.Add(m2);
            l.Items.Add(message);
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "\t\t" + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
