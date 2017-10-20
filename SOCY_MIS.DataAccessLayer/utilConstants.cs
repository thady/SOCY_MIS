using System;

namespace SOCY_MIS.DataAccessLayer
{
    public class utilConstants
    {
        #region App Config Keys
        public const string cACKBlankOfficeEdit = "BlankOfficeEdit";
        public const string cACKConnection = "SOCY_MIS";
        public const string cACKConnectionFile = "ConnectionFile";
        public const string cACKImageFolder = "ImageFolder";
        public const string cACKImportDataFolder = "ImportDataFolder";
        public const string cACKNoDatabase = "NoDatabase";
        public const string cACKVersion = "Version";
        #endregion App Config Keys

        #region App Defaults
        public const int cADSessionKeyLength = 8;
        public const string cADTableCheck = "um_user_upload";
        #endregion App Defaults

        #region Defaults
        public const string cDFAdminID = "1";
        public const string cDFAdminRole = "4155a6c4-f79c-4134-a8bb-2dbef193596f";
        public const int cDFActive = 1;
        public const int cDFInActives = 0;
        public const string cDFDownloadDelimiter = "~~88~~";
        public const string cDFEmptyDateValue = "1900/01/01";
        public const string cDFEmptyListValue = "-1";
        public const string cDFImportOffice = "IMPORT";
        public const string cDFLngId = "EN";
        public const string cDFListValueNo = "0";
        public const string cDFListValueOther = "Other";
        public const string cDFListValueYes = "1";
        public const string cDFMaxGUID = "ffffffff-ffff-ffff-ffff-ffffffffffff";
        public const int cDFPasswordformat = 1;
        public const int cDFPhoneNumberLength = 10;
        public const char cDFSplitChar = '~';
        public const string cDFStatus = "1";
        #endregion Defaults

        #region DREAMS Record Types
        public const string cDRTHTCRegister = "1";
        public const string cDRTPartnerTracking = "2";
        public const string cDRTSINOVUYOMissedSessions = "3";
        public const string cDRTSteppingStonesMissedSessions = "4";
        #endregion PopUp Types

        #region Gender
        public const string cGNDFemale = "f05d3f3c-9aac-4f12-b0cd-1c4ae9294da3";
        public const string cGNDMale = "m26e435b-1478-4978-aad5-58c3677a1f70";
        #endregion Gender

        #region HIV Status
        public const string cHSTPositive = "1";
        public const string cHSTNegative = "2";
        public const string cHSTUnKnown = "3";
        #endregion HIV Status

        #region Member Type
        public const string cMTExternal = "2";
        public const string cMTHousehold = "1";
        #endregion Member Type

        #region Message IDs
        public const string cMIDAccountInactive = "43";
        public const string cMIDDatabaseConnectionFailed = "49";
        public const string cMIDDeleteCancelled = "53";
        public const string cMIDDeleteCheckRecords = "52";
        public const string cMIDDeleteConformation = "51";
        public const string cMIDDeleteRecordsConformation = "50";
        public const string cMIDDREAMSIdInUse = "2";
        public const string cMIDEmailAddressInvalid = "21";
        public const string cMIDEmailAddressInUse = "13";
        public const string cMIDEmailFormatInvalid = "1";
        public const string cMIDEmptyListMultiSelect = "9";
        public const string cMIDEmptyListNewRecord = "61";
        public const string cMIDEmptyListSingleSelect = "10";
        public const string cMIDInvalidDateRange = "39";
        public const string cMIDMessageServer = "55";
        public const string cMIDMessageWelcome = "56";
        public const string cMIDNameIsUse = "19";
        public const string cMIDPasswordConfirmMatch = "11";
        public const string cMIDPasswordFormatInvalid = "22";
        public const string cMIDPasswordIncorrect = "23";
        public const string cMIDPhoneNumberInUse = "54";
        public const string cMIDPhoneNumberLength = "20";
        public const string cMIDRequiredFields = "5";
        public const string cMIDRoleNameExists = "7";
        public const string cMIDSaved = "8";
        public const string cMIDSyncComplete = "59";
        public const string cMIDSyncMessage = "57";
        public const string cMIDSyncNoSession = "60";
        public const string cMIDSyncTitle = "58";
        public const string cMIDValidateCBSDAnnualRealization = "45";
        public const string cMIDValidateCBSDBudgetProbation = "44";
        public const string cMIDValidateCSOOutOf = "41";
        public const string cMIDValidateMinutesReviewed = "42";
        public const string cMIDValidateProbationAnnualRealization = "46";
        #endregion Message IDs

        #region Office Status
        public const string cOSTRejected = "0";
        public const string cOSTValidated = "1";
        public const string cOSTWaitingValidation = "2";
        #endregion Office Status

