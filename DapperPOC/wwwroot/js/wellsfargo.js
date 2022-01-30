
$(document).ready(function () {
    var str = $('.dv-text-trade').text().split(" ");
    $('.dv-text-trade').empty();
    str.forEach(function (a) {
        $('.dv-text-trade').append('&nbsp;<span>' + a.slice(0, 1) + '</span>' + a.slice(1))
    })
})