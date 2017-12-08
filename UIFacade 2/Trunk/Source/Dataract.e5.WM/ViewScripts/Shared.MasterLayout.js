var orientation = 0, collapsed = 0, workspace = 0;

$(document).ready(function () {

    $.pm.bind("dataract-message", function (postData) {
        $.ajax({
            url: '/Services/Api',
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

    $('#mainSplitter').jqxSplitter({ width: '100%', height: 'calc(100% - 40px)', orientation: 'vertical', panels: [{ size: '50%', collapsible: false }, { size: '50%', collapsible: false }] });

    $('#rightSplitter').jqxSplitter({ width: '100%', height: '100%', orientation: 'horizontal', panels: [{ size: '80%', collapsible: false }, { size: '20%', min: '20%', collapsible: false }] });
    $('#leftSplitter').jqxSplitter({ width: '100%', height: '100%', orientation: 'horizontal', panels: [{ size: '80%', collapsible: false }, { size: '20%', min: '20%', collapsible: false }] });

    $('#jqxTabsLeft').jqxTabs({ position: 'top', width: '100%', height: '100%', scrollPosition: 'both' });
    $('#jqxTabsLeftBottom').jqxTabs({ position: 'top', width: '100%', height: '100%', scrollPosition: 'both' });

    $('#jqxTabsRight').jqxTabs({ position: 'top', width: '100%', height: '100%', scrollPosition: 'both' });
    $('#jqxTabsRightBottom').jqxTabs({ position: 'top', width: '100%', height: '100%', scrollPosition: 'both' });

    $('#jqxTabsLeft, #jqxTabsRight, jqxTabsLeftBottom, jqxTabsRightBottom').on('selecting', function (event) {
        return false;
    });


    $('#WS1Home').click(function () {
        var url = readUrl('#WS1HomeURL');
        loadUrl('#WS1HomeFrame', url);
    });

    $('#WS2Home').click(function () {
        var url = readUrl('#WS2HomeURL');
        loadUrl('#WS2HomeFrame', url);
    });

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
    
    $(document).on('click', 'i.icon-remove-sign', function () { //"#panel-left--top-tabstrip li:last span"
        alert('clicked');
    });

});

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


function addTab(jqxTabsId, url, label, item) {
    $(jqxTabsId).jqxTabs('addAt', 1, label);
    $(jqxTabsId).jqxTabs('setContentAt', 1, '<div class="jqxTabsHeader"><a class="btn btn-sm" href="#"><i class="icon-remove-sign"></i></a></div><iframe class="jqxTabsContentIframe" src="' + url + '" ></iframe>');
}

function clearTabs(jqxTabsId) {
    for (var i = 0; i < 999; i++) {
        $(jqxTabsId).jqxTabs('removeAt', 1);
    }
    
    $(jqxTabsId).jqxTabs('select', 0);
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
        performWorkSpace1(response.dataWorkSpace1);
    }

    if (response.processWorkSpace2 === 1) {
        performWorkSpace2(response.dataWorkSpace2);
    }
}

function performWorkSpace1(data) {
    clearTabs('#jqxTabsLeft');
    clearTabs('#jqxTabsLeftBottom');
    
    _.each(data, function (item) {
        var label = item.value;
        var paneId = item.pane;

        if (!paneId) paneId = 0;

        if (paneId === 0) {
            addTab('#jqxTabsLeft', item.url, label, item);
        } else if (paneId === 1) {
            addTab('#jqxTabsLeftBottom', item.url, label, item);
        }
    });
}

function performWorkSpace2(data) {
    clearTabs('#jqxTabsRight');
    clearTabs('#jqxTabsRightBottom');
    
    _.each(data, function (item) {
        var label = item.value;
        var paneId = item.pane;

        if (!paneId) paneId = 0;

        if (paneId === 0) {
            addTab('#jqxTabsRight', item.url, label, item);
        } else if (paneId === 1) {
            addTab('#jqxTabsRightBottom', item.url, label, item);
        }
    });
}