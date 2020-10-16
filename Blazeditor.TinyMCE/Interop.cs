using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazeditor.TinyMCE
{
    public static class Interop
    {
        internal static ValueTask<object> InitialTinyMCE
        (
            IJSRuntime jSRuntime,
            string idSelector,
            BlazeditorOption blazeditorOption
        )
        {
            return jSRuntime.InvokeAsync<object>
            (
                "blazeditorTinyMCE.init",
                idSelector,
                new
                {
                    inlineMode = blazeditorOption.InlineMode,
                    toolbar = blazeditorOption.Toolbar,
                    menubar = blazeditorOption.ShowMenuBar
                }
            );
        }

        internal static ValueTask<string> GetContent(IJSRuntime jSRuntime, string id)
            => jSRuntime.InvokeAsync<string>("blazeditorTinyMCE.getContent", id);

        internal static ValueTask<object> SetContent(IJSRuntime jSRuntime, string id, string data)
            => jSRuntime.InvokeAsync<object>("blazeditorTinyMCE.setContent", id, data);

    }
}
