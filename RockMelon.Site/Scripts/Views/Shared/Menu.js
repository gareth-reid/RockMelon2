function showMenu(id) {
    $('#SelectedMenuId').val(id);
    $('div[id^="node-"]').hide();
    $('#node-' + id).show();
}

$(document).ready(function () {
    showMenu($('#SelectedMenuId').val());
});