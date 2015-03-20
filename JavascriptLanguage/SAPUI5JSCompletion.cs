// Created by Ahmad Sebak on 19/03/2015

#region Using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;
using JavascriptLanguage.Schemas;
using Microsoft.VisualStudio.JSLS;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.Web.Editor;

#endregion

namespace JavascriptLanguage
{
    internal class SAPUI5JSCompletion : StringCompletionSource
    {
        private const string API_SCHEMA = @"https://sapui5.netweaver.ondemand.com/sdk/docs/api/index.xml";

        private static readonly Type jsTaggerType =
            typeof (JavaScriptLanguageService).
                Assembly.GetType("Microsoft.VisualStudio.JSLS.Classification.Tagger");

        private static readonly ImageSource _glyph =
            GlyphService.GetGlyph(StandardGlyphGroup.GlyphGroupField, StandardGlyphItem.GlyphItemPublic);

        private static readonly Dictionary<string, Namespace> _namespaces = new Dictionary<string, Namespace>();
        private static NamespaceCollection apiDef;
        private static string currentText;

        public override Span? GetInvocationSpan(string text, int linePosition, SnapshotPoint position)
        {
            if (IsComment(position) || (linePosition <= 0))
            {
                return null;
            }

            var startIndex = text.LastIndexOf(' ', linePosition - 1);

            if (startIndex == -1 || !text.Substring(startIndex, linePosition - startIndex).Contains(' '))
            {
                return null;
            }
            var endIndex = linePosition + text.Substring(linePosition).TakeWhile(Char.IsLetter).Count();


            currentText = text.Split(' ').Last();
            return Span.FromBounds(startIndex, endIndex);
        }

        private static bool IsComment(SnapshotPoint position)
        {
            if (position.Position < 2)
                return false;

            var tagger = position.Snapshot.TextBuffer.Properties.GetProperty<ITagger<ClassificationTag>>(jsTaggerType);

            var span = Span.FromBounds(position.Position - 1, position.Position);
            var spans = new NormalizedSnapshotSpanCollection(new SnapshotSpan(position.Snapshot, span));
            var classifications = tagger.GetTags(spans);

            return classifications.Any(c => c.Tag.ClassificationType.IsOfType("comment"));
        }

        public override IEnumerable<Completion> GetEntries(char quote, SnapshotPoint caret)
        {
            if (apiDef == null)
            {
                apiDef = deserialize(API_SCHEMA);
            }
            Namespace output;
            if (_namespaces.TryGetValue(currentText, out output))
            {
                return GetCompletions(currentText, _namespaces[currentText]);
            }

            if (currentText[currentText.Length - 1] == '.')
            {
                currentText = currentText.Remove(currentText.LastIndexOf("."), 1);
            }
            foreach (var autoCompletedTerm in apiDef.Items
                .Select(nameSpace => Find(nameSpace, currentText))
                .Where(autoCompletedTerm => autoCompletedTerm != null))
            {
                _namespaces[currentText] = autoCompletedTerm;
                return GetCompletions(currentText, autoCompletedTerm);
            }
            return null;
        }

        private List<Completion> GetCompletions(string text, Namespace elements)
        {
            //return null;
            List<Completion> completions = new List<Completion>();

            if (elements.Children == null)
            {
                completions.Add(new Completion(elements.Description, elements.Description, elements.Description, _glyph,
                    null));
            }
            elements.Children.Items.ForEach(
                child =>
                    completions.Add(new Completion(child.Description, child.Description, child.Description, _glyph, null)));
            return completions;
        }

        private static NamespaceCollection deserialize(String path)
        {
            var myXmlDocument = new XmlDocument();
            myXmlDocument.Load(path);
            NamespaceCollection obj;
            using (var reader = XmlReader.Create(new StringReader(myXmlDocument.InnerXml)))
            {
                reader.MoveToContent();
                obj = (NamespaceCollection) new XmlSerializer(typeof (NamespaceCollection)).Deserialize(reader);
            }

            return obj;
        }

        private static Namespace Find(Namespace node, string name)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Alias == name)
            {
                return node;
            }

            return node.Children == null
                ? null
                : node.Children.Items.Select(child => Find(child, name))
                    .FirstOrDefault(found => found != null);
        }
    }
}