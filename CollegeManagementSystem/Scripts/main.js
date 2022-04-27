$(document).ready(function () {
    // Enable Live Search.  
    $('#SubjectList').attr('data-live-search', true);

    //// Enable multiple select.  
    $('#SubjectList').attr('multiple', true);
    $('#SubjectList').attr('data-selected-text-format', 'count');

    $('.selectSubject').selectpicker(
        {
            width: 'auto',
            title: '- [Choose Multiple Subjects] -',
            style: 'btn-default',
            size: 6,
            iconBase: 'fa',
            tickIcon: 'fa-check'
        });
});