var contact = {
    init: function()
    {
        contact.registerEvents();
    },
    registerEvents: function()
    {
        $('#btnSend').off('click').on('click', function()
        {
            var name = $('#txtName').val();
            var mobile = $('#txtMobile').val();
            var address = $('#txtAddress').val();
            var email = $('#txtEmail').val();
            var content = $('#txtContent').val();

            $.ajax({
                url: 'Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    mobile: mobile,
                    adddress: address,
                    email: email,
                    content: content
                },
                success: function (res) {
                    if(res.status == true)
                    {
                        window.alert('Gửi thành công!');
                    }
                }
            })
        })
    }
}
contact.init();