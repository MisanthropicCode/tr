function highlightWords(tagName) {
    var words = $(tagName).hover(function (eventObject) {
        $(this).addClass("lighted");
    }).mouseout(function () {
        $(this).removeClass("lighted");
    });
}