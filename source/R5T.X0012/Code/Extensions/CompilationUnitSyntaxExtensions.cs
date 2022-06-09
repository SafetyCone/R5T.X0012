using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0134;

using Instances = R5T.X0012.Instances; /// <see cref="R5T.X0012.Documentation"/>


namespace System
{
    public static partial class CompilationUnitSyntaxExtensions
    {
        public static AddNodeResult<CompilationUnitSyntax, NamespaceDeclarationSyntax> AddNamespace(this CompilationUnitSyntax compilationUnit,
            NamespaceDeclarationSyntax @namespace)
        {
            return compilationUnit.AddNode(
                @namespace,
                Instances.SyntaxOperator.AddNamespace);
        }

        public static CompilationUnitSyntax AddNamespace(this CompilationUnitSyntax compilationUnit,
            NamespaceDeclarationSyntax @namespace,
            out ISyntaxNodeAnnotation<NamespaceDeclarationSyntax> namespaceAnnotation)
        {
            return Instances.SyntaxNodeOperator.AddNamespace(
                compilationUnit,
                @namespace,
                out namespaceAnnotation);
        }

        public static AddNodeResult<CompilationUnitSyntax, UsingDirectiveSyntax> AddUsingDirective(this CompilationUnitSyntax compilationUnit,
            AnnotatedNode<UsingDirectiveSyntax> usingDirective)
        {
            return compilationUnit.AddNode(
                usingDirective,
                Instances.SyntaxOperator.AddUsingDirective);
        }

        public static AddNodeResult<CompilationUnitSyntax, UsingDirectiveSyntax> AddUsingDirective(this CompilationUnitSyntax compilationUnit,
            UsingDirectiveSyntax usingDirective)
        {
            return compilationUnit.AddNode(
                usingDirective,
                Instances.SyntaxOperator.AddUsingDirective);
        }

        public static CompilationUnitSyntax AddUsingDirective(this CompilationUnitSyntax compilationUnit,
            UsingDirectiveSyntax usingDirective,
            out ISyntaxNodeAnnotation<UsingDirectiveSyntax> usingDirectiveAnnotation)
        {
            return Instances.SyntaxNodeOperator.AddUsingDirective(
                compilationUnit,
                usingDirective,
                out usingDirectiveAnnotation);
        }
    }
}
