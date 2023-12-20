using System;
using System.Collections.Generic;
using System.Text;

namespace MainProgramLibrary
{
    public static class Messages
    {
        public static string PartAlreadyExists => "This part already exists in the system. Please ensure that these are unique:\n- Original Part Number\n- New Part Number";
        public static string InvalidParameter => "Parameter is not valid.";



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

        public static string CSVBatchImportInformationCaption => "INFORMATION - CSV Batch Import Successful";
        public static string CSVBatchImportInformationText => "Please ensure that the selected CSV file has the following items in this exact order:\n\n" +
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

        public static string TaskWarningInformationCaption => "WARNING - Task could not complete";
        public static string TaskErrorInformationCaption => "ERROR - Task failed";

        public static string CsvBatchImportErrorCaption => "ERROR - CSV Batch Import Failed";
        public static string CsvBatchImportErrorText => "The CSV file could not be imported. Please ensure that the file is not open in another application and that the file's format is correct.";

        public static string TaskErrorInformationText => "The task could not be completed. Please try restarting the system.";

        //===============================================================================================================
    }

}
