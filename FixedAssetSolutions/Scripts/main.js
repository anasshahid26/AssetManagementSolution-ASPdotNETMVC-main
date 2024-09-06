// **********************  ALL REUSEABLE FUNCTIONS ******************* //


// ********  All Functions related to Company ************ //

// ********  Get All Company ************ //
function getCompany(callback) {

    var requetUrl = baseUrl.apiServer.concat(api.Company.view);

    var reqData = {
        url: requetUrl,
        type: "Get"
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Get User Company ************ //

function GetUserLog(formData, callback) {


    var requestUrl = baseUrl.apiServer.concat(api.User.userLog);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Image Upload ************ //

function UploadImage(formData, callback) {

    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(app.Upload.uploadImages);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function FileUpload(formData, callback) {

    console.log(formData);
    var requestUrl = baseUrl.appServer.concat(app.AssetAddition.FileUpload);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjaxOnFileData(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Image Upload ************ //

//function Export(formData,callback) {
//    var requestUrl = baseUrl.appServer.concat(app.Export.exportExcel);
//    var reqData = {
//        url: requestUrl,
//        type: formData.type,
//        headers: null,
//        data: formData.data
//    };
//    var respData = {
//        message: "",
//        data: "null"
//    };

//    //  calling callAjax function 
//    callAjaxFileDownload(reqData, function (resp) {

//        respData = {
//            message: resp.Message,
//            data: resp.Data
//        };
//        return callback(respData);
//    });
//}

// ********  Image Upload ************ //

function SupplierAddition(formData, callback) {

    console.log(formData);
    var requestUrl = api.AssetAddition.SupplierAddition;
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function PurchaseDetail(formData, callback) {

    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.PurchaseDetails);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Image Upload ************ //

function ExportSearch(formData, callback) {

    console.log(formData);
    var requestUrl = baseUrl.appServer.concat(app.ExportSearch.exportExcel);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}


// ********  Get User Company ************ //

function ChangePassword(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.changePassword);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Get User Company ************ //

function getCompanyUser(formData, callback) {


    var requestUrl = baseUrl.apiServer.concat(api.Company.get);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Get All Location ************ //
function getLocationAdmin(callback) {

    var requetUrl = baseUrl.apiServer.concat(api.AssetSearch.adminLocation);

    var reqData = {
        url: requetUrl,
        type: "Get"
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Add Company ************ //

function addCompany(formData, callback) {


    var requestUrl = baseUrl.apiServer.concat(api.Company.add);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Edit Company ************ //

function EditCompany(formData, callback) {


    var requestUrl = baseUrl.apiServer.concat(api.Company.edit);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}


// ********  Update Company ************ //

function UpdateCompany(formData, callback) {

    var requestUrl = baseUrl.apiServer.concat(api.Company.update);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Delete Company ************ //

function DeleteCompany(formData, callback) {


    var requestUrl = baseUrl.apiServer.concat(api.Company.del);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}


// *********** AssetTagging ********* //

function AssetTagging(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetTagging.AssetTagging);
    console.log(requestUrl + "tag");
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };
    //  calling callAjax function 
    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}





// ********  Delete Company ************ //

function AssetAddition(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.Addition);
    console.log(requestUrl+"anas");
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };
    //  calling callAjax function 
    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Delete Company ************ //

function L3CategoryAddition(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.addL3Category);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };
    //  calling callAjax function 
    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Delete Company ************ //

function IsL3CategoryExist(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.IsL3CategoryExist);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };
    //  calling callAjax function 
    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Delete Company ************ //

function supplierAddition(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.supplierAddition);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };
    //  calling callAjax function 
    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Is Company Code Exsist ************ //

function IsCompanyCodeExsist(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Company.codeExsist);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Get Locations  ************ //

function getLocations(formData, callback) {


    var requestUrl = baseUrl.apiServer.concat(api.Location.view);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Add Locations ************ //

function addLocation(formData, callback) {

    var requestUrl = baseUrl.apiServer.concat(api.Location.add);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Edit Locations ************ //

function EditLocation(formData, callback) {

    var requestUrl = baseUrl.apiServer.concat(api.Location.edit);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Update Locations ************ //

function UpdateLocation(formData, callback) {
    console.log(formData);

    var requestUrl = baseUrl.apiServer.concat(api.Location.update);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
// ********  Delete Locations ************ //

function DeleteLocation(formData, callback) {

    var requestUrl = baseUrl.apiServer.concat(api.Location.del);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  All Functions related to FAS ************ //

function getAllCountries(callback) {

    var requetUrl = baseUrl.apiServer.concat(api.Company.getAllCountries);

    var reqData = {
        url: requetUrl,
        type: "Get"
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });

}

function addUser(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.add);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  All Functions related to FAS ************ //

function GetUser(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.view);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  All Functions related to FAS ************ //

function EditUser(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.edit);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  All Functions related to FAS ************ //

function UpdateUser(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.update);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function getAllPermission(callback) {

    var requetUrl = baseUrl.apiServer.concat(api.User.permssions);
    console.log(requetUrl);
    var reqData = {
        url: requetUrl,
        type: "Get"
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Is Location Code Exsist ************ //

function IsLocationCodeExsist(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Location.codeExsist);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Is Location Code Exsist ************ //

function IsUsernameExsist(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.usernameExsist);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL1Category(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getL1Category);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function SetDepreciationRate(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.SetDepreciationRate);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ComputeDepreciation(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ComputeDepreciation);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function SaveDepreciation(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.SaveDepreciation);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReturnDepreciationDates(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ReturnDepreciationDates);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReturnDepreciation(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ReturnDepreciation);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}


//function getL1Category(callback) {

//    var requetUrl = baseUrl.apiServer.concat(api.AssetSearch.getL1Category);

//    var reqData = {
//        url: requetUrl,
//        type: "Get"
//    };

//    var respData = {
//        message: "",
//        data: "null"
//    };

//    callAjax(reqData, function (resp) {
//        respData = {
//            message: resp.Message,
//            data: resp.Data
//        };
//        return callback(respData);
//    });
//}

// ********  Asset Search ************ //

function getL2Category(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getL2Category);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL2CategoryOnly(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getL2CategoryOnly);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL3Category(formData, callback) {
    console.log(formData);
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.getL3Category);

    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL2Location(formData, callback) {
    
    var requetUrl = baseUrl.apiServer.concat(api.AssetSearch.getL2Location);
    var reqData = {
        url: requetUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    
    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL3Location(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getL3Location);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL4Location(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getL4Location);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function getL5Location(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getL5Location);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Tagging Search ************ //

function getAssetTagging(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetTagging.getAssetTagging);
    console.log(requestUrl+"::urla");
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}


// ********  Asset Search ************ //

function getAsset(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getAsset);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function AssetNumberList(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.AssetNumberList);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function DateOfDisposalList(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.DateOfDisposalList);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function AssetDispose(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.AssetDispose);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function GetAssetBC(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getAssetBC);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Asset Search ************ //

function GetAssetDscption(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.getAssetDscption);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}


// ********  Dashboard ************ //

function GetUserLocation (formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Dashboard.getUserLocation);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Dashboard ************ //

function getDashboardData(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Dashboard.getDashboardData);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Permissions ************ //

function Permissions(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Common.permission);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Single Asset Movement ************ //

function AssetMoveSingle(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetMovementSingle.single);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
// ********  Single Asset Movement ************ //

function getSupplier(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.supplier);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Single Asset Movement ************ //

function getCurrency(callback) {

    var requetUrl = baseUrl.apiServer.concat(api.AssetSearch.currency);

    var reqData = {
        url: requetUrl,
        type: "POST"
    };

    var respData = {
        message: "",
        data: "null"
    };

    callAjax(reqData, function (resp) {
        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  Single Asset Movement ************ //

function Processing(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.Processing);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GPTransactionNumber ************ //

function GPNumberList(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GPNumberList);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GatePass ************ //

function GatePass(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GetGatePass);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GatePass ************ //

function GetGatePass(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GatePass);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GatePass Approval ************ //

function GatePassApproval(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.Approval);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GatePass Approval Denied ************ //

function GatePassApprovalDeclined(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GatePassApprovalDeclined);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GatePass Approval Denied ************ //

function GatePassReProcessing(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GatePassReProcessing);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  GatePass Approval Denied ************ //

function GatePassRelease(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GatePassRelease);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  ReceivingUser ************ //

function ReceivingUser(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.User.ReceivingUser);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

// ********  ReceivingUser ************ //

function GatePassReturn(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.GatePass.GatePassReturn);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalProcessing(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Processing);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data,
        content: "application/json"
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalNumberList(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.DisposalList);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DateOfDisposal(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.DateOfDisposalList);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalTransaction(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.DisposalTransaction);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReviewDisposal(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Review);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalDenied(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.DisposalDenied);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReProcessing(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Reprocessing);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalVerification(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Verification);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalAgreement(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Agreement);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalValidation(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Validation);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalApproval(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.Approval);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function DisposalApprovalAM(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ApprovalAM);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function IsBarcodeExsist(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.IsBarcodeExsist);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function IsBarcodeExsistRev(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.IsBarcodeExsistRev);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function IsAssetPurchaseDeatilExist(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.IsAssetPurchaseDeatilExist);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function AssetReverification(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.AssetReverification);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReplaceBarcode(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ReplaceBarcode);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReverifiedAssets(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ReverifiedAssets);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    console.log(reqData);
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ManualReverifiedAssets(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ManualReverifiedAssets);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    console.log(reqData);
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function Reconciliation(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.Reconciliation);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReverificationSchedule(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.ReverificationSchedule);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function AssetAdditionReverification(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetAddition.AssetAdditionReverification);
    console.log(requestUrl);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function CloseReverification(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.CloseReverification);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function isL3LocationAvailable(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetSearch.isL3LocationAvailable);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ongoingReverificationDate(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetReverification.ongoingReverificationDate);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReverifiedAssetsByDateOfVerification(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetReverification.ReverifiedAssetsByDateOfVerification);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function Reconciliation(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetReconciliation.Reconciliation);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReconciliationByDescription(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetReconciliation.ReconciliationByDescription);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function ReconciliationByRoomNumber(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetReconciliation.ReconciliationByRoomNumber);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function CreateL2Location(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Location.CreateL2Location);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function CreateL3Location(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Location.CreateL3Location);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}

function isL2LocationAvailable(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Location.isL2LocationAvailable);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ReconciliationByRoomNo(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.AssetReconciliation.ReconciliationByRoomNo);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ListOfValidators(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ListOfValidators);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ListofReveiwer(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ListofReveiwer);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ListofVerifier(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ListofVerifier);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ListofAgreed_GM(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ListofAgreed_GM);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ListofApproval_HO_Finance(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ListofApproval_HO_Finance);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}
function ListofApproval_HO_AM_Finance(formData, callback) {
    var requestUrl = baseUrl.apiServer.concat(api.Disposal.ListofApproval_HO_AM_Finance);
    var reqData = {
        url: requestUrl,
        type: formData.type,
        headers: null,
        data: formData.data
    };
    var respData = {
        message: "",
        data: "null"
    };

    //  calling callAjax function 
    callAjax(reqData, function (resp) {

        respData = {
            message: resp.Message,
            data: resp.Data
        };
        return callback(respData);
    });
}