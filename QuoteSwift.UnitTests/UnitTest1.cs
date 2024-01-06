using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteSwift.Controllers;
using System;
using System.Globalization;
using System.Runtime.Remoting.Contexts;
using MainProgramLibrary;

namespace QuoteSwift.UnitTests
{
    [TestClass]
    public class FrmAddPartControllerTests
    {
        private FrmAddPartController mFrmAddPartController;

        [TestInitialize]
        public void Setup()
        {
            mFrmAddPartController = new FrmAddPartController();
            Global.InitializeContext();
        }

        [TestMethod]
        public void AddOrUpdatePartHandler_ValidInput_AddMandatoryPart_ReturnsTrue()
        {
            // Arrange
            const string partName = "TestPart";
            const string partDescription = "This is a test part";
            const string originalPartNumber = "123";
            const string newPartNumber = "456";
            const string partPrice = "100";
            const bool isMandatory = true;

            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                partName,
                partDescription,
                originalPartNumber,
                newPartNumber,
                partPrice,
                isMandatory,
                context: Global.Context,
                showMessages: false
            );

            // Assert
            Assert.IsTrue(result, "Expected AddOrUpdatePartHandler to return true for valid input");
            AssertPartInMandatoryMapOnly(originalPartNumber, newPartNumber);
        }

        [TestMethod]
        public void AddOrUpdatePartHandler_ValidInput_AddNonMandatoryPart_ReturnsTrue()
        {
            // Arrange
            const string partName = "TestPart";
            const string partDescription = "This is a test part";
            const string originalPartNumber = "123";
            const string newPartNumber = "456";
            const string partPrice = "100";
            const bool isMandatory = false;

            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                partName,
                partDescription,
                originalPartNumber,
                newPartNumber,
                partPrice,
                isMandatory,
                context: Global.Context,
                showMessages: false
            );

