var tabStripWs1;
var tabStripWs2;

$(document).ready(function () {
    tabStripWs1 = $('#panel-left--top-tabstrip').kendoTabStrip().data('kendoTabStrip');
    tabStripWs2 = $('#panel-right--top-tabstrip').kendoTabStrip().data('kendoTabStrip');

    $('#WS1Home').click(function () {
        var url = $('#WS1HomeURL').val();
        loadUrl('#WS1HomeFrame', url);
    });

    $('#WS2Home').click(function () {
        var url = $('#WS2HomeURL').val();
        loadUrl('#WS2HomeFrame', url);
    });

    $.pm.bind("openUrl", function (data) {
        var tabIndex;

        switch(data.workspaceId) {
            case 1:
                {
                    tabIndex = append_new_tab_ws2(data.url, data.caption);
                    break;
                }
            case 2:
                {
                    tabIndex = append_new_tab_ws1(data.url, data.caption);
                    break;
                }
            default:
                {
                    tabIndex = -1;
                }
        }

        return {
            message: "Data Received & Processed",
            result: tabIndex
        };
    });
    

    $.pm.bind("closeTab", function (data) {
        switch (data.workspaceId) {
            case 1:
                {
                    //remove_tab_ws1(data.tabIndex);
                    break;
                }
            case 2:
                {
                    //remove_tab_ws2(data.tabIndex);
                    break;
                }
        }

        return {
            message: "Data Received & Processed",
            result: 1
        };
    });
});

function append_new_tab_ws1(url, label) {
    var getItemWs1 = function(target) {
        var itemIndex = target[0].value;
        return tabStripWs1.tabGroup.children('li').eq(itemIndex);
    }, tabAppendWs1 = function(e) {
        tabStripWs1.append({
            text: label,
            content: '<iframe class="workspace-iframe" src="' + url + '" ></iframe>'
        });
    }();

    var tabIndex = (tabStripWs1.tabGroup.children('li').length - 1);

    tabStripWs1.select(tabIndex);

    return tabIndex;
}

function append_new_tab_ws2(url, label) {
    var getItemWs2 = function(target) {
        var itemIndex = target[0].value;
        return tabStripWs2.tabGroup.children('li').eq(itemIndex);
    }, tabAppendWs2 = function(e) {
        tabStripWs2.append({
            text: label,
            content: '<iframe class="workspace-iframe" src="' + url + '" ></iframe>'
        });
    }();

    var tabIndex = (tabStripWs2.tabGroup.children("li").length - 1);

    tabStripWs2.select(tabIndex);

    return tabIndex;
}

function loadUrl(iframeId, url) {
    alert(url);
    $(iframeId).attr('src', url);
}

function getUrl(iframeId) {
    var url = $(iframeId).attr('src');
    alert(url);
}