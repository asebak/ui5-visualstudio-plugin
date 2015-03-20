// Created by Ahmad Sebak on 19/03/2015

#region Using

using System;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

#endregion

namespace JavascriptLanguage
{
    public static class FileHelpers
    {
        /// <summary>
        ///     Gets the currently selected point within a specific buffer type, or null if there is no selection or if the
        ///     selection is in a different buffer.
        /// </summary>
        /// <param name="view">The TextView containing the selection</param>
        /// <param name="contentType">The ContentType to filter the selection by.</param>
        public static SnapshotPoint? GetSelection(this ITextView view, string contentType)
        {
            return view.BufferGraph.MapDownToInsertionPoint(view.Caret.Position.BufferPosition,
                PointTrackingMode.Positive, ts => ts.ContentType.IsOfType(contentType));
        }

        /// <summary>
        ///     Gets the currently selected point within a specific buffer type, or null if there is no selection or if the
        ///     selection is in a different buffer.
        /// </summary>
        /// <param name="view">The TextView containing the selection</param>
        /// <param name="contentTypes">The ContentTypes to filter the selection by.</param>
        public static SnapshotPoint? GetSelection(this ITextView view, params string[] contentTypes)
        {
            return view.BufferGraph.MapDownToInsertionPoint(view.Caret.Position.BufferPosition,
                PointTrackingMode.Positive, ts => contentTypes.Any(c => ts.ContentType.IsOfType(c)));
        }

        /// <summary>
        ///     Gets the currently selected point within a specific buffer type, or null if there is no selection or if the
        ///     selection is in a different buffer.
        /// </summary>
        /// <param name="view">The TextView containing the selection</param>
        /// <param name="contentTypeFilter">The ContentType to filter the selection by.</param>
        public static SnapshotPoint? GetSelection(this ITextView view, Func<IContentType, bool> contentTypeFilter)
        {
            return view.BufferGraph.MapDownToInsertionPoint(view.Caret.Position.BufferPosition,
                PointTrackingMode.Positive, ts => contentTypeFilter(ts.ContentType));
        }
    }
}