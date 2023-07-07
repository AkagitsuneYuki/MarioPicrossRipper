using System;

namespace MarioPicrossRipper
{
    internal class Picross
    {

        private byte[] puzzleData;
        private byte   width;
        private byte   height;

        public byte[] PuzzleData
        {
            get { return puzzleData; }
        }

        public Picross(byte[] data)
        {
            if(data.Length != 32)   //all picross puzzles must be 32 bytes
            {
                throw new ArgumentException("Invalid size of data!");
            }

            //index 30 is the width of the puzzle, it must be 5, 10, or 15
            if(data[30] != 5)   //this is pretty sloppy but it'll do for now
            {
                if(data[30] != 10)
                {
                    if (data[30] != 15)
                    {
                        throw new ArgumentException("Invalid picross dimensions!");
                    }
                }
            }

            //the puzzle matrix is 240 bytes in game, though most are unused
            puzzleData = new byte[240];

            for (int i = 0; i < 30; i++) //for every byte
            {
                byte dataByte = data[i];
                //Console.WriteLine(dataByte);

                if (dataByte != 0)   //don't waste time working on the bytes that are all 0
                {
                    for (int n = 0; n < 8; n++)  //for every bit of the byte
                    {
                        //each bit gets its own byte                                    //the byte is shifted left by n bits
                        puzzleData[n + i * 8] = (byte)(((dataByte << n) & 0xff) >> 7);  //then and it with 255 to remove the unused bits
                                                                                        //finally shift the byte right by 7 to get 1 or 0
                    }
                }
            }
            width  = data[30];
            height = data[31];
        }

    }
}
