using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazeditor.TinyMCE
{
    public static class Interop
    {
        internal static ValueTask<object> InitialTinyMCE
        (
            IJSRuntime jSRuntime,
            DotNetObjectReference<TextEditor> dotNetObjectReference,
            string idSelector,
            BlazeditorOption blazeditorOption,
            string onchangeCallback
        )
        {
            return jSRuntime.InvokeAsync<object>
            (
                "callbackProxy",
                dotNetObjectReference,
                "blazeditorInit",
                idSelector,
                new
                {
                    inlineMode = blazeditorOption.InlineMode,
                    toolbar = blazeditorOption.Toolbar,
                    menubar = blazeditorOption.ShowMenuBar
                },
                onchangeCallback
            );
        }

        internal static ValueTask<string> GetContent(IJSRuntime jSRuntime, string id)
            => jSRuntime.InvokeAsync<string>("blazeditorGetContent", id);

        internal static ValueTask<object> SetContent(IJSRuntime jSRuntime, string id, string data)
            => jSRuntime.InvokeAsync<object>("blazeditorSetContent", id, data);
    }
}
