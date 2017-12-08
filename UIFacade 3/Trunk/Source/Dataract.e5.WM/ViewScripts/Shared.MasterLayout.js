var orientation = 0, collapsed = 0, workspace = 0; workspace1Home = 0, workspace2Home = 0, debug = 0;

var jqxTabsLeftArray = [];

$(document).ready(function () {
    var serviceCall = function (postData) {
        $.ajax({
            url: '/Services/Api',
            type: 'POST',
            dataType: 'json',
            data: { "data": JSON.stringify(postData) },
            success: function (response) {
                if (debug === 1) alert(JSON.stringify(response));
            },
            error: function (response) {
                alert('Server Post Error : ' + JSON.stringify(response));
            }
        });

        return {
            message: "Message Received & Dispatched...",
            result: 1
        };
    };

    $.pm.bind("dataract-message", function (postData) {
        if (debug === 1) alert(JSON.stringify(postData));

        if (checkMessageForAnyClientSideEvents(postData) === true) {
            $.ajax({
                url: '/Services/Api',
                type: 'POST',
                dataType: 'json',
                data: { "data": JSON.stringify(postData) },
                success: function (response) {
                    if (debug === 1) alert(JSON.stringify(response));
                    process(response);
                },
                error: function (response) {
                    alert('Server Post Error : ' + JSON.stringify(response));
                }
            });
        }

        return {
            message: "Message Received & Dispatched...",
            result: 1
        };
    });
    
    function checkMessageForAnyClientSideEvents(postData) {
        switch (postData.messageCode) {
            case "closeSingleWork":
                {
                    var selectedItem = $('#jqxTabsLeft').jqxTabs('selectedItem');
                    $('#jqxTabsLeft').jqxTabs('removeAt', selectedItem);
                    return false;
                    break;
                }
            default:
                {
                    return true;
                    break;
                }
        }
    }

    $('#mainSplitter').jqxSplitter({ width: '100%', height: 'calc(100% - 40px)', orientation: 'vertical', panels: [{ size: '50%', collapsible: false }, { size: '50%', collapsible: false }] });

    $('#leftSplitter').jqxSplitter({ width: '100%', height: '100%', orientation: 'horizontal', panels: [{ size: '80%', collapsible: false }, { size: '20%', collapsible: false }] });
    //$('#rightSplitter').jqxSplitter({ width: '100%', height: '100%', orientation: 'horizontal', panels: [{ size: '80%', collapsible: false }, { size: '20%', min: '20%', collapsible: false }] });

    $('#jqxTabsLeft').jqxTabs({ position: 'top', width: '100%', height: '100%', showCloseButtons: true, scrollPosition: 'both' });
    //$('#jqxTabsLeftBottom').jqxTabs({ position: 'top', width: '100%', height: '100%', scrollPosition: 'both' });

    $('#jqxTabsRight').jqxTabs({ position: 'top', width: '100%', height: '100%', showCloseButtons: true, scrollPosition: 'both' });
    //$('#jqxTabsRightBottom').jqxTabs({ position: 'top', width: '100%', height: '100%', scrollPosition: 'both' });

    $('#jqxTabsLeft').jqxTabs('hideCloseButtonAt', 0);
    
    $('#jqxTabsRight').jqxTabs('hideCloseButtonAt', 0);

    $('#WSNormal').click(function () {
        workspace1And2();
    });
    
    $('#WS1Only').click(function () {
        workspace1Only();
    });
    
    $('#WS2Only').click(function () {
        workspace2Only();
    });

    $('#WSVerticalSplit').click(function () {
        drawVerticalLayout();
    });
    
    $('#WSHorizontalSplit').click(function () {
        drawHorizontalLayout();
    });
    
    $('#WorkspaceLabel').click(function () {
        switch(workspace) {
            case 0:
                {
                    workspace1Only();
                    break;
                }
            case 1:
                {
                    workspace2Only();
                    break;
                }
            case 2:
                {
                    workspace1And2();
                    break;
                }
        }
    });
    
    $('#jqxTabsLeft').on('removed', function (event) {
        var removedItem = (event.args.item) - 1;
        var tabKey = jqxTabsLeftArray.splice(removedItem, 1)[0];

        serviceCall({
            messageCode: "unlockwork",
            workspaceId: 1,
            workId: tabKey
        });
        
        if (debug === 1) {
            alert(tabKey);
            alert(jqxTabsLeftArray.toString());
        }
    });
    
    $('#jqxTabsLeft').on('add', function (event) {
        if (debug === 1) {
            alert('Tab Added To : #jqxTabsLeft');
        }
    });
    
    $('#jqxTabsLeft').on('tabclick', function (event) {
        var clickedItem = event.args.item;

        if (clickedItem === 0) {
            var homeUrl = $('#WS1HomeFrame').attr('data');
            if (homeUrl) {
                $('#WS1HomeFrame').attr('src', homeUrl);
            }
        }
    });
    
    $('#jqxTabsRight').on('tabclick', function (event) {
        var clickedItem = event.args.item;

        if (clickedItem === 0) {
            var homeUrl = $('#WS2HomeFrame').attr('data');
            if (homeUrl) {
                $('#WS2HomeFrame').attr('src', homeUrl);
            }
        }
    });

    $('#Workspace1Home').click(function () {
        var homeUrl;
        
        if (workspace1Home === 0) {
            workspace1Home = 1;
            homeUrl = $("#txtWorkspace1HomeUrlAlt").val();
            $('#WS1HomeFrame').attr('src', homeUrl);
            $('#WS1HomeFrame').attr('data', homeUrl);
            $('#Workspace1Home').toggleClass('btn-success');
            $('#Workspace1Home > i').attr('class', 'icon-thumbs-up');
        } else {
            workspace1Home = 0;
            homeUrl = $("#txtWorkspace1HomeUrl").val();
            $('#WS1HomeFrame').attr('src', homeUrl);
            $('#WS1HomeFrame').attr('data', homeUrl);
            $('#Workspace1Home').toggleClass('btn-success');
            $('#Workspace1Home > i').attr('class', 'icon-thumbs-down');
        }
    });
    
    $('#Workspace2Home').click(function () {
        var homeUrl;

        if (workspace2Home === 0) {
            workspace2Home = 1;
            homeUrl = $("#txtWorkspace2HomeUrlAlt").val();
            $('#WS2HomeFrame').attr('src', homeUrl);
            $('#WS2HomeFrame').attr('data', homeUrl);
            $('#Workspace2Home').toggleClass('btn-success');
            $('#Workspace2Home > i').attr('class', 'icon-thumbs-up');
        } else {
            workspace2Home = 0;
            homeUrl = $("#txtWorkspace2HomeUrl").val();
            $('#WS2HomeFrame').attr('src', homeUrl);
            $('#WS2HomeFrame').attr('data', homeUrl);
            $('#Workspace2Home').toggleClass('btn-success');
            $('#Workspace2Home > i').attr('class', 'icon-thumbs-down');
        }
    });

    resetArrary();
});

