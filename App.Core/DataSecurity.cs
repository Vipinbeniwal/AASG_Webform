using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Core
{
    public class DataSecurity
    {
        /// <summary>
        /// This method accepts plain string and converts to base64 encrypted string
        /// </summary>
        /// <param name="plainString">Plain String</param>
        /// <returns>Encrypted String</returns>
        public static string Encryptdata(string plainString)
        {
            string encodedString = string.Empty;
            byte[] encode = new byte[plainString.Length];
            encode = Encoding.UTF8.GetBytes(plainString);
            encodedString = Convert.ToBase64String(encode);
            return encodedString;
        }
        /// <summary>
        /// This method accepts base64 encrypted string and converts to plain string
        /// </summary>
        /// <param name="encryptedString">Encrypted String</param>
        /// <returns>Decrypted String</returns>
        public static string Decryptdata(string encryptedString)
        {
            string decryptedString = string.Empty;
            UTF8Encoding encodingStandard = new UTF8Encoding();
            Decoder Decode = encodingStandard.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptedString);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptedString = new String(decoded_char);
            return decryptedString;
        }
        private void Encrypt(string inputFilePath, string outputfilePath)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                        {
                            int data;
                            while ((data = fsInput.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }
        private void Decrypt(string inputFilePath, string outputfilePath)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                {
                    using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                        {
                            int data;
                            while ((data = cs.ReadByte()) != -1)
                            {
                                fsOutput.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }
        //protected void EncryptFile(object sender, EventArgs e)
        //{
        //    //Get the Input File Name and Extension.
        //    string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
        //    string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

        //    //Build the File Path for the original (input) and the encrypted (output) file.
        //    string input = Server.MapPath("~/Files/") + fileName + fileExtension;
        //    string output = Server.MapPath("~/Files/") + fileName + "_enc" + fileExtension;

        //    //Save the Input File, Encrypt it and save the encrypted file in output path.
        //    FileUpload1.SaveAs(input);
        //    this.Encrypt(input, output);

        //    //Download the Encrypted File.
        //    Response.ContentType = FileUpload1.PostedFile.ContentType;
        //    Response.Clear();
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(output));
        //    Response.WriteFile(output);
        //    Response.Flush();

        //    //Delete the original (input) and the encrypted (output) file.
        //    File.Delete(input);
        //    File.Delete(output);

        //    Response.End();
        //}
        //protected void DecryptFile(object sender, EventArgs e)
        //{
        //    //Get the Input File Name and Extension
        //    string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
        //    string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

        //    //Build the File Path for the original (input) and the decrypted (output) file
        //    string input = Server.MapPath("~/Files/") + fileName + fileExtension;
        //    string output = Server.MapPath("~/Files/") + fileName + "_dec" + fileExtension;

        //    //Save the Input File, Decrypt it and save the decrypted file in output path.
        //    FileUpload1.SaveAs(input);
        //    this.Decrypt(input, output);

        //    //Download the Decrypted File.
        //    Response.Clear();
        //    Response.ContentType = FileUpload1.PostedFile.ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(output));
        //    Response.WriteFile(output);
        //    Response.Flush();

        //    //Delete the original (input) and the decrypted (output) file.
        //    File.Delete(input);
        //    File.Delete(output);

        //    Response.End();
        //}
    }
}
