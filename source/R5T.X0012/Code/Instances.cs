using System;

using R5T.F0013;


namespace R5T.X0012
{
    public static class Instances
    {
        public static ISyntaxNodeOperator SyntaxNodeOperator { get; } = F0013.SyntaxNodeOperator.Instance;
        public static B0006.ISyntaxOperator SyntaxOperator { get; } = B0006.SyntaxOperator.Instance;
    }
}
