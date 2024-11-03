//document.addEventListener('DOMContentLoaded', () => {
//    const seats = document.querySelectorAll('.seat.available');

//    seats.forEach(seat => {
//        seat.addEventListener('click', () => {
//            if (!seat.classList.contains('booked')) {
//                seat.classList.toggle('selected'); // Toggle selected class
//                alert(`Anda telah memilih kursi ${seat.dataset.seat}`);
//            }
//        });
//    });
//});

$(document).ready(function () {
    let status = true;

    const now = new Date();
    const startTime = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0);
    const endTime = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 5, 0, 0);

    countdown();
    console.log(status);
    if (status == true) {
        fetchSeats()
    }

    function countdown() {
        if (now >= startTime && now < endTime) {

            $.ajax({
                url: $("#web_link").val() + "/WFHReserveAPI/Booking/Get_Time",
                method: "GET",
                success: function (response) {
                    const countDownDate = new Date(response.targetTime).getTime();

                    const x = setInterval(function () {
                        const now = new Date().getTime();
                        const distance = countDownDate - now;

                        const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                        const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                        const seconds = Math.floor((distance % (1000 * 60)) / 1000);

                        document.getElementById("countdown").innerHTML = hours + "h "
                            + minutes + "m " + seconds + "s ";

                        if (distance < 0) {
                            clearInterval(x);
                            document.getElementById("countdown").innerHTML = "Waktu Habis!";
                            status = false;

                            //$(".seat").each(function () {
                            //    $(this).css({
                            //        "pointer-events": "none",
                            //        "opacity": "0.2",
                            //        "background-color": "grey"
                            //    });
                            //});
                        } else {
                            status = true;
                        }

                    }, 1000);
                },
                error: function (error) {
                    document.getElementById("countdown").innerHTML = "Gagal memuat waktu target.";
                    console.error("Error fetching target time:", error);
                    status = false;
                }
            });
        } else {

            document.getElementById("countdown").innerHTML = "Countdown hanya tersedia antara pukul 6:00 hingga 7:00 pagi.";
            status = false;
        };
    }

    function fetchSeats() {
        $.ajax({
            url: $("#web_link").val() + "/WFHReserveAPI/Booking/Get_Seat",
            type: 'GET',
            success: function (data) {
                data.forEach(function (seat) {
                    const seatStyle = seat.Avail == 0 ? 'opacity: 0.2; background-color: grey;' : '';
                    const seatElement = `
                    <a class="btn btn-alt-primary seat" style="${seatStyle}" data-available="${seat.Avail}" data-seat-number="${seat.Number}">
                        <i class="fa fa-chair"></i>
                        <br /><b>${seat.Number}</b>
                    </a>`;

                    if (seat.Type === "A") {
                        $('#seatContainerA').append(seatElement);
                    } else if (seat.Type === "B") {
                        $('#seatContainerB').append(seatElement);
                    }
                });
            },
            error: function (xhr, status, error) {
                console.error('Error fetching seats:', error);
            }
        });


        $(document).on('click', '.seat', function () {
            const available = $(this).data('available');
            const seatNumber = $(this).data('seat-number');

            if (available == 1) {
                $('#txt_seat').val(seatNumber);
                $('#txt_nrp').val($('#nrp_login').val());

                $.ajax({
                    url: $("#web_link2").val() + "/EmployeeAPI/Employee/Get_Employee?nrp=" + $('#nrp_login').val(),
                    type: 'GET',
                    success: function (emp) {
                        //console.log(emp.Data)
                        $('#txt_name').val(emp.Data.nama);
                        $('#modal_booked').modal('show');
                    },
                    error: function (xhr, status, error) {
                        console.error('Error fetching pemesan data:', error);
                        alert('Gagal memuat data pemesan. Silakan coba lagi.');
                    }
                });
            } else {
                alert(`Kursi ${seatNumber} tidak tersedia!`);
            }
        });
    }

    
});

function Booked() {
    var ListBooked = [];
    ListBooked.length = 0;

    ListBooked.push({
        nrp: $("#txt_nrp").val(),
        no_seat: $("#text_seat").val()
    });

    $.ajax({
        url: $("#web_link").val() + "/EmployeeAPI/Employee/BookingSeat", //URI
        data: JSON.stringify(ListBooked),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.Remarks == true) {
                $('#modal_booked').modal('hide');
                tableRepair.ajax.reload();
            } if (data.Remarks == false) {
                Swal.fire(
                    'Error!',
                    'Message : ' + data.Message,
                    'error'
                );
            }

        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    })
}
