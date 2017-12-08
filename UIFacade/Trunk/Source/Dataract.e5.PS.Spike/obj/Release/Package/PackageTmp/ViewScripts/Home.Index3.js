var tabStripWs1;
var tabStripWs2;

$(document).ready(function () {

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

    $.pm.bind("dataract-message", function (data) {
        if (data.messageType === "openRelatedWork") {
            if (data.workspaceId === 2) {
                var url1 = '/Services/Api?Key=GetWorkForClaim&QryValue=' + data.claimNumber;
                var url2 = '/Services/Api?Key=GetClaim&QryValue=' + data.claimNumber;

                process(data, url1, url2);

                return {
                    message: "Claim Number Received Successfully...",
                    result: 1
                };
            }
            
            return {
                message: "Message Received From Invalid Workspace...",
                result: 0
            };
        }
        
        return {
            message: "Invalid Message Received...",
            result: 0
        };
    });
});


function process(data, url1, url2) {
    $.get(url1, function (res) {
        performWorkSpace1(data, res);
    }, 'json');
    
    $.get(url2, function (res) {
        performWorkSpace2(data, res);
    }, 'json');
}

function performWorkSpace1(data, res) {
    if (data.messageType === "openRelatedWork") {
        if (data.workspaceId === 2) {
            var label; clear_all_tabs_ws1();
            _.each(res, function (item) {
                label = 'Claim ' + data.claimNumber + ' : ' + 'Work ' + item.value;
                append_new_tab_ws1(item.url, label);
            });
        }
    }
}

function performWorkSpace2(data, res) {
    if (data.messageType === "openRelatedWork") {
        if (data.workspaceId === 2) {
            var label; clear_all_tabs_ws2();
            _.each(res, function (item) {
                label = 'Claim : ' + item.value;
                append_new_tab_ws2(item.url, label);
            });
        }
    }
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