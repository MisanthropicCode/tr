function setDialog(urlToAction, dialogId, tagName) {
    $(dialogId).dialog({
        autoOpen: false,
        resizable: false,
        width: 200,
        height: 200
    });

    $(tagName).click(function (e) {
     
        //var offset = $(this).offset();

        var selectedWord = $(this).text();
        
        $.post(urlToAction, { word: selectedWord }, function (data) {
            $(dialogId).html(data.Translation);
            
            var x = e.pageX - $(document).scrollLeft();
            var y = e.pageY - $(document).scrollTop();

            $(dialogId).dialog("option", { position: [x - 100, y + 14] });

            if (data.WordName.length <= selectedWord.length) {
                $(dialogId).dialog("option", "title", data.WordName).dialog("open");
            } else {
                $(dialogId).dialog("option", "title", selectedWord).dialog("open");
            }
        });
    });
}