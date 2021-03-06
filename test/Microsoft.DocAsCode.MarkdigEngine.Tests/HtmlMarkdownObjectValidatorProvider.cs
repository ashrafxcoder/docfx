// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.MarkdigEngine.Tests
{
    using System.Collections.Immutable;
    using System.Composition;

    using MarkdigEngine.Extensions;

    using Markdig.Syntax;
    using Microsoft.DocAsCode.Common;

    [Export(ContractName, typeof(IMarkdownObjectValidatorProvider))]
    public class HtmlMarkdownObjectValidatorProvider : IMarkdownObjectValidatorProvider
    {
        public const string ContractName = "Html";

        public const string WarningMessage = "Html Tag!";

        ImmutableArray<IMarkdownObjectValidator> IMarkdownObjectValidatorProvider.GetValidators()
        {
            return ImmutableArray.Create(
                MarkdownObjectValidatorFactory.FromLambda<HtmlBlock>(
                    block => Logger.LogWarning(WarningMessage)));
        }
    }
}
