$(document).ready(function () {
    $(document).on("click", "#deleteCategory", function (e) {
        e.preventDefault();
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr("href");
                fetch(url).then(response => {
                    if (response.ok) {
                        Swal.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        )
                    }

                    return response.text();
                }).then(data => {
                    $(".dataTable").html(data);
                })
            }
        })

    })

    $(document).on("click", "#restoreCategory", function (e) {
        e.preventDefault();
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Restore it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr("href");
                fetch(url).then(response => {
                    if (response.ok) {
                        Swal.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        )
                    }

                    return response.text();
                }).then(data => {
                    $(".dataTable").html(data);
                })
            }
        })

    })

    $(document).on("click", "#deleteImage", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => { return response.text() }).then(data => { $(".productupdate").html(data) });
    })
})