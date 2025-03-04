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

        public byte Width
        {
            get { return width; }
        }
        public byte Height
        { 
            get { return height; }
        }

        public Picross(byte[] data)
        {
            //various integrity checks
            //these should never trigger in normal use unless the ROM is modified
            if(data.Length != 32)
            {
                throw new ArgumentException("Invalid size of data! Data block must be 32 bytes. Received block " + data.Length.ToString() + " byte(s)!");
            }
            if (!IsValidSize(data[30])){
                throw new ArgumentException("Invalid picross dimensions! Width and height must be 5, 10, or 15; but got " + data[30].ToString() + "!");
            }
            if(data[30] != data[31])
            {
                throw new ArgumentException("Invalid picross dimensions! Width and Height do not match!");
            }

            DecodePuzzle(data);
        }

        private bool IsValidSize(int size)
        {
            if(size == 5 || size == 10 || size == 15)
            {
                return true;
            }
            return false;
        }

        private void DecodePuzzle(byte[] data)
        {
            //the puzzle matrix is 240 bytes in game, though most are unused
            puzzleData = new byte[240];

            for (int byteIndex = 0; byteIndex < 30; byteIndex++) //for every byte
            {
                byte dataByte = data[byteIndex];

                if (dataByte != 0)   //don't waste time working on the bytes that are all 0
                {
                    for (int bits = 0; bits < 8; bits++)  //for every bit of the byte
                    {
                        //each bit gets its own byte                                                    //the byte is shifted left by n bits
                        puzzleData[bits + byteIndex * 8] = (byte)(((dataByte << bits) & 0xff) >> 7);    //then and it with 255 to remove the unused bits
                                                                                                        //finally shift the byte right by 7 to get 1 or 0
                    }
                }
            }
            width = data[30];
            height = data[31];
        }

    }
}
