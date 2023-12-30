
using System.Runtime.CompilerServices;

namespace GeoWall_E
{
   
    public class Link
    {
        private readonly string code;
        private Error errores;
        private List<Tuple<Type, Color>> para_dibujar;
        private List<Token> tokens;
        private AST? ast;
        private Evaluator? evaluator;
        public List<Tuple<Type, Color>> ToDraw => para_dibujar;
        public Error Errors => errores;

        public Link(string code)
        {
            this.code = code;
            errores = new Error();
            para_dibujar = new List<Tuple<Type, Color>>();
            tokens = new List<Token>();

            LinkLexer();
            LinkParse();
            LinkSemantic();
            if (!errores.AnyError())
            {
                LinkEvaluate();
            }
        }

        public void LinkEvaluate()
        {
            this.evaluator.Evaluate();
            this.para_dibujar = evaluator.ToDraw;
        }

        public void LinkLexer()
        {
            var lexer = new Lexer(code);
            tokens = lexer.Tokenize();
            errores = lexer.Errors;
        }

        public void LinkParse()
        {
            var parser = new Parser(tokens, errores);
            ast = parser.Parse_();
            errores = parser.Errors;
        }

        public void LinkSemantic()
        {
            if (ast == null) return;
            evaluator = new Evaluator(ast.Root, errores);
        }

    }
}