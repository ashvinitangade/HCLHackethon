$(document).ready(function () {
    $('#myTable').dataTable({
    });
    $("#txtDate").datepicker();

    $("#btnTournament").on("click", "", function () {
        alert('test');
    });
});