$(document).ready(function () {
    
    $('#WS1Home').click(function () {
        loadUrl('#WorkSpace1', 'http://localhost:52784/WS1/Index');
    });

    $('#WS2Home').click(function () {
        loadUrl('#WorkSpace2', 'http://localhost:52785/WS2/Index');
    });

    /*
    $('#WorkSpace1').load(function () {
        var url1 = $('#WorkSpace1').attr('src');
        var url2 = $('#WorkSpace2').attr('src');

        if(url1 !== url2)
            $('#WorkSpace2').attr('src', url1);
    });

    $('#WorkSpace2').load(function () {
        var url1 = $('#WorkSpace1').attr('src');
        var url2 = $('#WorkSpace2').attr('src');

        if (url1 !== url2)
             $('#WorkSpace1').attr('src', url2);
    });
    */
});


function actionPerformed(workspaceId, itemId, itemData, itemAdditionalData) {
    switch (workspaceId) {
        case 1:
            {
                redirectActionToWorkspace2(itemId, itemData, itemAdditionalData);
                break;
            }
        case 2:
            {
                redirectActionToWorkspace1(itemId, itemData, itemAdditionalData);
                break;
            }
    }
}


function redirectActionToWorkspace1(itemId, itemData, itemAdditionalData) {
    switch(itemId) {
        case 99:
            {
                if (itemData)
                {
                    alert('Opening URL Workspace 1 : ' + itemData);

                    $('#ws1-leftmenu').append('<a href="#" onclick="loadUrl(' + "'#WorkSpace1', '" + itemData + "')" + '">' + itemAdditionalData + '</a><br />');

                    loadUrl('#WorkSpace1', itemData);
                }
                else
                {
                    alert('Item Id : 99 - Browse To URL ( URL is not passed )');
                }
                
                break;
            }
        default:
            {
                alert('Unknown Item');
                break;
            }
    }
}

function redirectActionToWorkspace2(itemId, itemData, itemAdditionalData) {
    switch (itemId) {
        case 99:
            {
                if (itemData)
                {
                    alert('Opening URL Workspace 2 : ' + itemData);
                    
                    $('#ws2-leftmenu').append('<a href="#" onclick="loadUrl(' + "'#WorkSpace2', '" + itemData + "')" + '">' + itemAdditionalData + '</a><br />');

                    loadUrl('#WorkSpace2', itemData);
                }
                else
                {
                    alert('Item Id : 99 - Browse To URL ( URL is not passed )');
                }

                break;
            }
        default:
            {
                alert('Unknown Item');
                break;
            }
    }
}

function loadUrl(iframeId, url) {
    $(iframeId).attr('src', url);
}

function getUrl(iframeId) {
    var url = $(iframeId).attr('src');

    alert(url);
}