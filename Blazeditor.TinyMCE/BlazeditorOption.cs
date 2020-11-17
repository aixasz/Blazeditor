namespace Blazeditor.TinyMCE
{
    public class BlazeditorOption
    {
        public bool InlineMode { get; set; }

        public string Plugins { get; set; } = "paste autolink link wordcount";

        public string Toolbar { get; set; } = "undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | outdent indent | link";

        public bool ShowMenuBar { get; set; }

        public bool PasteAsText { get; set; }

        public bool PasteDataImage { get; set; }
    }
}
