﻿using System;

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
            if (!IsValidSize(data[30])){
                throw new ArgumentException("Invalid picross dimensions!");
            }

            DecodePuzzle(data);
        }

        private bool IsValidSize(int size)
        {
            if(size % 5 == 0)
            {
                int divisor = size / 5;

                if (divisor >= 1 && divisor <= 3)
                {
                    return true;
                }
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
