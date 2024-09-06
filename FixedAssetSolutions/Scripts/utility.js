/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

// ********  All Helper Functions ************ //

/**
 * Returns response messages
 * @param {string} statusCode
 * @param {string} msg
 * @param {object} data
 * @returns {object} jsonResp
 */
function responseMessage(statusCode, msg, data) {
    var jsonResp = {
        ajaxStatus: statusCode,
        ajaxMessage: msg,
        ajaxData: data
    };
    return jsonResp;
}

/**
 * repeat
 * Reuseable function that will make ajax request 
 * @param (object) reqData
 * @param (function) callback
 * @return (object)  
 */
function callAjax(reqData, callback) {
    $.ajax({
        url: reqData.url,
        type: reqData.type,
        headers: reqData.headers,
        contentType: reqData.content,
        //contentType: 'multipart/form-data',
        data: reqData.data,
        success: function (responseData) {
            return callback(responseData);
        },
        error: function (err) {
            return callback(responseMessage("405", "error", err));
        }
    });

}

function callAjaxOnFileData(reqData, callback) {
    $.ajax({
        url: reqData.url,
        type: reqData.type,
        headers: reqData.headers,
        cache: false,
        contentType: false,
        processData: false,
        data: reqData.data,
        success: function (responseData) {
            return callback(responseMessage(responseData.meta.status, "success", responseData));
        },
        error: function (err) {
            return callback(responseMessage("405", "error", err));
        }
    });

}

function callAjaxFileDownload(reqData, callback) {
    $.ajax({
        url: '@Url.Action("DownloadAttachment", "PostDetail")',
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        data: {
            studentId: 123
        },
        type: "GET",
        success: function () {
            window.location = '@Url.Action("DownloadAttachment", "PostDetail", new { studentId = 123 })';
        }
    });
}

function count(array, value) {
    var counter = 0;
    for (var i = 0; i < array.length; i++) {
        if (array[i]['Depreciated'] === value) counter++;
    }
    return counter;
}

function countValue(array) {
    var amount = 0;
    for (var i = 0; i < array.length; i++) {
        amount = parseInt(array[i]['NetbookValue']) + amount;
    }
    return amount;
}