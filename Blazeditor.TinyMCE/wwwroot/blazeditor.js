window.blazeditorTinyMCE = {
    init: function (id, option) {
        var html = document.getElementById(id).innerHTML;
        if (option.inlineMode) {
            tinymce.init({
                selector: '#' + id,
                inline: true,
                toolbar: option.toolbar,
                menubar: option.menubar
            });
        } else {
            tinymce.init({
                selector: 'textarea#' + id,
                toolbar: option.toolbar,
                setup: function (ed) {
                    ed.on("init",
                        function () {
                            tinyMCE.get(id).setContent(html);
                            tinyMCE.execCommand('mceRepaint');
                        }
                    );
                }
            });
        }
    },
    setContent: function (id, data) {
        tinymce.get(id).setContent(data);
        tinyMCE.execCommand('mceRepaint');
    },
    getContent: function (id) {
        return tinymce.get(id).getContent();
    }
}