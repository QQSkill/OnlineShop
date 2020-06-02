var user = {
    init: function () {
        user.loadProvince();
        user.registerEvent();
    },
    registerEvent: function () {
        $('#ddlProvince').off('change').on('change', function () {
            var id = $(this).val();
            if (id != '') {
                user.loadDistrict(parseInt(id));
            }
            else {
                $('#ddlDistrict').html('');
            }
        });
    },
    loadProvince: function () {
        $.ajax({
            url: '/User/LoadProvince',
            type: "POST",
            dataType: "json",
            success: function(response)
            {
                if(response.status == true)
                {
                    var data = response.data;
                    var html = '<option value=""> -- Chọn tỉnh/thành--</option>';
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID  + '">' + item.Name + '</option>'
                    });
                    $('#ddlProvince').html(html);
                }
            }
        })
    },
    loadDistrict: function (id) {
        $.ajax({
            url: '/User/LoadDistrict',
            type: "POST",
            data: { provinceId: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    var html = '<option value=""> -- Chọn quận/huyện--</option>';
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID + '">' + item.Name + '</option>'
                    });
                    $('#ddlDistrict').html(html);
                }
            }
        })
    }
}
user.init();