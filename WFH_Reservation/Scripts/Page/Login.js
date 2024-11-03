var e = Swal.mixin({ buttonsStyling: !1, customClass: { confirmButton: "btn btn-alt-success m-5", cancelButton: "btn btn-alt-danger m-5", input: "form-control" } });
//addJobsite();

function PostLogin() {
    var obj = new Object();
    obj.nrp = $("#login-username").val();
    obj.password = $("#login-password").val();
    $.ajax({
        url: $("#web_link").val() + "/WFHReserveAPI/Login/Get_Login", //URI
        data: JSON.stringify(obj),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $("#overlay").show();
        },
        success: function (data) {
            if (data.Remarks == true) {
                MakeSession(obj.nrp);
            }
            else {
                swal.fire({
                    title: "Error!",
                    text: "Username or Password incorrect.",
                    icon: 'error',
                });
                $("#overlay").hide();
            }

        },
        error: function (xhr) {
            swal.fire({
                title: "Error!",
                text: 'Message : ' + xhr.responseText,
                icon: 'error',
            });
        }
    })
}

function MakeSession(nrp) {
    //debugger
    var obj = {
        nrp: nrp
    };

    $.ajax({
        type: "POST",
        url: "/Login/MakeSession", //URI
        dataType: "json",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.Remarks == true) {
                window.location.href = "/Home/index";
            }
            else {
                swal.fire({
                    title: "Error!",
                    text: data.Message,
                    icon: 'error',
                });
                $("#overlay").hide();
            }
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}