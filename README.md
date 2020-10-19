# Blazeditor
Rich text editor for Blazor applications - Uses TinyMCE

[![main - ubuntu-latest](https://github.com/aixasz/Blazeditor/workflows/ci-ubuntu-latest/badge.svg?branch=main)](https://github.com/aixasz/Blazeditor/actions?query=workflow%3Aci-ubuntu-latest) [![Nuget](https://img.shields.io/nuget/v/Blazeditor.TinyMCE.svg)](https://www.nuget.org/packages/Blazeditor.TinyMCE)

### Getting Setup

You can install the package via the nuget package manager - just search for *Blazeditor.TinyMCE*. You can also install via powershell using the following command.

``` powershell
Install-Package Blazeditor.TinyMCE
```

Or via the dotnet CLI.

``` bash
dotnet add package Blazeditor.TinyMCE
```

### Add Imports

Add the following to your *_Imports.razor*

``` CSharp
@using Blazeditor.TinyMCE
```

Add the following to your *_Host.cshtml*

``` html
<script src="_content/Blazeditor.TinyMCE/tinymce.min.js"></script>
<script src="_content/Blazeditor.TinyMCE/blazeditor.js"></script>
```

## Usage
Please checkout the [sample projects](https://github.com/aixasz/Blazeditor/tree/main/samples) in this repo to see working examples of the features in the rich text editor component

### Display a text editor

Just use TextEditor in place of any textarea tags.
```razor
<TextEditor Id="text-editor">
    <EditorContent>
        This example shows you the blazor with TinyMCE.
    </EditorContent>
</TextEditor>
```

### Customizing text editor 
The rich text editor can be customized the toolbar and mode for variety of uses. These option can be set globally or changed programatically on a per text editor basis.

###### Toolbar
For normal mode, text editor has a toolbar in the top by default. The toolbar can be customized to show the [core plugins from TinyMCE](https://www.tiny.cloud/apps/#core-plugins) using the `BlazeditorOption` parameter to set the custom plugins globally.

In html scope:
```razor
<TextEditor Id="text-editor" BlazeditorOption="option">
    <EditorContent>
        This example to customized plugins in toolbar.
    </EditorContent>
</TextEditor>
```
And code scope:
``` razor
@code
{
    BlazeditorOption option = new BlazeditorOption
    {
        Toolbar = "bold italic | alignleft aligncenter alignright"
    };
}
```

##### Inline mode

_**Note:** This option is not supported on mobile devices._

The inline editing mode is used for merging the editing and reading views of the page for a seamless editing experience and true WYSIWYG behavior.

set the `InlineMode` option to `true`. For example:

``` razor
BlazeditorOption option = new BlazeditorOption
{
    InlineMode = true
};
```

### Get and Set content
This is the easy way to get content from text editor using `@ref` parameter with `TextEditor` property.

``` razor
<TextEditor Id="text-editor" @ref="@textEditor">
    <EditorContent>
        <p>This example to get the content.</p>
    </EditorContent>
</TextEditor>

@code{
    private TextEditor textEditor;
    async Task<string> GetContent() => await textEditor.GetContent();
}
```

There are two ways to set the content to editor. 

Using `<EditorContent>` inside `<TextEditor>` example: 
``` razor
<TextEditor Id="text-editor">
    <EditorContent>
        <p>This example to set the content.</p>
    </EditorContent>
</TextEditor>
```
Or using `@ref` parameter with `TextEditor` property.

``` razor
<TextEditor Id="text-editor" @ref="@textEditor">
    <EditorContent>
        <p>This example to clear content by set empty.</p>
    </EditorContent>
</TextEditor>

<button @onclick="Clear">Clear</button>

@code{
    TextEditor textEditor;
    async Task Clear() => await textEditor.SetContent(string.Empty);
}
```
