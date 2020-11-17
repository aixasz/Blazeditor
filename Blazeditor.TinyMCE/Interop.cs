using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazeditor.TinyMCE
{
    public static class Interop
    {
        public static ValueTask<object> InitializeTextEditor
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
                "blazeditorCallbackProxy",
                dotNetObjectReference,
                "blazeditorInit",
                idSelector,
                new
                {
                    inlineMode = blazeditorOption.InlineMode,
                    toolbar = blazeditorOption.Toolbar,
                    menubar = blazeditorOption.ShowMenuBar,
                    plugins = blazeditorOption.Plugins,
                    paste_data_images = blazeditorOption.PasteDataImage,
                    paste_as_text = blazeditorOption.PasteAsText
                },
                onchangeCallback
            );
        }

        public static ValueTask<string> GetContent(IJSRuntime jSRuntime, string id)
            => jSRuntime.InvokeAsync<string>("blazeditorGetContent", id);

        public static ValueTask<object> SetContent(IJSRuntime jSRuntime, string id, string data)
            => jSRuntime.InvokeAsync<object>("blazeditorSetContent", id, data);
    }
}
