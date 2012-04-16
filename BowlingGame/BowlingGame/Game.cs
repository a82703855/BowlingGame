using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    public class Game
    {
        private int score = 0;
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        private int currentFrame = 1;
        private bool isFirstRoll = true;

        public void roll(int pins)
        {

           // score += pins;
            rolls[currentRoll++] = pins;
            AdjustCurrentFrame(pins);

        }

        private void AdjustCurrentFrame(int pins)
        {
            if (isFirstRoll)
            {
                if (pins == 10)
                {
                    currentFrame++;
                }
                else
                {
                    isFirstRoll = false;
                }
            }
            else
            {
                isFirstRoll = true;
                currentFrame++;
            }
            if (currentFrame > 11)
            {
                currentFrame = 11;
            }
        }

        public int Score()
        {
            //int score = 0;
            //int frameIndex = 0;
            //for (int frame = 0; frame < 10; frame++)
            //{
            //    if (isStrike(frameIndex))//strike
            //    {
            //        score = 10 + strikeBonus(frameIndex);
            //        frameIndex++;
            //    }
            //    else if (isSpare(frameIndex))//补中spare
            //    {
            //        score += 10 + spareBonus(frameIndex);
            //        frameIndex += 2;
            //    }
            //    else
            //    {
            //        score += sumOfBallsInFrame(frameIndex);
            //        frameIndex += 2;
            //    }
                
                
            //}
            //return score;

            return ScoreForFrame(CurrentFrame - 1);
        }

        private int sumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int spareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int strikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];

        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        public int ScoreForFrame(int theFrame)
        {
            int score1 = 0;
            int ball = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                int firstRoll = rolls[ball++];
                if (firstRoll == 10)
                {
                    score1 += 10 + rolls[ball] + rolls[ball + 1];
                }
                else
                {
                    int secondRoll = rolls[ball++];
                    int frameScore = firstRoll + secondRoll;
                    if (frameScore == 10)
                    {
                        score1 += frameScore + rolls[ball];
                    }
                    else
                    {
                        score1 += frameScore;
                    }
                }
            }
            return score1;
        }

        public int CurrentFrame 
        { 
            get { return currentFrame; } 
        }
    }
}
