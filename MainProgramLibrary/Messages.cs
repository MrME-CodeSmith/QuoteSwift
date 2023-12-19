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

        public static string UpdateConfirmationInfoCaption => "CONFIRMATION - Update Successful";
        public static string UpdateConfirmationInfoText => "Successfully updated";

        public static string AddConfirmationInformationCaption => "CONFIRMATION - Add Successful";
        public static string AddConfirmationInformationText => "Successfully added";

        //===============================================================================================================
    }

}
