var tabStripWs1;
var tabStripWs2;

$(document).ready(function () {
    var setSize = function () {
        var panes = $("#Horizontal").children();
        var pane = panes[0];

        alert('Found');

        $("#Horizontal").kendoSplitter().data("kendoSplitter").size(pane, '200px');
        
        //$("#Horizontal").data("kendoSplitter").size(pane, '200px');
    };
    
    tabStripWs1 = $('#panel-left--top-tabstrip').kendoTabStrip().data('kendoTabStrip');
    tabStripWs2 = $('#panel-right--top-tabstrip').kendoTabStrip().data('kendoTabStrip');

    $(document).on('click', 'li.k-item span img', function () { //"#panel-left--top-tabstrip li:last span"
        var space = $(this).attr("space"), tab;
        
        if (space === "ws1") {
            tab = tabStripWs1.select();
            tabStripWs1.remove(tab);
            
            //tab = tabStripWs1.tabGroup.children("li").eq(0);
            //tabStripWs1.select(tab);
        } else if (space === "ws2") {
            tab = tabStripWs2.select();
            tabStripWs2.remove(tab);
            
            //tab = tabStripWs2.tabGroup.children("li").eq(0);
            //tabStripWs2.select(tab);
        }

        return false;
    });

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

    $.pm.bind("dataract-message", function (postData) {
        $.ajax({
            url: '/Services/Api', //     /WorkSpaceSpike/Services/Api
            type: 'POST',
            dataType: 'json',
            data: { "data": JSON.stringify(postData) },
            success: function (response) {
                process(response);
            },
            error: function (response) {
                alert('Server Post Error : ' + JSON.stringify(response));
            }
        });

        return {
            message: "Message Received & Dispatched...",
            result: 1
        };
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
        append_new_tab_ws1(item.url, label, item);
    });
}

function performWorkSpace2(data) {
    var label; clear_all_tabs_ws2();
    _.each(data, function (item) {
        label = item.value;
        append_new_tab_ws2(item.url, label, item);
    });
}

function clear_all_tabs_ws1() {
    var tab;

    for (var i = 0; i < 999; i++) {
        tab = tabStripWs1.tabGroup.children("li").eq(1);
        var div = $(tab).attr("aria-controls");
        if (div) {
            var iframe = $('#' + div + ' iframe'), src = $(iframe).attr("src"), data = $(iframe).attr("data"), workId = $(iframe).attr("work_id");

            if (data) {
                if (!src) {
             
                    if (workId !== 'undefined') {
                        $.ajax({
                            url: '/Services/Api',
                            type: 'POST',
                            dataType: 'json',
                            data: {
                                "data": JSON.stringify({
                                    messageCode: "unlockWork",
                                    workspaceId: 0,
                                    workId: workId
                                })
                            },
                            error: function (response) {
                                alert('Server Post Error : ' + JSON.stringify(response));
                            }
                        });
                    }

                }
            }
        }

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

function append_new_tab_ws1(url, label, data) {
    tabStripWs1.append({
        text: label,
        content: '<iframe class="workspace-iframe" data="' + url + '" work_id="' + data.work_id + '" ></iframe>'
    });

    $("#panel-left--top-tabstrip li:last span").append('<img src="../Images/close_12.png" class="close-tab" space="ws1" />');
}

function append_new_tab_ws2(url, label, data) {
    tabStripWs2.append({
        text: label,
        content: '<iframe class="workspace-iframe" data="' + url + '" ></iframe>'
    });

    $("#panel-right--top-tabstrip li:last span").append('<img src="../Images/close_12.png" class="close-tab" space="ws2" />');
}

function loadUrl(iframeId, url) {
    alert(url);
    $(iframeId).attr('src', url);
}

function getUrl(iframeId) {
    var url = $(iframeId).attr('src');
    alert(url);
}