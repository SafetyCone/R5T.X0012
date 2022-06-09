﻿using System;

using Microsoft.CodeAnalysis;

using R5T.T0134;


namespace System
{
    public static class SyntaxNodeExtensions
    {
        /// <summary>
        /// Does not verify that the node has the given node annotation.
        /// </summary>
        public static AddNodeResult<TParentNode, TNode> AddNode_Unverified<TParentNode, TNode>(this TParentNode parentNode,
            TNode node,
            ISyntaxNodeAnnotation<TNode> nodeAnnotation,
            Func<TParentNode, TNode, TParentNode> addSimple)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            parentNode = addSimple(parentNode, node);

            var output = AddNodeResult.From(parentNode, nodeAnnotation);
            return output;
        }

        public static AddNodeResult<TParentNode, TNode> AddNode<TParentNode, TNode>(this TParentNode parentNode,
            TNode node,
            ISyntaxNodeAnnotation<TNode> nodeAnnotation,
            Func<TParentNode, TNode, TParentNode> addSimple)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            // Verify node has annotation.
            node.VerifyHasAnnotation(nodeAnnotation);

            return parentNode.AddNode_Unverified(
                node,
                nodeAnnotation,
                addSimple);
        }

        public static AddNodeResult<TParentNode, TNode> AddNode<TParentNode, TNode>(this TParentNode parentNode,
            TNode node,
            Func<TParentNode, TNode, TParentNode> addSimple)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var annotatedNode = node.Annotate(out var nodeAnnotation);

            return parentNode.AddNode_Unverified(
                annotatedNode,
                nodeAnnotation,
                addSimple);
        }

        /// <summary>
        /// Note: assumes the annotated node is already verified.
        /// </summary>
        public static AddNodeResult<TParentNode, TNode> AddNode<TParentNode, TNode>(this TParentNode parentNode,
            AnnotatedNode<TNode> annotatedNode,
            Func<TParentNode, TNode, TParentNode> addSimple)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            return parentNode.AddNode_Unverified(
                annotatedNode.Node,
                annotatedNode.Annotation,
                addSimple);
        }

        /// <summary>
        /// Note: assumes the annotated node is already verified.
        /// </summary>
        public static AddNodeResult<TParentNode, TNode> AddNode_VerifyAnnotatedNode<TParentNode, TNode>(this TParentNode parentNode,
            AnnotatedNode<TNode> annotatedNode,
            Func<TParentNode, TNode, TParentNode> addSimple)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            annotatedNode.Verify();

            return parentNode.AddNode(
                annotatedNode,
                addSimple);
        }
    }
}
