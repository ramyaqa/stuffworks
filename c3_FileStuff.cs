using System;
using System.IO;
using System.Text;

namespace StuffWorks
{

    public static class c3_FileStuff
    {

        /// <summary>
        /// This method opens a file and read all the contents into a string variable and returns them to the 
        /// calling function
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFileIntoString(string filePath)
        {
            /// Here fileContent is the variable name. Usually variable names should be camel case. 
            /// example thisIsAGoodVariableName. Note the first character is lower case and all the other words first 
            /// character is in UPPERCASE
            string fileContent = File.ReadAllText(filePath);

            return fileContent;

            /// ************    SOME SCENARIOS WHERE IT IS USEFUL **********
            /// It may not be asked in interview but you can use in coding if you know the file is SMALL. 
            /// For simple problems that you need to use a string. Example if they ask you to reverse a file or copy the contents. 
        }

        /// <summary>
        /// This method opens a file and reads all the contents into an array of strings and not just one string. 
        /// For example if the file contains 5 lines, it opens and copies the contents into an array of 5 strings 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[] ReadFileLineByLine(string filePath)
        {
            /// Here fileContent is the variable name. Usually variable names should be camel case. 
            /// example thisIsAGoodVariableName
            string[] fileContent = File.ReadAllLines(filePath);

            return fileContent;

            /// ************    SOME SCENARIOS WHERE IT IS USEFUL **********
            /// It may not be asked in interview but you can use in coding if you know the file is SMALL. 
            /// For simple problems that you need to use a string array. Example if you are manipulating a list of users or test data that you
            /// need to feed into the program
        }

        /// <summary>
        /// Sometimes the file is too big. Consider a English dictionary that is copied into a file and
        /// lets assume the file is 10 GB in size (size of two DVD movies)
        /// In such cases it is technically not possible to copy the contents into a string or array of strings
        /// as there is a space limitation of every program. It can occupy only some amount of space. In a 2 GB RAM machine, 
        /// technically a program can copy up to 2 GB although it could be less. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFileAsStream(string filePath)
        {
            //Initialize string where we want to copy the file content to.
             string fileContent = string.Empty;

            ///One way to overcome this limitation is that, you read the file in parts.
            ///In order to read in parts, you need to open an stream (like a pipe) to the file
            ///with a pointer to the current location of the last read. As you read the pointer moves
            ///forward. There is one issue. You cannot read it character by character, but it is only 
            ///available as bytes. so you read byte by byte and convert it into character.
            ///
            ///Because you are opening the stream you need to manage it. you should open it, read it and close it. 
            ///Failure to do so will have unwanted side effects. C# provides a best practice to automatically open and close. 
            ///The keyword is "using"
            ///

            //"using" manages the object inside ( ). In our case it is "fs" object of type FileStream that streams the 
            //underlying content, in our case it is the file. If you use "using" keyword you do not have to worry about managing resources
            //This is one effective way of preventing memory leak.
            using (FileStream fs = File.OpenRead(filePath))
            {
               

                //you can read byte by byte or in chunks. reading byte by byte is slow, and chunk is usually
                //more performant. Think like movie streams where content is read in chunks and stored in local
                //"buffering" in that case attempts to read contents in chunks. 
                byte[] buffer = new byte[1024]; //setup a 1 KB byte array. 1024 bytes = 1 KB.

                //Tell more about the content of the file. Lets have a separate exercise for that. 
                //For now assume it is UTF8, other popular encoding is ASCII
                UTF8Encoding myFileEncoding = new UTF8Encoding(true);

                ///It is a good practice to right click on sytem defined keywords and methods 
                ///to understand what it does and what are the parameters. Google FileStream and look 
                ///for Read method. 
                ///Here we are using the Read method to read the file stream from last read location
                ///first parameter is the buffer to which the read contents are temporarily written
                ///the second parameter is called offset. it says this is how much we should skip before starting to read again
                ///the third parameter is count, number of bytes to read. as we set above we try to read 1024 bytes. 
                ///
                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    //use the encoding to convert the bytes to string.
                    string stringRepresentationOfBuffer = myFileEncoding.GetString(buffer);

                    //bingo there you have the read chunk. use it. Add all the buffers into a big string.
                    fileContent += stringRepresentationOfBuffer;


                    /// *************** What does the file content contain **********************/
                    /// As you know file contents may vary with different files. A txt document could contain plain text, whereas a microsoft
                    /// word document may contain proprietary content for word. An image will have a encoded chars.
                    /// EXERCISE :: Open a word document in notepad and see what it has
                    /// EXERCISE :: Open an image (gif or jpeg) in notepad (not editor) to see the contents.

                    /// ************    SOME SCENARIOS WHERE IT IS USEFUL **********
                    /// When you hear LARGE file, use this scenario. This is a good approach to 
                    /// solve LARGE file problems
                    /// 
                    /// 1. Search a string in a Large file. 
                    /// 2. Search a string in a Large file from the end. In this case, you will first go to the end of the file 
                    ///    and begin reading.  fs.Seek(0, SeekOrigin.End)
                    /// 3. Read every 5th character in the string. Example as string of "ABCDEFGHIJKLMNOP" should return EJO (every 5th char)
                    ///    In this case, you simply set a buffer to size 1, then set the offset to 4. (ie., REad current location, move 4 bytes etc)
                    ///    fs.Read(buffer, 4, buffer.Length)
                    /// 4. Find how many occurances of the word "and" is there in the file. A file with content, jack and jill went up the hill and fetched" returns 2. 
                    ///    It cannot the solved by just using this, but a combination. Example you should read in chunks and search for and. A better way to do is using
                    ///    REgex but we can deal with it later
                }
            }

            return fileContent;

        }

        /// <summary>
        /// This method takes a string of contents and writes all the contents into a file specified. The file name should
        /// be a filename or the full path. Example of full path is "c:\users\ramya\desktop\samplefile.txt". If no path is provided
        /// (ie., samplefile.txt), then the file is written to the same directory as this program. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void WriteStringIntoFile(string contentToWrite, string fileNameToWriteWithPath)
        {
            File.WriteAllText(fileNameToWriteWithPath, contentToWrite);

            /// ************    SOME SCENARIOS WHERE IT IS USEFUL **********
            /// It may not be asked in interview but you can use in coding if you know the file content is SMALL. 
        }

        /// <summary>
        /// This method takes a string of contents and writes all the contents into a file specified. The file name should
        /// be a filename or the full path. Example of full path is "c:\users\ramya\desktop\samplefile.txt". If no path is provided
        /// (ie., samplefile.txt), then the file is written to the same directory as this program.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void WriteStringArrayIntoFile(string[] arrayContentToWrite, string fileNameToWriteWithPath)
        {
            File.WriteAllLines(fileNameToWriteWithPath, arrayContentToWrite);

            /// ************    SOME SCENARIOS WHERE IT IS USEFUL **********
            /// It may not be asked in interview but you can use in coding if you know the file content is SMALL. 
        }


        public static void WriteStreamToFile(string filePath, FileStream fs)
        {
            using (fs = File.Create(filePath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

        }


    }
}
