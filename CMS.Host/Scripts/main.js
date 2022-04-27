$(document).ready(function () {
    // Enable Live Search.  
    $('#SubjectList').attr('data-live-search', true);

    //// Enable multiple select.  
    $('#SubjectList').attr('multiple', true);
    $('#SubjectList').attr('data-selected-text-format', 'count');

    $('.selectSubject').selectpicker(
        {
            width: 'auto',
            title: 'Choose Multiple Subjects',
            style: 'btn-default',
            size: 6,
            iconBase: 'fa',
            tickIcon: 'fa-check'
        });
});

$(document).ready(function () {
    // Enable Live Search.  
    $('#CourseList').attr('data-live-search', true);

    //// Enable multiple select.  
    $('#CourseList').attr('multiple', false);
    $('#CourseList').attr('data-selected-text-format', 'count');

    $('.selectCourse').selectpicker(
        {
            width: 'auto',
            title: 'Choose Courses',
            style: 'btn-default',
            size: 6,
            iconBase: 'fa',
            tickIcon: 'fa-check'
        });
});