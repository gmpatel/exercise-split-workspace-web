var tabStripWs1;
var tabStripWs2;

$(document).ready(function () {

    var size = '200px';

    var setSize = function () {
        var panes = $("#Horizontal").children();
        var pane = panes[0];

        $("#Horizontal").kendoSplitter().data("kendoSplitter").size(pane, size);
        //$("#Horizontal").data("kendoSplitter").size(pane, size);

        if (size === '200px')
            size = '400px';
        else
            size = '200px';
    };
    
    tabStripWs1 = $('#panel-left--top-tabstrip').kendoTabStrip().data('kendoTabStrip');
    tabStripWs2 = $('#panel-right--top-tabstrip').kendoTabStrip().data('kendoTabStrip');

    $(document).on('click', 'li.k-item', function () {
        var div = $(this).attr("aria-controls");
        if (div) {
            var iframe = $('#' + div + ' iframe'), src = $(iframe).attr("src"), data = $(iframe).attr("data");
            if (data) {
                if (!src) {
                    $(iframe).attr('src', data);
                }
            }
        }
    });
    
    $('#WS1Home').click(function () {
        var url = $('#WS1HomeURL').val();
        loadUrl('#WS1HomeFrame', url);
    });

    $('#WS2Home').click(function () {
        var url = $('#WS2HomeURL').val();
        loadUrl('#WS2HomeFrame', url);
    });
    
    $('#TestResize').click(function () {
        setSize();
    });
});


function process(response) {
    if (response.processWorkSpace1 === 1) {
        performWorkSpace1(response.dataWorkSpace1);
    }
    
    if (response.processWorkSpace2 === 1) {
        performWorkSpace2(response.dataWorkSpace2);
    }
}

function performWorkSpace1(data) {
    var label; clear_all_tabs_ws1();
    _.each(data, function (item) {
        label = item.value;
        append_new_tab_ws1(item.url, label);
    });
}

function performWorkSpace2(data) {
    var label; clear_all_tabs_ws2();
    _.each(data, function (item) {
        label = item.value;
        append_new_tab_ws2(item.url, label);
    });
}

function clear_all_tabs_ws1() {
    var tab;

    for (var i = 0; i < 999; i++) {
        tab = tabStripWs1.tabGroup.children("li").eq(1);
        tabStripWs1.remove(tab);
    }
    
    tab = tabStripWs1.tabGroup.children("li").eq(0);
    tabStripWs1.select(tab);
}

function clear_all_tabs_ws2() {
    var tab;

    for (var i = 0; i < 999; i++) {
        tab = tabStripWs2.tabGroup.children("li").eq(1);
        tabStripWs2.remove(tab);
    }

    tab = tabStripWs2.tabGroup.children("li").eq(0);
    tabStripWs2.select(tab);
}

function append_new_tab_ws1(url, label) {
    tabStripWs1.append({
        text: label,
        content: '<iframe class="workspace-iframe" data="' + url + '" ></iframe>'
    });
}

function append_new_tab_ws2(url, label) {
    tabStripWs2.append({
        text: label,
        content: '<iframe class="workspace-iframe" data="' + url + '" ></iframe>'
    });
}

function loadUrl(iframeId, url) {
    alert(url);
    $(iframeId).attr('src', url);
}

function getUrl(iframeId) {
    var url = $(iframeId).attr('src');
    alert(url);
}