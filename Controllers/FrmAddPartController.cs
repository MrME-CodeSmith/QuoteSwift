using MainProgramLibrary;
using System;

namespace QuoteSwift.Controllers
{
    public class FrmAddPartController
    {
        public bool AddPartHandler(
            string partName,
            string partDescription,
            string originalPartNumber,
            string newPartNumber,
            string partPrice,
            bool isMandatory,
            bool showMessages = true,
            Product selectedProd = null,
            int partProdQuantity = 0,
            AppContext context = null
        )
        {
            var cleanedPartName = partName.Trim();
            var cleanedPartDescription = partDescription.Trim();
            var cleanedOriginalPartNumber = originalPartNumber.Trim();
            var cleanedNewPartNumber = newPartNumber.Trim();
            var cleanedPartPrice = QuoteSwiftMainCode.ParseFloat(partPrice.Trim());

            if ((context ?? mContext).ChangeSpecificObject)
            {

                if (
                    ValidInput(
                        partName: cleanedPartName,
                        partDescription: cleanedPartDescription,
                        originalPartNumber: cleanedOriginalPartNumber,
                        newPartNumber: cleanedNewPartNumber,
                        partPrice: partPrice,
                        showMessages: showMessages
                    )
                )
                {
                    var BeforeUpdatePart = new Part((context ?? mContext).PartToChange);

                    (context ?? mContext).PartToChange.PartName = cleanedPartName;
                    (context ?? mContext).PartToChange.PartDescription = cleanedPartDescription;
                    (context ?? mContext).PartToChange.OriginalItemPartNumber = cleanedOriginalPartNumber;
                    (context ?? mContext).PartToChange.NewPartNumber = cleanedNewPartNumber;
                    (context ?? mContext).PartToChange.PartPrice = cleanedPartPrice;
                    (context ?? mContext).PartToChange.MandatoryPart = isMandatory;

                    switch (BeforeUpdatePart.MandatoryPart)
                    {
                        case true when !BeforeUpdatePart.MandatoryPart:
                            ChangeToNonMandatory((context ?? mContext).PartToChange);
                            break;
                        case false when BeforeUpdatePart.MandatoryPart:
                            ChangeToMandatory((context ?? mContext).PartToChange);
                            break;
                    }

                    if (showMessages)
                        MainProgramCode.ShowInformation($"{Messages.UpdateConfirmationInfoText} the part", Messages.UpdateConfirmationInfoCaption);

                    (context ?? mContext).PartToChange = null;
                    (context ?? mContext).ChangeSpecificObject = false;
                    return true;
                }
                else return false;
            }
            else // Add New Part
            {
                Part newPart;
                if (
                    ValidInput(
                        cleanedPartName,
                        cleanedPartDescription,
                        cleanedOriginalPartNumber,
                        cleanedNewPartNumber,
                        partPrice,
                        showMessages: showMessages
                    )
                )
                {
                    newPart = new Part(
                        partName: cleanedPartName,
                        partDescription: cleanedPartDescription,
                        originalItempartNumber: originalPartNumber,
                        newPartNumber: cleanedNewPartNumber,
                        mandatoryPart: isMandatory,
                        partPrice: cleanedPartPrice
                    );
                }
                else return false;

                try
                {
                    (context ?? mContext).AddPart(ref newPart);
                }
                catch (FeedbackException Ex)
                {
                    if(showMessages) 
                        MainProgramCode.ShowWarning(
                            Ex.Message,
                            Messages.TaskWarningInformationCaption
                        );
                    return false;
                }
                catch (Exception)
                {
                    if (showMessages)
                        MainProgramCode.ShowError(
                            Messages.TaskErrorInformationText,
                            Messages.TaskErrorInformationCaption
                        );
                    return false;
                }

                if (selectedProd != null)
                {
                    selectedProd.PartList.Add(
                        new ProductPart(
                            newPart,
                            partProdQuantity
                        )
                    );

                    if (showMessages)
                        MainProgramCode.ShowInformation(
                        $"{Messages.AddConfirmationInformationText} {newPart.PartName} to {selectedProd.ProductName}'s part list.",
                            Messages.AddConfirmationInformationCaption
                        );
                }
                else
                {
                    if (showMessages)
                        MainProgramCode.ShowInformation(
                            $"{Messages.AddConfirmationInformationText} {newPart.PartName}",
                            Messages.AddConfirmationInformationCaption
                        );
                }

                return true;
            }
        }

        private readonly AppContext mContext = Global.Context;

        private static bool ValidInput(
            string partName,
            string partDescription,
            string originalPartNumber,
            string newPartNumber,
            string partPrice,
            bool showMessages = true
        )
        {
            if (partName.Length < 3)
            {
                if(showMessages) MainProgramCode.ShowError(Messages.InvalidPartName, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (partDescription.Length < 3)
            {
                if (showMessages) MainProgramCode.ShowError(Messages.InvalidPartDescription, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (originalPartNumber.Length < 3)
            {
                if(showMessages) MainProgramCode.ShowError(Messages.InvalidOriginalPartNumber, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (newPartNumber.Length < 3)
            {
               if(showMessages) MainProgramCode.ShowError(Messages.InvalidNewPartNumber, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (QuoteSwiftMainCode.ParseFloat(partPrice) == 0)
            {
                if(showMessages) MainProgramCode.ShowError(Messages.InvalidPartPrice, Messages.InvalidInputErrorCaption);
                return false;
            }

            return true;
        }

        private static bool ChangeToMandatory(Part switchPart)
        {
            if (switchPart != null)
            {
                var ctx = Global.Context;
                ctx.NonMandatoryPartMap.Remove(switchPart.OriginalItemPartNumber);
                ctx.NonMandatoryPartMap.Remove(switchPart.NewPartNumber);

                ctx.MandatoryPartMap[switchPart.OriginalItemPartNumber] = switchPart;
                ctx.MandatoryPartMap[switchPart.NewPartNumber] = switchPart;
                return true;
            }
            return false;
        }

        private static bool ChangeToNonMandatory(Part switchPart)
        {
            if (switchPart != null)
            {
                var ctx = Global.Context;
                ctx.MandatoryPartMap.Remove(switchPart.OriginalItemPartNumber);
                ctx.MandatoryPartMap.Remove(switchPart.NewPartNumber);

                ctx.NonMandatoryPartMap[switchPart.OriginalItemPartNumber] = switchPart;
                ctx.NonMandatoryPartMap[switchPart.NewPartNumber] = switchPart;

                return true;
            }
            return false;
        }
    }
}
