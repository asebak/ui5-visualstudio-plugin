// Created by Ahmad Sebak on 19/03/2015

#region Using

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using Microsoft.Web.Editor.Intellisense;
using Intel = Microsoft.VisualStudio.Language.Intellisense;

#endregion

namespace JavascriptLanguage
{
    [Export(typeof (Intel.ICompletionSourceProvider))]
    [Order(Before = "High")]
    [ContentType("JavaScript"),
     Name("EnhancedJavaScriptCompletionSAPUI5")]
    public class JavaScriptCompletionSourceProvider : Intel.ICompletionSourceProvider
    {
        [Import] private ICssNameCache _classNames;

        public Intel.ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer)
        {
            return
                textBuffer.Properties.GetOrCreateSingletonProperty(
                    () => new JavaScriptCompletionSource(textBuffer, _classNames));
        }
    }

    public class JavaScriptCompletionSource : Intel.ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly ReadOnlyCollection<StringCompletionSource> completionSources;

        public JavaScriptCompletionSource(ITextBuffer buffer, ICssNameCache classNames)
        {
            _buffer = buffer;

            completionSources = new ReadOnlyCollection<StringCompletionSource>(new StringCompletionSource[]
            {
                new JsDocCompletionSource(),
                new SAPUI5JSCompletion()
            });
        }

        public void AugmentCompletionSession(Intel.ICompletionSession session, IList<Intel.CompletionSet> completionSets)
        {
            var position = session.GetTriggerPoint(_buffer).GetPoint(_buffer.CurrentSnapshot);
            var line = position.GetContainingLine();

            if (line == null)
            {
                return;
            }

            var text = line.GetText();
            var linePosition = position - line.Start;

            foreach (var source in completionSources)
            {
                var span = source.GetInvocationSpan(text, linePosition, position);
                if (span == null) continue;

                if (span.Value.Length == 0)
                    return;

                var trackingSpan = _buffer.CurrentSnapshot.CreateTrackingSpan(span.Value.Start + line.Start,
                    span.Value.Length, SpanTrackingMode.EdgeInclusive);
                completionSets.Add(new StringCompletionSet(
                    source.GetType().Name,
                    trackingSpan,
                    source.GetEntries(text[span.Value.Start], session.TextView.Caret.Position.BufferPosition)
                    ));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private class StringCompletionSet : Intel.CompletionSet
        {
            public StringCompletionSet(string moniker, ITrackingSpan span, IEnumerable<Intel.Completion> completions)
                : base(moniker, "SAPUI5", span, completions, null)
            {
            }

            public override void SelectBestMatch()
            {
                base.SelectBestMatch();

                var snapshot = ApplicableTo.TextBuffer.CurrentSnapshot;
                var userText = ApplicableTo.GetText(snapshot);

                // If VS couldn't find an exact match, try again without closing quote.
                if (SelectionStatus.IsSelected) return;
                if (userText.Length == 0 || userText.Last() != userText[0])
                    return; // If there is no closing quote, do nothing.

                var originalSpan = ApplicableTo;
                try
                {
                    var spanPoints = originalSpan.GetSpan(snapshot);
                    ApplicableTo = snapshot.CreateTrackingSpan(spanPoints.Start, spanPoints.Length - 1,
                        ApplicableTo.TrackingMode);
                    base.SelectBestMatch();
                }
                finally
                {
                    ApplicableTo = originalSpan;
                }
            }
        }
    }
}