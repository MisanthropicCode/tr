function wrapAllWords(containerId) {
    var text = $(containerId).text();
    text = text.replace(/\w+/g, "<word>$&</word>");
    text = text.replace(/\n/g, "<br />");
    $(containerId).html(text);
}