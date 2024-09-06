/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

var baseUrl = {
    //apiServer: ' http://74.208.68.72/API/',
    //appServer: ' http://74.208.68.72/'
    apiServer: '/API/',
    appServer: '/'
};
//setting API Urls
var api = {

    Company: {
        view: 'Company/index',
        get: 'Company/GetCompaniesUser',
        add: 'Company/CreateCompany',
        getAllCountries: 'Company/AllCountries',
        edit: 'Company/EditCompany',
        update: 'Company/UpdateCompany',
        del: 'Company/DeleteCompany',
        codeExsist: 'Company/IsCompanyCodeExsist'
    },
    Location: {
        add: 'Location/CreateLocation',
        view: 'Location/AllLocation',
        edit: 'Location/EditLocation',
        update: 'Location/UpdateLocation',
        codeExsist: 'Location/IsLocationCodeExsist',
        CreateL2Location: 'Location/CreateL2Location',
        CreateL3Location: 'Location/CreateL3Location',
        isL2LocationAvailable: 'Location/isL2LocationAvailable'
    },
    User: {
        add: 'User/CreateUser',
        view: 'User/GetUsers',
        edit: 'User/Edit',
        update: 'User/UpdateUser',
        permssions: 'User/GetAllPermissions',
        usernameExsist: 'User/IsUserExsist',
        userLog: 'User/GetUserLog',
        changePassword: 'User/ChangePassword'
    },
    AssetSearch: {
        getL1Category: 'AssetSearch/GetL1Category',
        getL2Category: 'AssetSearch/GetL2Category',
        getL2CategoryOnly: 'AssetSearch/GetL2CategoryOnly',
        getL2Location: 'AssetSearch/GetL2Location',
        getL3Location: 'AssetSearch/GetL3Location',
        getL4Location: 'AssetSearch/GetL4Location',
        getL5Location: 'AssetSearch/GetL5Location',
        getAsset: 'AssetSearch/GetAsset',
        
        getAssetBC: 'AssetSearch/GetAssetBC',
        getAssetDscption: 'AssetSearch/GetAssetDscption',
        exportToExcel: 'AssetSearch/ExportToExcel',
        adminLocation: 'AssetSearch/GetAllLocationAdmin',
        currency: 'AssetSearch/GetCurrency',
        supplier: 'AssetSearch/GetSupplier',
        PurchaseDetails: 'AssetSearch/PurchaseDetails',
        AssetNumberList: 'AssetSearch/AssetNumberList',
        AssetDispose: 'AssetSearch/AssetDispose',
        DateOfDisposalList: 'AssetSearch/DateOfDisposalList',
        AssetReverification: 'AssetSearch/AssetReverification',
        ReplaceBarcode: 'AssetSearch/ReplaceBarcode',
        ReverifiedAssets: 'AssetSearch/ReverifiedAssets',
        Reconciliation: 'AssetSearch/Reconciliation',
        ReverificationSchedule: 'AssetSearch/ReverificationSchedule',
        isL3LocationAvailable: 'AssetSearch/isL3LocationAvailable',
        CloseReverification: 'AssetSearch/CloseReverification',
        SetDepreciationRate: 'AssetSearch/SetDepreciationRate',
        ComputeDepreciation: 'AssetSearch/ComputeDepreciation',
        SaveDepreciation: 'AssetSearch/SaveDepreciation',
        ReturnDepreciationDates: 'AssetSearch/ReturnDepreciationDates',
        ReturnDepreciation: 'AssetSearch/ReturnDepreciation'
    },
    AssetAddition: {
        getL3Category: 'AssetAddition/GetL3Category',
        addL3Category: 'AssetAddition/L3CategoryAddition',
        Addition: 'AssetAddition/AssetAddition',
        IsL3CategoryExist: 'AssetAddition/IsL3CategoryExist',
        SupplierAddition: '/API/AssetAddition/SupplierAddition',
        IsBarcodeExsist: 'AssetAddition/IsBarcodeExsist',
        IsBarcodeExsistRev: 'AssetAddition/IsBarcodeExsistRev',
        IsAssetPurchaseDeatilExist: 'AssetAddition/IsAssetPurchaseDeatilExist',
        AssetAdditionReverification: 'AssetAddition/AssetAdditionReverification'
    },
    AssetTagging: {
        AssetTagging: 'AssetTagging/AssetTagging',
        getAssetTagging: 'AssetTagging/GetAssetTagging',
    },
    Dashboard: {
        getUserLocation: 'Dashboard/UserAllLocation',
        getDashboardData: 'Dashboard/DashboardAssets'
    },
    Common: {
        permission: 'AssetSearch/GetPermissions'
    },
    AssetMovementSingle: {
        single: 'AssetSearch/AssetMovement'
    },
    GatePass: {
        Processing: 'GatePass/Processing',
        GPNumberList: 'GatePass/GPNumberList',
        GetGatePass: 'GatePass/GetGatePass',
        Approval: 'GatePass/Approval',
        GatePassApprovalDeclined: 'GatePass/GatePassApprovalDeclined',
        GatePassReProcessing: 'GatePass/GatePassReProcessing',
        GatePassRelease: 'GatePass/GatePassRelease',
        GatePassReturn: 'GatePass/GatePassReturn',
        GatePass: 'GatePass/GatePass'
    },
    Disposal: {
        Processing: 'Disposal/Processing',
        DisposalList: 'Disposal/DisposalNumberList',
        DateOfDisposalList: 'Disposal/DateOfDisposalList',
        DisposalTransaction: 'Disposal/DisposalTransaction',
        Review: 'Disposal/Review',
        DisposalDenied: 'Disposal/DisposalDenied',
        Reprocessing: 'Disposal/Reprocessing',
        Verification: 'Disposal/Verification',
        Agreement: 'Disposal/Agreement',
        Validation: 'Disposal/Validation',
        Approval: 'Disposal/Approval',
        ApprovalAM: 'Disposal/ApprovalAM',
        DisposalNumberList1: 'Disposal/DisposalNumber',
        ListOfValidators: 'Disposal/ListOfValidators',
        ListofReveiwer: 'Disposal/ListofReveiwer',
        ListofVerifier: 'Disposal/ListofVerifier',
        ListofAgreed_GM: 'Disposal/ListofAgreed_GM',
        ListofApproval_HO_Finance: 'Disposal/ListofApproval_HO_Finance',
        ListofApproval_HO_AM_Finance: 'Disposal/ListofApproval_HO_AM_Finance'

    },
    AssetReverification: {
        ongoingReverificationDate: 'AssetReverification/ongoingReverificationDate',
        ReverifiedAssetsByDateOfVerification: 'AssetReverification/ReverifiedAssetsByDateOfVerification'
    },
    AssetReconciliation: {
        Reconciliation: 'AssetReconciliation/Reconciliation',
        ReconciliationByDescription: 'AssetReconciliation/ReconciliationByDescription',
        ReconciliationByRoomNumber: 'AssetReconciliation/ReconciliationByRoomNumber',
        ReconciliationByRoomNo: 'AssetReconciliation/ReconciliationByRoomNo'
    }
};

var app = {

    Upload: {
        uploadImages: 'AssetAddition/UploadFiles'
    },
    Export: {
        exportExcel: 'AssetRegister/ExportExcel'
    },
    ExportSearch: {
        exportExcel: 'AssetSearch/ExportExcel'
    },
    AssetAddition: {
        FileUpload: 'AssetAddition/FileUpload'
    }
    //AssetAddition:{
    //    SupplierAddition: 'AssetAddition/SupplierAddition'
    //}
};
