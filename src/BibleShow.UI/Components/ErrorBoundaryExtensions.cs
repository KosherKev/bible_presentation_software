using System;
using Microsoft.Maui.Controls;

namespace BibleShow.UI.Components;

public static class ErrorBoundaryExtensions
{
    public static T WithErrorBoundary<T>(this T view, IServiceProvider services) where T : View
    {
        ArgumentNullException.ThrowIfNull(view);
        ArgumentNullException.ThrowIfNull(services);

        var errorBoundary = new ErrorBoundary(services)
        {
            Content = view
        };

        return (T)errorBoundary.Content;
    }

    public static ErrorBoundary? GetErrorBoundary(this View view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var current = view.Parent;
        while (current != null)
        {
            if (current is ErrorBoundary errorBoundary)
            {
                return errorBoundary;
            }
            current = current.Parent;
        }
        return null;
    }

    public static void PropagateError(this View view, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(view);
        ArgumentNullException.ThrowIfNull(exception);

        var errorBoundary = view.GetErrorBoundary();
        if (errorBoundary != null)
        {
            errorBoundary.HandleError(exception);
        }
        else
        {
            throw new InvalidOperationException("No error boundary found in the visual tree. Ensure the view is wrapped in an ErrorBoundary component.", exception);
        }
    }
}