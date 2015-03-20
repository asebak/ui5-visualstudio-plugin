// Created by Ahmad Sebak on 19/03/2015

#region Using

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.Web.Editor;
using Microsoft.Web.Editor.EditorHelpers;
using Microsoft.Web.Editor.Intellisense;
using Intel = Microsoft.VisualStudio.Language.Intellisense;

#endregion

namespace JavascriptLanguage
{
    internal class ElementsByTagNameCompletionSource : FunctionCompletionSource
    {
        private static readonly ImageSource _glyph = GlyphService.GetGlyph(Intel.StandardGlyphGroup.GlyphXmlItem,
            Intel.StandardGlyphItem.GlyphItemPublic);

        private static readonly ReadOnlyCollection<Tuple<string, string>> tagNames =
            UnknownTagErrorTagProvider.GetListEntriesCache(includeUnstyled: true)
                .Select(c => Tuple.Create(c.DisplayText, c.Description))
                .Distinct()
                .OrderBy(s => s)
                .ToList()
                .AsReadOnly();

        protected override string FunctionName
        {
            get { return "getElementsByTagName"; }
        }

        public override IEnumerable<Intel.Completion> GetEntries(char quote, SnapshotPoint caret)
        {
            return tagNames.Select(t => new Intel.Completion(
                quote + t.Item1 + quote,
                quote + t.Item1 + quote,
                t.Item2,
                _glyph,
                null
                ));
        }
    }

    internal abstract class CssNameCacheCompletionSource : FunctionCompletionSource
    {
        private static readonly ImageSource _glyph = GlyphService.GetGlyph(Intel.StandardGlyphGroup.GlyphXmlAttribute,
            Intel.StandardGlyphItem.GlyphItemPublic);

        private readonly ICssNameCache _classNames;

        public CssNameCacheCompletionSource(ICssNameCache classNames)
        {
            _classNames = classNames;
        }

        protected override string FunctionName
        {
            get { return "getElementsByClassName"; }
        }

        protected abstract CssNameType NameType { get; }

        public override IEnumerable<Intel.Completion> GetEntries(char quote, SnapshotPoint caret)
        {
            return _classNames.GetNames(new Uri(caret.Snapshot.TextBuffer.GetFileName()), caret, NameType)
                .Select(s => s.Name)
                .Distinct()
                .OrderBy(s => s)
                .Select(s => new Intel.Completion(quote + s + quote, quote + s + quote, null, _glyph, null));
        }
    }

    internal class ElementsByClassNameCompletionSource : CssNameCacheCompletionSource
    {
        public ElementsByClassNameCompletionSource(ICssNameCache classNames) : base(classNames)
        {
        }

        protected override string FunctionName
        {
            get { return "getElementsByClassName"; }
        }

        protected override CssNameType NameType
        {
            get { return CssNameType.Class; }
        }
    }

    internal class ElementsByIdCompletionSource : CssNameCacheCompletionSource
    {
        public ElementsByIdCompletionSource(ICssNameCache classNames) : base(classNames)
        {
        }

        protected override string FunctionName
        {
            get { return "getElementById"; }
        }

        protected override CssNameType NameType
        {
            get { return CssNameType.Id; }
        }
    }
}