function resetArrary() {
    jqxTabsLeftArray = [];
}

function workspace1And2() {
    if (orientation === 0) {
        $('#mainSplitter').jqxSplitter({ panels: [{ size: '50%', collapsible: false }, { size: '50%', collapsible: false }] });
        $('#rightSplitter').jqxSplitter({ panels: [{ size: '80%', collapsible: false }, { size: '20%', collapsible: false }] });
        $('#leftSplitter').jqxSplitter({ panels: [{ size: '80%', collapsible: false }, { size: '20%', collapsible: false }] });
        
        $('#mainSplitter').jqxSplitter('collapse');
    }

    if (orientation === 1) {
        drawVerticalLayout(); workspace1Only();

        $('#mainSplitter').jqxSplitter({ panels: [{ size: '50%', collapsible: false }, { size: '50%', collapsible: false }] });
        $('#rightSplitter').jqxSplitter({ panels: [{ size: '80%', collapsible: false }, { size: '20%', collapsible: false }] });
        $('#leftSplitter').jqxSplitter({ panels: [{ size: '80%', collapsible: false }, { size: '20%', collapsible: false }] });
        
        $('#mainSplitter').jqxSplitter('collapse');

        drawHorizontalLayout();
    }

    if (workspace !== 0) {
        $('#WorkspaceLabel').text('Split Workspace');

        collapsed = 0;
        workspace = 0;
    }
}

function workspace1Only() {
    if (workspace !== 1) {
        if (orientation === 0) {
            $('#mainSplitter').jqxSplitter({ panels: [{ collapsible: false }, { collapsible: true }] });
            $('#mainSplitter').jqxSplitter('collapse');
        }
        
        if (orientation === 1) {
            drawVerticalLayout();

            $('#mainSplitter').jqxSplitter({ panels: [{ collapsible: false }, { collapsible: true }] });
            $('#mainSplitter').jqxSplitter('collapse');
            
            drawHorizontalLayout();
        }

        $('#WorkspaceLabel').text('e5 Workflow');
        
        collapsed = 1;
        workspace = 1;
    }
}

function workspace2Only() {
    if (workspace !== 2) {
        if (orientation === 0) {
            $('#mainSplitter').jqxSplitter({ panels: [{ collapsible: true }, { collapsible: false }] });
            $('#mainSplitter').jqxSplitter('collapse');
        }

        if (orientation === 1) {
            drawVerticalLayout();

            $('#mainSplitter').jqxSplitter({ panels: [{ collapsible: true }, { collapsible: false }] });
            $('#mainSplitter').jqxSplitter('collapse');

            drawHorizontalLayout();
        }

        $('#WorkspaceLabel').text('Another Application');
        
        collapsed = 1;
        workspace = 2;
    }
}