            // Assert
            Assert.IsTrue(result, "Expected AddOrUpdatePartHandler to return true for valid input");
            AssertPartInNonMandatoryMapOnly(originalPartNumber, newPartNumber);
        }


        [DataTestMethod]
        [DataRow("", "This is a test part", "123", "456", "100")]
        [DataRow("TestPart", "", "123", "456", "100")]
        [DataRow("TestPart", "This is a test part", "", "456", "100")]
        [DataRow("TestPart", "This is a test part", "123", "", "100")]
        [DataRow("TestPart", "This is a test part", "123", "456", "")]
        public void AddOrUpdatePartHandler_InvalidInput_ReturnsFalseAndDoesNotAddPartToMaps(
            string partName,
            string partDescription,
            string originalPartNumber,
            string newPartNumber,
            string partPrice
        )
        {
            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                partName,
                partDescription,
                originalPartNumber,
                newPartNumber,
                partPrice,
                false,
                context: Global.Context,
                showMessages: false
            );

            // Assert
            Assert.IsFalse(result, "Expected AddOrUpdatePartHandler to return false for invalid input");
            AssertPartNotInMaps(originalPartNumber, newPartNumber);
        }

        [TestMethod]
        public void AddOrUpdatePartHandler_ValidInput_UpdateMandatoryPart_ReturnsTrue()
        {
            // Arrange
            const string partName = "TestPart";
            const string partDescription = "This is a test part";
            const string originalPartNumber = "123";
            const string newPartNumber = "456";
            const string partPrice = "200";
            const bool isMandatory = true;

            var partToUpdate = new Part(
                partName: "UNINITIALISED",
                partDescription: "UNINITIALISED",
                originalItemPartNumber: originalPartNumber,
                newPartNumber: newPartNumber,
                mandatoryPart: true,
                partPrice: 100f
            );

            mFrmAddPartController.AddOrUpdatePartHandler(
                partToUpdate.PartName,
                partToUpdate.PartDescription,
                partToUpdate.OriginalItemPartNumber,
                partToUpdate.NewPartNumber,
                partToUpdate.PartPrice.ToString(CultureInfo.InvariantCulture),
                partToUpdate.MandatoryPart,
                context: Global.Context,
                showMessages: false
            );

            Global.Context.PartToChange = partToUpdate;
            Global.Context.ChangeSpecificObject = true;

            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                                partName,
                                partDescription,
                                originalPartNumber,
                                newPartNumber,
                                partPrice,
                                isMandatory,
                                context: Global.Context,
                                showMessages: false
                            );

            // Assert
            Assert.IsTrue(result, "Expected AddOrUpdatePartHandler to return true for valid update input");
            AssertPartInMandatoryMapOnly(originalPartNumber, newPartNumber);

            Assert.IsTrue(partToUpdate.PartName == partName, "Expected updated part to have the correct name");
            Assert.IsTrue(partToUpdate.PartDescription == partDescription, "Expected updated part to have the correct description");
            Assert.IsTrue(partToUpdate.OriginalItemPartNumber == originalPartNumber, "Expected updated part to have the correct original part number");
            Assert.IsTrue(partToUpdate.NewPartNumber == newPartNumber, "Expected updated part to have the correct new part number");
            Assert.IsTrue(partToUpdate.MandatoryPart == isMandatory, "Expected updated part to have the correct mandatory status");
            Assert.IsTrue(partToUpdate.PartPrice.Equals(MainProgramCode.ParseFloat(partPrice)), "Expected updated part to have the correct price");

            Assert.IsTrue(Global.Context.PartToChange == null, "Expected PartToChange to be null after updating part");
            Assert.IsFalse(Global.Context.ChangeSpecificObject, "Expected ChangeSpecificObject to be false after updating part");
        }

        [TestMethod]
        public void AddOrUpdatePartHandler_ValidInput_UpdateNonMandatoryPart_ReturnsTrue()
        {
            // Arrange
            const string partName = "TestPart";
            const string partDescription = "This is a test part";
            const string originalPartNumber = "123";
            const string newPartNumber = "456";
            const string partPrice = "200";
            const bool isMandatory = false;

            var partToUpdate = new Part(
                partName: "UNINITIALISED",
                partDescription: "UNINITIALISED",
                originalItemPartNumber: originalPartNumber,
                newPartNumber: newPartNumber,
                mandatoryPart: false,
                partPrice: 100f
            );

            mFrmAddPartController.AddOrUpdatePartHandler(
                partToUpdate.PartName,
                partToUpdate.PartDescription,
                partToUpdate.OriginalItemPartNumber,
                partToUpdate.NewPartNumber,
                partToUpdate.PartPrice.ToString(CultureInfo.InvariantCulture),
                partToUpdate.MandatoryPart,
                context: Global.Context,
                showMessages: false
            );

            Global.Context.PartToChange = partToUpdate;
            Global.Context.ChangeSpecificObject = true;

            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                                partName,
                                partDescription,
                                originalPartNumber,
                                newPartNumber,
                                partPrice,
                                isMandatory,
                                context: Global.Context,
                                showMessages: false
                            );

            // Assert
            Assert.IsTrue(result, "Expected AddOrUpdatePartHandler to return true for valid update input");
            AssertPartInNonMandatoryMapOnly(originalPartNumber, newPartNumber);

            Assert.IsTrue(partToUpdate.PartName == partName, "Expected updated part to have the correct name");
            Assert.IsTrue(partToUpdate.PartDescription == partDescription, "Expected updated part to have the correct description");
            Assert.IsTrue(partToUpdate.OriginalItemPartNumber == originalPartNumber, "Expected updated part to have the correct original part number");
            Assert.IsTrue(partToUpdate.NewPartNumber == newPartNumber, "Expected updated part to have the correct new part number");
            Assert.IsTrue(partToUpdate.MandatoryPart == isMandatory, "Expected updated part to have the correct mandatory status");
            Assert.IsTrue(partToUpdate.PartPrice.Equals(MainProgramCode.ParseFloat(partPrice)), "Expected updated part to have the correct price");

            Assert.IsTrue(Global.Context.PartToChange == null, "Expected PartToChange to be null after updating part");
            Assert.IsFalse(Global.Context.ChangeSpecificObject, "Expected ChangeSpecificObject to be false after updating part");
        }

        [TestMethod]
        public void AddOrUpdatePartHandler_ValidInput_UpdateMandatoryPartToNonMandatory_ReturnsTrue()
        {
            // Arrange
            const string partName = "TestPart";
            const string partDescription = "This is a test part";
            const string originalPartNumber = "123";
            const string newPartNumber = "456";
            const string partPrice = "200";
            const bool isMandatory = false;

            var partToUpdate = new Part(
                partName: "UNINITIALISED",
                partDescription: "UNINITIALISED",
                originalItemPartNumber: originalPartNumber,
                newPartNumber: newPartNumber,
                mandatoryPart: true,
                partPrice: 100f
            );

            mFrmAddPartController.AddOrUpdatePartHandler(
                partToUpdate.PartName,
                partToUpdate.PartDescription,
                partToUpdate.OriginalItemPartNumber,
                partToUpdate.NewPartNumber,
                partToUpdate.PartPrice.ToString(CultureInfo.InvariantCulture),
                partToUpdate.MandatoryPart,
                context: Global.Context,
                showMessages: false
            );

            // Assert
            AssertPartInMandatoryMapOnly(originalPartNumber, newPartNumber);

            // Arrange
            Global.Context.PartToChange = partToUpdate;
            Global.Context.ChangeSpecificObject = true;

            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                                partName,
                                partDescription,
                                originalPartNumber,
                                newPartNumber,
                                partPrice,
                                isMandatory,
                                context: Global.Context,
                                showMessages: false
                            );

            // Assert
            Assert.IsTrue(result, "Expected AddOrUpdatePartHandler to return true for valid update input");
            AssertPartInNonMandatoryMapOnly(originalPartNumber, newPartNumber);

            Assert.IsTrue(partToUpdate.PartName == partName, "Expected updated part to have the correct name");
            Assert.IsTrue(partToUpdate.PartDescription == partDescription, "Expected updated part to have the correct description");
            Assert.IsTrue(partToUpdate.OriginalItemPartNumber == originalPartNumber, "Expected updated part to have the correct original part number");
            Assert.IsTrue(partToUpdate.NewPartNumber == newPartNumber, "Expected updated part to have the correct new part number");
            Assert.IsTrue(partToUpdate.MandatoryPart == isMandatory, "Expected updated part to have the correct mandatory status");
            Assert.IsTrue(partToUpdate.PartPrice.Equals(MainProgramCode.ParseFloat(partPrice)), "Expected updated part to have the correct price");

            Assert.IsTrue(Global.Context.PartToChange == null, "Expected PartToChange to be null after updating part");
            Assert.IsFalse(Global.Context.ChangeSpecificObject, "Expected ChangeSpecificObject to be false after updating part");
        }

        [TestMethod]
        public void AddOrUpdatePartHandler_ValidInput_UpdateNonMandatoryPartToMandatory_ReturnsTrue()
        {
            // Arrange
            const string partName = "TestPart";
            const string partDescription = "This is a test part";
            const string originalPartNumber = "123";
            const string newPartNumber = "456";
            const string partPrice = "200";
            const bool isMandatory = true;

            var partToUpdate = new Part(
                partName: "UNINITIALISED",
                partDescription: "UNINITIALISED",
                originalItemPartNumber: originalPartNumber,
                newPartNumber: newPartNumber,
                mandatoryPart: false,
                partPrice: 100f
            );

            mFrmAddPartController.AddOrUpdatePartHandler(
                partToUpdate.PartName,
                partToUpdate.PartDescription,
                partToUpdate.OriginalItemPartNumber,
                partToUpdate.NewPartNumber,
                partToUpdate.PartPrice.ToString(CultureInfo.InvariantCulture),
                partToUpdate.MandatoryPart,
                context: Global.Context,
                showMessages: false
            );

            // Assert
            AssertPartInNonMandatoryMapOnly(originalPartNumber, newPartNumber);

            // Arrange
            Global.Context.PartToChange = partToUpdate;
            Global.Context.ChangeSpecificObject = true;

            // Act
            var result = mFrmAddPartController.AddOrUpdatePartHandler(
                                partName,
                                partDescription,
                                originalPartNumber,
                                newPartNumber,
                                partPrice,
                                isMandatory,
                                context: Global.Context,
                                showMessages: false
                            );

            // Assert
            Assert.IsTrue(result, "Expected AddOrUpdatePartHandler to return true for valid update input");
            AssertPartInMandatoryMapOnly(originalPartNumber, newPartNumber);

            Assert.IsTrue(partToUpdate.PartName == partName, "Expected updated part to have the correct name");
            Assert.IsTrue(partToUpdate.PartDescription == partDescription, "Expected updated part to have the correct description");
            Assert.IsTrue(partToUpdate.OriginalItemPartNumber == originalPartNumber, "Expected updated part to have the correct original part number");
            Assert.IsTrue(partToUpdate.NewPartNumber == newPartNumber, "Expected updated part to have the correct new part number");
            Assert.IsTrue(partToUpdate.MandatoryPart == isMandatory, "Expected updated part to have the correct mandatory status");
            Assert.IsTrue(partToUpdate.PartPrice.Equals(MainProgramCode.ParseFloat(partPrice)), "Expected updated part to have the correct price");

            Assert.IsTrue(Global.Context.PartToChange == null, "Expected PartToChange to be null after updating part");
            Assert.IsFalse(Global.Context.ChangeSpecificObject, "Expected ChangeSpecificObject to be false after updating part");
        }

        private void AssertPartNotInMaps(string originalPartNumber, string newPartNumber)
        {
            Assert.IsFalse(Global.Context.MandatoryPartMap.ContainsKey(originalPartNumber), "Expected MandatoryPartMap to not contain originalPartNumber of part with incorrect details");
            Assert.IsFalse(Global.Context.MandatoryPartMap.ContainsKey(newPartNumber), "Expected MandatoryPartMap to not contain newPartNumber of part with incorrect details");

            Assert.IsFalse(Global.Context.NonMandatoryPartMap.ContainsKey(originalPartNumber), "Expected NonMandatoryPartMap to not contain originalPartNumber of part with incorrect details");
            Assert.IsFalse(Global.Context.NonMandatoryPartMap.ContainsKey(newPartNumber), "Expected NonMandatoryPartMap to not contain newPartNumber of part with incorrect details");
        }

        private Part AssertPartInMandatoryMapOnly(string originalPartNumber, string newPartNumber)
        {
            var originalInMandatory = Global.Context.MandatoryPartMap.ContainsKey(originalPartNumber);
            var newInMandatory = Global.Context.MandatoryPartMap.ContainsKey(newPartNumber);

            Assert.IsTrue(originalInMandatory, "Expected MandatoryPartMap to contain originalPartNumber of newly added part");
            Assert.IsTrue(newInMandatory, "Expected MandatoryPartMap to contain newPartNumber of newly added part");

            Assert.IsFalse(Global.Context.NonMandatoryPartMap.ContainsKey(originalPartNumber), "Expected NonMandatoryPartMap to not contain originalPartNumber of newly added part");
            Assert.IsFalse(Global.Context.NonMandatoryPartMap.ContainsKey(newPartNumber), "Expected NonMandatoryPartMap to not contain newPartNumber of newly added part");

            return (originalInMandatory && newInMandatory) ? Global.Context.MandatoryPartMap[originalPartNumber] : null;
        }

        private void AssertPartInNonMandatoryMapOnly(string originalPartNumber, string newPartNumber)
        {
            Assert.IsTrue(Global.Context.NonMandatoryPartMap.ContainsKey(originalPartNumber), "Expected NonMandatoryPartMap to contain originalPartNumber of newly added part");
            Assert.IsTrue(Global.Context.NonMandatoryPartMap.ContainsKey(newPartNumber), "Expected NonMandatoryPartMap to contain newPartNumber of newly added part");

            Assert.IsFalse(Global.Context.MandatoryPartMap.ContainsKey(originalPartNumber), "Expected MandatoryPartMap to not contain originalPartNumber of newly added part");
            Assert.IsFalse(Global.Context.MandatoryPartMap.ContainsKey(newPartNumber), "Expected MandatoryPartMap to not contain newPartNumber of newly added part");
        }

    }

}
