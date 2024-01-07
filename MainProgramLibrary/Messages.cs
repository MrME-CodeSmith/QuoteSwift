using QuoteSwift;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MainProgramLibrary
{
    public static class Messages
    {

        public static string InvalidParameter => "Parameter is not valid.";

        //========================================  Part Details Errors Related  =====================================================
        public static string PartAlreadyExists => "This part already exists in the system. Please ensure that these are unique:\n- Original Part Number\n- New Part Number";
        public static string InvalidPartName => "Please ensure that the name of the Item is valid and it has a length greater than two(2) characters.";
        public static string InvalidPartDescription => "Please ensure that the description of the Item is valid and it has a length greater than two(2) characters.";
        public static string InvalidOriginalPartNumber => "Please ensure that the original part number of the Item is valid and it has a length greater than two(2) characters.";
        public static string InvalidNewPartNumber => "Please ensure that the new part number of the Item is valid and it has a length greater than two(2) characters.";
        public static string InvalidPartPrice => "Please ensure that the price of the Item is valid and it has a value greater than R99.";

        //========================================  Business Details Errors Related  =====================================================

        public static string BusinessAlreadyExists => "This business already exists in the system. Please ensure that these are unique:\n- VAT Number\n- Registration Number";
        public static string InvalidBusinessName => "The provided business name is invalid, please provide a business name longer that 2 characters.";
        public static string InvalidTaxNumber => "The provided VAT number is invalid, please provide a valid VAT number.";
        public static string InvalidRegistrationNumber => "The provided registration number is invalid, please provide a valid registration number.";
        public static string NoBusinessAddress => "Please add a valid business address under the 'mBusiness Address' section.";
        public static string NoPoBoxAddress => "Please add a valid business P.O.Box address under the 'mBusiness P.O.Box Address' section.";
        public static string NoValidPhoneNumber => "Please add a valid phone number under the 'Phone Related' section.";
        public static string NoValidEmailAddress => "Please add a valid business email address under the 'Email Related' section.";

        //========================================  Messages Related  ===================================================

        public static string TerminationRequestCaption => "REQUEST - Application Termination";
        public static string TerminationRequestText => "Are you sure you want to close the application?";

        public static string UpdatePartsWithSamePartNumbersRequestCaption => "REQUEST - Update Duplicate Part";
        public static string UpdatePartsWithSamePartNumbersRequestText => "In case a duplicate part is being added would you like to update the part's details instead?";

        public static string UpdateConfirmationInfoCaption => "CONFIRMATION - Update Successful";
        public static string UpdateConfirmationInfoText => "Successfully updated";

        public static string AddConfirmationInformationCaption => "CONFIRMATION - Add Successful";
        public static string AddConfirmationInformationText => "Successfully added";

        public static string CsvBatchImportSuccessCaption => "CONFIRMATION - CSV Batch Import Successful";
        public static string CsvBatchImportSuccessText => "The CSV file was successfully imported.";

        public static string CsvBatchImportInformationCaption => "INFORMATION - CSV Batch Import Successful";
        public static string CsvBatchImportInformationText => "Please ensure that the selected CSV file has the following items in this exact order:\n\n" +
                                                              "First Column: Original Part Number\n" +
                                                              "Second Column: Part Name\n" +
                                                              "Third Column: Part Description\n" +
                                                              "Fourth Column: New Part Number\n" +
                                                              "Fifth Column: Part Price\n" +
                                                              "Sixth Column: Part Quantity (To add this amount of parts to the pump specified)\n" +
                                                              "Seventh Column: TRUE / FALSE value (Mandatory part)\n" +
                                                              "Eighth Column: Pump Name(To add a part to a specific pump)\n" +
                                                              "Ninth Column: Pump Price (Price when pump is bought new)\n" +
                                                              "Click the OK button to select the file or alternative choose cancel to abort this action.";

        public static string ScreenDefaultValueRequestCaption => "REQUEST - Screen Defaults Reset";
        public static string ScreenDefaultValueRequestText => "Are you sure you want to reset the screen defaults?";

        public static string ActionCancelRequestCaption => "REQUEST - Action Cancellation";
        public static string ActionCancelRequestText => "Are you sure you want to cancel this action?";

        public static string TaskWarningInformationCaption => "WARNING - Task could not complete";
        public static string TaskErrorInformationCaption => "ERROR - Task failed";

        public static string CsvBatchImportErrorCaption => "ERROR - CSV Batch Import Failed";
        public static string CsvBatchImportErrorText => "The CSV file could not be imported. Please ensure that the file is not open in another application and that the file's format is correct.";

        public static string TaskErrorInformationText => "The task could not be completed. Please try restarting the system.";
        public static string InvalidInputErrorCaption => "ERROR - Invalid Input";
        public static string UpdatePartRequestText => "You are currently only viewing a part, would you like to update its details instead?";
        public static string UpdatePartRequestCaption => "REQUEST - Update Specific Part Details";

        //===============================================================================================================
    }

}
