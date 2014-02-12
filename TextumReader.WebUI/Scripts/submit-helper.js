function submitFormAutomatically () {
    $("#category").change(function () {
        document.forms["catform"].submit();
    });
}