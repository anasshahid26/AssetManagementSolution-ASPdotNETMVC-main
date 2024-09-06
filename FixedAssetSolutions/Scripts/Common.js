function GetHierarchy(formData1) {
    console.log(formData1);
    getL2Location(formData1, function (response) {
        $.each(response.data, function (key, value) {
            $("#AssetSection").append($("<option></option>").val(value.L2LocCode).html(value.L2LocName));
        });
        $("#AssetSection").unbind().change(function () {
            $('#AssetRoomNo').find('option').remove().end().append('<option value="">SELECT ROOM NUMBER</option>');
            $('#AssetFloor').find('option').remove().end().append('<option value="">SELECT FLOOR</option>');
            var sid = $(this).val();
            console.log(formData1.data['L1LocCode']);
            var form = {
                "L2LocCode": sid,
                "L1LocCode": formData1.data['L1LocCode']
            };
            var formData = {
                type: "POST",
                data: form
            };
            getL5Location(formData, function (response) {
                $.each(response.data, function (key, value) {
                    $("#AssetFloor").append($("<option></option>").val(value.CODELEVEL).html(value.CODELEVEL));
                });
                $("#AssetFloor").unbind().change(function () {
                    $('#AssetRoomNo').find('option').remove().end().append('<option value="">SELECT ROOM NUMBER</option>');
                    var rid = $(this).val();
                    var form = {
                        "CODELEVEL": rid,
                        "L2LocCode": sid,
                        "L1LocCode": formData1.data['L1LocCode']
                    };
                    var formData = {
                        type: "POST",
                        data: form
                    };
                    getL3Location(formData, function (response) {
                        console.log(response);
                        $.each(response.data, function (key, value) {
                            var form = {
                                "L3LocCode": value.L3LocCode,
                                "L1LocCode": formData1.data['L1LocCode']
                            };
                            var formData = {
                                type: "POST",
                                data: form
                            };
                            isL3LocationAvailable(formData, function (response) {
                                console.log(response);
                                if (response.message === "Room not Reverified") {
                                    $("#AssetRoomNo").append($("<option></option>").val(value.L3LocCode).html(value.L3LocName));
                                }
                            });
                        });
                        $("#AssetRoomNo").unbind().change(function () {
                            var Code = $(this).val();
                            var form = {
                                "L2LocCode": sid,
                                "L3LocCode": Code,
                                "L1LocCode": formData1.data['L1LocCode']
                            };
                            var formData = {
                                type: "POST",
                                data: form
                            };
                            getL4Location(formData, function (response) {
                                console.log(response.data[0]['L4LocCode']);
                                $('#TYPECODE').val(response.data[0]['L4LocCode']);
                            });
                        });
                    });
                });
            });
        });
    });
}



function GetHierarchyWRTSection(formData1) {
    console.log(formData1);
    getL2Location(formData1, function (response) {
        $.each(response.data, function (key, value) {
            $("#AssetSection").append($("<option></option>").val(value.L2LocCode).html(value.L2LocName));
        });
        $("#AssetSection").unbind().change(function () {
            $('#AssetRoomNo').find('option').remove().end().append('<option value="">SELECT ROOM NUMBER</option>');
            $('#AssetFloor').find('option').remove().end().append('<option value="">SELECT FLOOR</option>');
            var sid = $(this).val();
            console.log(formData1.data['L1LocCode']);
            var form = {
                "L2LocCode": sid,
                "L1LocCode": formData1.data['L1LocCode']
            };
            var formData = {
                type: "POST",
                data: form
            };
            getL3Location(formData, function (response) {
                $.each(response.data, function (key, value) {
                    var form = {
                        "L3LocCode": value.L3LocCode,
                        "L1LocCode": formData1.data['L1LocCode']
                    };
                    var formData = {
                        type: "POST",
                        data: form
                    };
                    isL3LocationAvailable(formData, function (response) {
                        //if (response.message === "Room not Reverified") {
                            $("#AssetRoomNo").append($("<option></option>").val(value.L3LocCode).html(value.L3LocName));
                        //}
                    });
                });
                $("#AssetRoomNo").unbind().change(function () {
                    var Code = $(this).val();
                    var form = {
                        "L2LocCode": sid,
                        "L3LocCode": Code,
                        "L1LocCode": formData1.data['L1LocCode']
                    };
                    var formData = {
                        type: "POST",
                        data: form
                    };
                    getL4Location(formData, function (response) {
                        console.log(response.data[0]['L4LocCode']);
                        $('#TYPECODE').val(response.data[0]['L4LocCode']);
                    });
                });
            });
        });
    });
}