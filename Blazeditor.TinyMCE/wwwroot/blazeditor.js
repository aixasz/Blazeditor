// Proxy function that serves as middlemen
window.callbackProxy = function (dotNetInstance, callMethod, id, option, callbackMethod) {
    // Execute function that will do the actual job
    window[callMethod](id, option, function (result) {
        // Invoke the C# callback method passing the result as parameter
        return dotNetInstance.invokeMethodAsync(callbackMethod, result);
    });
    return true;
};

window.blazeditorInit = function (id, option, callback) {
    var html = document.getElementById(id).innerHTML;

    function setup(ed) {
        ed.on("init",
            function () {
                tinyMCE.get(id).setContent(html);
                tinyMCE.execCommand('mceRepaint');
            }
        );

        ed.on("change", function () {
            var content = ed.getContent();
            callback(content);
        });
    }


    if (option.inlineMode) {
        tinymce.init({
            selector: '#' + id,
            inline: true,
            toolbar: option.toolbar,
            setup: setup,
            menubar: option.menubar
        });
    } else {
        tinymce.init({
            selector: 'textarea#' + id,
            toolbar: option.toolbar,
            setup: setup,
            menubar: option.menubar
        });
    }
}

window.blazeditorSetContent = function (id, data) {
    tinymce.get(id).setContent(data);
    tinyMCE.execCommand('mceRepaint');
}

window.blazeditorGetContent = function (id) {
    return tinymce.get(id).getContent();
}
