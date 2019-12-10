using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartati
{
    class rfidManipulation
    {

        public static SerialPort port = new SerialPort("COM17", 19200, Parity.None, 8, StopBits.One);
        public static sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
        String[] ports = SerialPort.GetPortNames();

        #region selectT_Tag
        public void selectTag1()
        {
            try
            {
                byte TagType;
                byte[] TagSerial = new byte[4];
                byte ReturnCode = 0;
                sm132.OpenPort(ports.Last(),19200);
                sm132.CMD_SelectTag(out TagType, out TagSerial, out ReturnCode);
             }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #endregion

        #region write_bloc1
        public String write_bloc1(string text)
        {


            byte BlockNo = 6;
            byte[] BlockData = new byte[16];
            byte ReturnCode = 0;



            for (int i = 0; i < text.Length; i++)
            {

                int value = Convert.ToInt32(text[i]);
                string hexOut = String.Format("{0:X}", value);
                BlockData[i] = byte.Parse(hexOut, System.Globalization.NumberStyles.HexNumber);
            }
            if (sm132.CMD_WriteBlock(BlockNo, BlockData, out ReturnCode))
            {
                return "Write is Successfull";
            }
            else //Write not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Write Failed:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x55) //'U'
                {
                    return "Read after write Failed:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x58) //'X'
                {
                    return "Unable to read after write" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x01) //
                {
                    return "Writing to Sector Trailer is not allowed with this function" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }

            }

        }
        #endregion

        #region write_bloc2
        public String write_bloc2(string text)
        {


            byte BlockNo = 5;
            byte[] BlockData = new byte[16];
            byte ReturnCode = 0;



            for (int i = 0; i < text.Length; i++)
            {

                int value = Convert.ToInt32(text[i]);
                string hexOut = String.Format("{0:X}", value);
                BlockData[i] = byte.Parse(hexOut, System.Globalization.NumberStyles.HexNumber);
            }
            if (sm132.CMD_WriteBlock(BlockNo, BlockData, out ReturnCode))
            {
                return "Write is Successfull";

            }
            else //Write not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Write Failed:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x55) //'U'
                {
                    return "Read after write Failed:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x58) //'X'
                {
                    return "Unable to read after write" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x01) //
                {
                    return "Writing to Sector Trailer is not allowed with this function" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }

            }

        }
        #endregion

        #region auth_methode1
        public String auth_methode1()
        {
            try
            {
                byte AuthSource = 0xFF;
                byte BlockNo;
                byte ReturnCode;
                byte[] Key = new byte[6];

                BlockNo = 6;
                //The following Key will be used only if Provided Key option is selected.
                Key[0] = 0xFF;
                Key[1] = 0xFF;
                Key[2] = 0xFF;
                Key[3] = 0xFF;
                Key[4] = 0xFF;
                Key[5] = 0xFF;

                AuthSource = (byte)sm_mifare_lib.ASource.KeyMifareDefault;

                if (sm132.CMD_Authenticate(AuthSource, Key, BlockNo, out ReturnCode))
                {
                   return "Authentification Block 6 Success\n";
                }
                else
                {
                    return "Authentification Block 6 failed \n";
                }
            }
            catch (Exception)
            {
                throw new InvalidCastException();
            }


        }
        #endregion

        #region auth_methode2
        public String auth_methode2()
        {
            try
            {
                byte AuthSource = 0xFF;
                byte BlockNo;
                byte ReturnCode;
                byte[] Key = new byte[6];

                BlockNo = 5;
                //The following Key will be used only if Provided Key option is selected.
                Key[0] = 0xFF;
                Key[1] = 0xFF;
                Key[2] = 0xFF;
                Key[3] = 0xFF;
                Key[4] = 0xFF;
                Key[5] = 0xFF;

                AuthSource = (byte)sm_mifare_lib.ASource.KeyMifareDefault;

                if (sm132.CMD_Authenticate(AuthSource, Key, BlockNo, out ReturnCode))
                {
                    return "Authentification Block 5 Success\n";
                }
                else
                {
                    return "Authentification Block 5 failed\n";
                }

            }
            catch (Exception)
            {
                throw new InvalidCastException();
            }


        }
        #endregion

        #region auth_methode3
        public String auth_methode3()
        {
            try
            {
                byte AuthSource = 0xFF;
                byte BlockNo;
                byte ReturnCode;
                byte[] Key = new byte[6];

                BlockNo = 8;
                //The following Key will be used only if Provided Key option is selected.
                Key[0] = 0xFF;
                Key[1] = 0xFF;
                Key[2] = 0xFF;
                Key[3] = 0xFF;
                Key[4] = 0xFF;
                Key[5] = 0xFF;

                AuthSource = (byte)sm_mifare_lib.ASource.KeyMifareDefault;

                if (sm132.CMD_Authenticate(AuthSource, Key, BlockNo, out ReturnCode))
                {
                    return "Authentification Block 8 Success\n";
                }
                else
                {
                    return "Authentification Block 8 failed\n";
                }
            }
            catch (Exception)
            {
                throw new InvalidCastException();
            }


        }
        #endregion

        #region read_bloc1
        public String read_bloc1()
        {
            byte BlockNo = 0;
            byte[] BlockData = new byte[16];
            byte ReturnCode = 0;

            BlockNo = 6;
            //Form3 a = new Form3(this);
            if (sm132.CMD_ReadBlock(BlockNo, out BlockData, out ReturnCode))
            {
                return Encoding.ASCII.GetString(BlockData);
            }
            else //Read not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Read Failed:" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }

            }
        }
        #endregion

        #region read_bloc2
        public String read_bloc2()
        {
            byte BlockNo = 0;
            byte[] BlockData = new byte[16];
            byte ReturnCode = 0;

            BlockNo = 5;

            if (sm132.CMD_ReadBlock(BlockNo, out BlockData, out ReturnCode))
            {
                return Encoding.ASCII.GetString(BlockData);
            }
            else //Read not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Read Failed:" + ReturnCode.ToString("X2");
                }
                else
                {

                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }

            }
        }
        #endregion

        #region increment
        public String inc(string text)
        {
            byte BlockNo = 0;
            long IncValue = 0;
            long NewValue = 0;
            byte ReturnCode = 0;

            BlockNo = 8;
            IncValue = Int32.Parse(text);
            if (sm132.CMD_IncrementValue(BlockNo, IncValue, out NewValue, out ReturnCode))
            {
                return NewValue.ToString();

            }
            else //Increment Value not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x49) //'I'
                {
                    return "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }
            }
        }
        #endregion

        #region decrement
        public String dec(string text)
        {
            byte BlockNo = 0;
            long DecValue = 0;
            long NewValue = 0;
            byte ReturnCode = 0;

            BlockNo = 8;
            DecValue = Int32.Parse(text);

            if (sm132.CMD_DecrementValue(BlockNo, DecValue, out NewValue, out ReturnCode))
            {
                
                return NewValue.ToString();

            }
            else //Decrement Value not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x49) //'I'
                {
                    return "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }
            }


        }
        #endregion

        #region write_value
        public string write_value(string text)
        {
            byte BlockNo = 0;
            long Value = 0;
            byte ReturnCode = 0;
           BlockNo = 8;
          
            Value = Int32.Parse(text);
            if (sm132.CMD_WriteValue(BlockNo, Value, out ReturnCode))
            {
                return Value.ToString();
            }
            else //WriteValue not successful
            {
                if (ReturnCode == 0x4E) //'N'
                {
                   
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                   
                    return "Write Failed. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x58) //'X'
                {
                    return "Unable to read after write. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x55) //'U'
                {
                    return "Read after write failed. Error Code:" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }
            }
        }
        #endregion

        #region read_value
        public String read_value()
        {
            byte BlockNo = 0;
            long Value = 0;
            byte ReturnCode = 0;

            BlockNo = 8;


            if (sm132.CMD_ReadValue(BlockNo, out Value, out ReturnCode))
            {
                return Value.ToString();
            }
            else //ReadValue not successful
            {

                if (ReturnCode == 0x4E) //'N'
                {
                    return "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x46) //'F'
                {
                    return "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                }
                else if (ReturnCode == 0x49) //'I'
                {
                    return "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                }
                else
                {
                    return "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                }
            }
        }
        #endregion

    }


}