        #region Online Status
        public const string cOLSOffline = "0";
        public const string cOLSOnline = "1";
        #endregion Online Status

        #region Permissions
        public const string cPMViewSocialWorkers = "1";
        public const string cPMManageSocialWorder = "2";
        public const string cPMManageParaSocialWorker = "3";
        public const string cPMViewHouseholds = "4";
        public const string cPMManageOVCIdentificationandPrioritization = "5";
        public const string cPMManageHouseholdAssessment = "6";
        public const string cPMManageHomeVisits = "7";
        public const string cPMManageReferrals = "8";
        public const string cPMManageHouseholdDetails = "9";
        public const string cPMManageHouseholdMembers = "10";
        public const string cPMViewResultArea01 = "11";
        public const string cPMViewActivityTraining = "12";
        public const string cPMManageActivityTraining = "13";
        public const string cPMViewApprentishipRegister = "14";
        public const string cPMManageApprentishipRegister = "15";
        public const string cPMViewGildChildEducation = "16";
        public const string cPMManageGirlChildEducation = "17";
        public const string cPMViewServiceRegister = "18";
        public const string cPMManageServiceRegister = "19";
        public const string cPMViewValueChainActorRegistration = "20";
        public const string cPMManageValueChainActorRegistration = "21";
        public const string cPMViewResultArea02 = "22";
        public const string cPMViewAlternativeCarePanelSummary = "23";
        public const string cPMManageAlternativeCarePanelSummary = "24";
        public const string cPMViewCBSDResourceAllocation = "25";
        public const string cPMManageCBSDResourceAllocation = "26";
        public const string cPMViewCBSDStaffandAppraisalTracking = "27";
        public const string cPMManageCBSDStaffandAppraisalTracking = "28";
        public const string cPMViewDistrictOVCCoordinationOVCDataUsageChecklist = "29";
        public const string cPMManageDistrictOVCCoordinationOVCDataUsageChecklist = "30";
        public const string cPMViewInstitutionalCareSummary = "31";
        public const string cPMManageInstitutionalCareSummary = "32";
        public const string cPMAdministrator = "33";
        public const string cPMViewSILC = "34";
        public const string cPMManageSILCGroup = "35";
        public const string cPMManageSILCSavingsRegister = "36";
        public const string cPMViewSILCGroupFinancialRegister = "37";
        public const string cPMManageSILCGroupFinancialRegister = "38";
        public const string cPMViewDREAMS = "39";
        public const string cPMViewDREAMSEnrolmentRegister = "40";
        public const string cPMManageDREAMSEnrolmentRegister = "41";
        public const string cPMViewDREAMSMembers = "42";
        public const string cPMManageDREAMSMembers = "43";
        public const string cPMManageDREAMSPartnerTracking = "44";
        public const string cPMViewDREAMSPostViolenceCare = "45";
        public const string cPMManageDREAMSPostViolenceCare = "46";
        public const string cPMViewDREAMSSINOVUYOAttendacneRegister = "47";
        public const string cPMManageDREAMSSINOVUYOAttendacneRegister = "48";
        public const string cPMViewDREAMSSteppingStonesAttendacneRegister = "49";
        public const string cPMManageDREAMSSteppingStonesAttendacneRegister = "50";
        public const string cPMManageDREAMSSINOVUYOMissedSession = "51";
        public const string cPMManageDREAMSSteppingStonesMissedSession = "52";
        public const string cPMManageDREAMSHTCRegister = "53";
        #endregion Permissions

        #region PopUp Images
        public const string cPIError = "Error.png";
        public const string cPIInfo = "Info.png";
        public const string cPIWarning = "Warning.png";
        #endregion PopUp Images

        #region PopUp Button
        public const int cPBOk = 1;
        public const int cPBYesNo = 2;
        #endregion PopUp Button

        #region PopUp Types
        public const int cPTError = 1;
        public const int cPTInfo = 2;
        public const int cPTWarning = 3;
        #endregion PopUp Types

        #region Record Types
        public const string cRTHouseAssessment = "1";
        public const string cRTHomeVisitArchive = "5";
        public const string cRTHomeVisit = "2";
        public const string cRTOVCIdentificationPrioritization = "4";
        public const string cRTReferral = "3";
        #endregion PopUp Types

        #region Social Worker Type
        public const string cSWTParaSocialWorker = "2";
        public const string cSWTSocialWorker = "1";
        #endregion Staff Structure

        #region Staff Structure
        public const string cSSDCDO = "1";
        public const string cSSSPSWO = "2";
        public const string cSSCDO = "3";
        public const string cSSACDO = "4";
        public const string cSSSCDO = "5";
        #endregion Staff Structure

        #region Trigger Action
        public const string cTADelete = "3";
        public const string cTAInsert = "1";
        #endregion Trigger Action
    }
}