function drawVerticalLayout() {
    if (orientation !== 0) {
        orientation = 0;

        $('#mainSplitter').jqxSplitter({ orientation: 'vertical' });
        $('#rightSplitter').jqxSplitter({ orientation: 'horizontal' });
        $('#leftSplitter').jqxSplitter({ orientation: 'horizontal' });

        $('#WS1Only > i').attr('class', 'icon-chevron-sign-right');
        $('#WS2Only > i').attr('class', 'icon-chevron-sign-left');
    }
}

function drawHorizontalLayout() {
    if (orientation !== 1) {
        orientation = 1;

        $('#mainSplitter').jqxSplitter({ orientation: 'horizontal' });
        $('#rightSplitter').jqxSplitter({ orientation: 'vertical' });
        $('#leftSplitter').jqxSplitter({ orientation: 'vertical' });

        $('#WS1Only > i').attr('class', 'icon-chevron-sign-down');
        $('#WS2Only > i').attr('class', 'icon-chevron-sign-up');
    }
}

function addTab_jqxTabsLeft(url, label, item) {
    var element = $('#jqxTabsLeft');

    if (!item.key) {
        $(element).jqxTabs('addAt', 1, label);
        $(element).jqxTabs('setContentAt', 1, '<iframe class="jqxTabsContentIframe" src="' + url + '" ></iframe>'); //<div class="jqxTabsHeader"></div>
        jqxTabsLeftArray.unshift(url);
    } else {
        var elementId = "#" + item.key;
        
        if ($(elementId).length === 0) {
            $(element).jqxTabs('addAt', 1, label);

            if (!item.info) {
                $(element).jqxTabs('setContentAt', 1, '<iframe id="' + item.key + '" class="jqxTabsContentIframe" src="' + url + '" ></iframe>'); //<div class="jqxTabsHeader"></div>
            } else {
                $(element).jqxTabs('setContentAt', 1, '<iframe id="' + item.key + '" info="' + item.info + '" class="jqxTabsContentIframe" src="' + url + '" ></iframe>'); //<div class="jqxTabsHeader"></div>
            }
            
            jqxTabsLeftArray.unshift(item.key);
        } else {
            alert('The work item is opend already');
        }
    }
}

function clearTabs_jqxTabsLeft() {
    var element = $('#jqxTabsLeft');

    for (var i = 0; i < 999; i++) {
        var content = $(element).jqxTabs('getContentAt', 1);
        if (content) {
            $(element).jqxTabs('removeAt', 1);
        }
    }
    
    $(element).jqxTabs('select', 0);
}

function clearTabs_jqxTabsRight() {
    var element = $('#jqxTabsRight');

    for (var i = 0; i < 999; i++) {
        var content = $(element).jqxTabs('getContentAt', 1);
        if (content) {
            $(element).jqxTabs('removeAt', 1);
        }
    }

    $(element).jqxTabs('select', 0);
}

function readUrl(textBoxId) {
    var url = $(textBoxId).val();

    if (url.substr(0, 4) !== 'http')
        url = 'http://' + url;
    
    return url;
}

function loadUrl(iframeId, url) {
    $(iframeId).attr('src', url);
}

function getUrl(iframeId) {
    var url = $(iframeId).attr('src');
    return url;
}

function process(response) {
    if (response.processWorkSpace1 === 1) {
        if (response.clearWorkSpace1HomeTabs && response.clearWorkSpace1HomeTabs === 1) {
            clearTabs_jqxTabsLeft();
        }
        
        performWorkSpace1(response);
    }

    if (response.processWorkSpace2 === 1) {
        if (response.clearWorkSpace2HomeTabs && response.clearWorkSpace2HomeTabs === 1) {
            clearTabs_jqxTabsRight();
        }
        
        performWorkSpace2(response);
    }
}

function performWorkSpace1(data) {
    _.each(data.dataWorkSpace1, function (item) {
        var paneId = item.pane, label = item.value;

        if (!paneId) paneId = 0;

        if (paneId === 0) {
            addTab_jqxTabsLeft(item.url, label, item);
        } else {
            $('#WS1HomeBottomFrame').attr('src', item.url);
        }
    });
}

function performWorkSpace2(data) {
    _.each(data.dataWorkSpace2, function (item) {
        var paneId = item.pane, label = item.value;

        if (!paneId) paneId = 0;

        if (paneId === 0) {
            $('#WS2HomeFrame').attr('src', item.url);
        }
    });
}