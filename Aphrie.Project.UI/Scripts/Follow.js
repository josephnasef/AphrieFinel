$(".toggle").click(function (e) {

    var Id = $(this).attr("data-Id");
    var ele = $(this);
    e.preventDefault();
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Home/toggleFriendReq/",
        data: JSON.stringify({ Id: Id }),
        success: function () {
            $(ele).first('#we').text() == " follow " ? $(ele).first('#we').text(" Unfollow ") : $(ele).first('#we').text(" follow ");
            $(ele).first('#we').toggleClass("fa-heart-o fa-heart");
        },
        Error: function () {
            alert("no");
        }
    });
});