using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ProtoBuf;



namespace QuoteSwift
{
    public static class MainProgramCode
    {

        // Set Components To ReadWrite:

        public static void ReadWriteComponents(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (TextBox txt in cc.OfType<TextBox>()) txt.ReadOnly = false;
                foreach (MaskedTextBox mtxt in cc.OfType<MaskedTextBox>()) mtxt.ReadOnly = false;
                foreach (RichTextBox rtxt in cc.OfType<RichTextBox>()) rtxt.ReadOnly = false;
                foreach (ComboBox cb in cc.OfType<ComboBox>()) cb.Enabled = true;
                foreach (DateTimePicker dtp in cc.OfType<DateTimePicker>()) dtp.Enabled = true;
                foreach (NumericUpDown nud in cc.OfType<NumericUpDown>()) nud.ReadOnly = false;
                foreach (DataGridView dgv in cc.OfType<DataGridView>()) dgv.ReadOnly = false;
                foreach (Button btn in cc.OfType<Button>()) btn.Enabled = true;
            }
        }

        // Set Components To Read-Only:

        public static void ReadOnlyComponents(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (TextBox txt in cc.OfType<TextBox>()) txt.ReadOnly = true;
                foreach (MaskedTextBox mtxt in cc.OfType<MaskedTextBox>()) mtxt.ReadOnly = true;
                foreach (RichTextBox rtxt in cc.OfType<RichTextBox>()) rtxt.ReadOnly = true;
                foreach (ComboBox cb in cc.OfType<ComboBox>()) cb.Enabled = false;
                foreach (DateTimePicker dtp in cc.OfType<DateTimePicker>()) dtp.Enabled = false;
                foreach (NumericUpDown nud in cc.OfType<NumericUpDown>()) nud.ReadOnly = true;
                foreach (DataGridView dgv in cc.OfType<DataGridView>()) dgv.ReadOnly = true;
                foreach (Button btn in cc.OfType<Button>()) btn.Enabled = false;
            }
        }

        /** Serialization Methods: */

        //Read file into byte Array

        public static byte[] RetreiveData(string FileName)
        {
            string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + FileName;
            byte[] Data;
            try
            {
                Data = File.ReadAllBytes(StorePath);
                return Data;
            }
            catch(FileNotFoundException)
            {
                //Do Nothing
                MainProgramCode.ShowError(FileName + " Could not be found, please contact the developer to fix this issue.","ERROR - " + FileName );
                Application.Exit();
            }
            catch
            {
                throw;
            }

            return null;
        }


        //Store Byte Array to Directory

        public static bool SaveData(string FileName, byte[] StoreData)
        {
            string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + FileName;

            try
            {
                if (File.Exists(StorePath)) File.Delete(StorePath);
                BinaryWriter FileWriter = new BinaryWriter(File.OpenWrite(StorePath));
                FileWriter.Write(StoreData);
                FileWriter.Flush();
                FileWriter.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Serialize - Protobuf

        public static byte[] ProtoSerialize<T>(T record) where T : class
        {
            if (null == record) return null;

            try
            {
                using (var stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, record);
                    return stream.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }

        //Deserialize - Protobuf

        public static T ProtoDeserialize<T>(byte[] data) where T : class
        {
            if (null == data) return null;

            try
            {
                using (var stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize<T>(stream);
                }
            }
            catch
            {
                throw;
            }
        }

        //Serialize Part list:

        public static byte[] SerializePartList(BindingList<Part> PartList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<BindingList<Part>>(PartList);
            }
            catch
            {
                throw;
            }

        return tempByte;
        }

        //Deserialize Part list:

        public static BindingList<Part> DeserializePartList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.ProtoDeserialize<BindingList<Part>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize Mandatory Part List Method

        public static void SerializeMandatoryPartList(ref Pass passed)
        {
            //Determine if Mandatory Parts exist:

                if (passed != null && passed.PassMandatoryPartList != null)
                {
                   byte[] ToStore = MainProgramCode.SerializePartList(passed.PassMandatoryPartList);
                   MainProgramCode.SaveData("MandatoryParts.pbf", ToStore);
                }
        }

        // Serialize Non-Mandatory Part List Method

        public static void SerializeNonMandatoryPartList(ref Pass passed)
        {
            //Determine if Non-Mandatory Parts exist:

            if (passed != null && passed.PassNonMandatoryPartList != null)
            {
                byte[] ToStore = MainProgramCode.SerializePartList(passed.PassNonMandatoryPartList);
                MainProgramCode.SaveData("NonMandatoryParts.pbf", ToStore);
            }
        }

        // Serialize Pump List Method

        public static byte[] SerializePumpList(BindingList<Pump> PumpPartList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<BindingList<Pump>>(PumpPartList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // Deserialize Pump List Method

        public static BindingList<Pump> DeserializePumpList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.ProtoDeserialize<BindingList<Pump>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and Store Pump List Method

        public static void SerializePumpList(ref Pass passed)
        {
            //Determine if Pump List exist:

            if (passed != null && passed.PassPumpList != null)
            {
                byte[] ToStore = MainProgramCode.SerializePumpList(passed.PassPumpList);
                MainProgramCode.SaveData("PumpList.pbf", ToStore);
            }
        }


        // Serialize Business List Method

        public static byte[] SerializeBusinessList(BindingList<Business> BusinessList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<BindingList<Business>>(BusinessList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // Deserialize Pump List Method

        public static BindingList<Business> DeserializeBusinessList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.ProtoDeserialize<BindingList<Business>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and Store Pump List Method

        public static void SerializeBusinessList(ref Pass passed)
        {
            //Determine if Pump List exist:

            if (passed != null && passed.PassBusinessList != null)
            {
                byte[] ToStore = MainProgramCode.SerializeBusinessList(passed.PassBusinessList);
                MainProgramCode.SaveData("BusinessList.pbf", ToStore);
            }
        }



        /****************************************************/


        /** Message Box Custom Functions */



        //Confirmation Request:

        public static bool RequestConfirmation(string text, string caption)
        {
            DialogResult MessageBoxResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return MessageBoxResult == DialogResult.Yes;
        }

        public static void ShowError(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /*********************************/
        


        //Procedure Handeling The Closing Of The Application
        public static void CloseApplication(bool b, ref Pass passed)
        {
            if (b)
            {
                MainProgramCode.SerializeMandatoryPartList(ref passed);

                MainProgramCode.SerializeNonMandatoryPartList(ref passed);

                MainProgramCode.SerializePumpList(ref passed);

                MainProgramCode.SerializeBusinessList(ref passed);

                Application.Exit();
            }
        }

        /** Parse String Inputs: */
        
        // Parse Float:

        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
            return temp;
        }
        
        // Parse Bool:

        public static bool ParseBoolean(string t)
        {
            bool.TryParse(t, out bool temp);
            return temp;
        }

        // Parse Int:

        public static int ParseInt(string t)
        {
            int.TryParse(t, out int temp);
            return temp;
        }


        /*************************/



        /** Different Screen Creation Handeling */

        // New Quote:

        public static ref Pass CreateNewQuote(ref Pass passed)
        {
            FrmCreateQuote newQuote = new FrmCreateQuote(ref passed);
            newQuote.ShowDialog();
            return ref newQuote.Passed;
        }

        //View Quote:

        public static ref Pass ViewAllQuotes(ref Pass passed)
        {
            FrmViewQuotes frmViewQuotes = new FrmViewQuotes(ref passed);
            frmViewQuotes.ShowDialog();
            return ref frmViewQuotes.Passed;
        }

        // View Pumps:

        public static ref Pass ViewAllPumps(ref Pass passed)
        {
            FrmViewPump frmViewPump = new FrmViewPump(ref passed);
            frmViewPump.ShowDialog();
            return ref frmViewPump.Passed;
        }

        // New Pump:

        public static ref Pass CreateNewPump(ref Pass passed)
        {
            FrmAddPump frmAddPump = new FrmAddPump(ref passed);
            frmAddPump.ShowDialog();
            return ref frmAddPump.Passed;
        }

        // View Pump Parts:

        public static ref Pass ViewAllParts(ref Pass passed)
        {
            FrmViewParts frmViewParts = new FrmViewParts(ref passed);
            try
            {
                frmViewParts.ShowDialog();
            }
            catch
            {
                //do nothing
            }
            return ref frmViewParts.Passed;
        }

        // New Parts:

        public static ref Pass AddNewPart(ref Pass passed)
        {
            FrmAddPart frmAddPart = new FrmAddPart(ref passed);
            frmAddPart.ShowDialog();
            return ref frmAddPart.Passed;
        }

        // New Customer:

        public static ref Pass AddCustomer(ref Pass passed)
        {
            FrmAddCustomer frmAddCustomer = new FrmAddCustomer(ref passed);
            frmAddCustomer.ShowDialog();
            return ref frmAddCustomer.Passed;
        }

        // View Customers:

        public static ref Pass ViewCustomers(ref Pass passed)
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers(ref passed);
            frmViewCustomers.ShowDialog();
            return ref frmViewCustomers.Passed;
        }

        // New Business:

        public static ref Pass AddBusiness(ref Pass passed)
        {
            FrmAddBusiness frmAddBusiness = new FrmAddBusiness(ref passed);
            frmAddBusiness.ShowDialog();
            return ref frmAddBusiness.Passed;
        }

        // View Businesses

        public static ref Pass ViewBusinesses(ref Pass passed)
        {
            FrmViewAllBusinesses frmViewAllBusinesses = new FrmViewAllBusinesses(ref passed);
            frmViewAllBusinesses.ShowDialog();
            return ref frmViewAllBusinesses.Passed;
        }

        // View Business Addresses

        public static ref Pass ViewBusinessesAddresses(ref Pass passed)
        {
            FrmViewBusinessAddresses FrmViewBusinessAddresses = new FrmViewBusinessAddresses(ref passed);
            FrmViewBusinessAddresses.ShowDialog();
            return ref FrmViewBusinessAddresses.Passed;
        }

        // View Business P.O.Box Addresses

        public static ref Pass ViewBusinessesPOBoxAddresses(ref Pass passed)
        {
            FrmViewPOBoxAddresses FrmViewPOBoxAddresses = new FrmViewPOBoxAddresses(ref passed);
            FrmViewPOBoxAddresses.ShowDialog();
            return ref FrmViewPOBoxAddresses.Passed;
        }

        // View Business Email Addresses

        public static ref Pass ViewBusinessesEmailAddresses(ref Pass passed)
        {
            FrmManageAllEmails FrmManageAllEmails = new FrmManageAllEmails(ref passed);
            FrmManageAllEmails.ShowDialog();
            return ref FrmManageAllEmails.Passed;
        }

        // View Business Phone Numbers

        public static ref Pass ViewBusinessesPhoneNumbers(ref Pass passed)
        {
            FrmManagingPhoneNumbers FrmManagingPhoneNumbers = new FrmManagingPhoneNumbers(ref passed);
            FrmManagingPhoneNumbers.ShowDialog();
            return ref FrmManagingPhoneNumbers.Passed;
        }

        // Edit Business Address:
        
        public static ref Pass EditBusinessAddress(ref Pass passed)
        {
            FrmEditBusinessAddress frmEditBusinessAddress = new FrmEditBusinessAddress(ref passed);
            frmEditBusinessAddress.ShowDialog();
            return ref frmEditBusinessAddress.Passed;
        }

        // Edit Business Email Address:

        public static ref Pass EditBusinessEmailAddress(ref Pass passed)
        {
            FrmEditEmailAddress FrmEditEmailAddress = new FrmEditEmailAddress(ref passed);
            FrmEditEmailAddress.ShowDialog();
            return ref FrmEditEmailAddress.Passed;
        }

        // Edit Business Phone nUmbers

        public static ref Pass EditPhoneNumber(ref Pass passed)
        {
            FrmEditPhoneNumber frmEditPhoneNumber = new FrmEditPhoneNumber(ref passed);
            frmEditPhoneNumber.ShowDialog();
            return ref frmEditPhoneNumber.Passed;
        }

        /***************************************/

    }
}
