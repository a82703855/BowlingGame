using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;



[TestClass]
public class BowlingGameTest
{
    private Game g;

    public BowlingGameTest()
    {
        g = new Game();
    }




    [TestMethod]
    public void testGutterGame()
    {
        // Game g = new Game();
        //int n = 20;
        //int pins = 0;
        rollMany(20, 0);
        Assert.AreEqual(0, g.Score());
    }

    private void rollMany(int n, int pins)
    {
        for (int i = 0; i < n; i++)
        {
            g.roll(pins);
        }
    }

    [TestMethod]
    public void testAllOnes()
    {
        rollMany(20, 1);
        Assert.AreEqual(20, g.Score());
    }

    [TestMethod]
    public void testRolls()
    {

        g.roll(5);
        g.roll(4);
        g.roll(7);
        g.roll(2);
        Assert.AreEqual(18, g.Score());
        Assert.AreEqual(9, g.ScoreForFrame(1));
        Assert.AreEqual(18, g.ScoreForFrame(2));
        Assert.AreEqual(3, g.CurrentFrame);
    }

    [TestMethod]
    public void testOneSpare()
    {
        roolSpare();
        g.roll(3);

        Assert.AreEqual(13, g.Score());
        Assert.AreEqual(13, g.ScoreForFrame(1));
        Assert.AreEqual(2, g.CurrentFrame);
    }
    [TestMethod]
    public void testFrameAfterSpare()
    {
        roolSpare();
        g.roll(3);
        g.roll(2);

        Assert.AreEqual(18, g.Score());
        Assert.AreEqual(13, g.ScoreForFrame(1));
        Assert.AreEqual(18, g.ScoreForFrame(2));

        Assert.AreEqual(3, g.CurrentFrame);
    }

    [TestMethod]
    public void testOneStrike()
    {
        rollStrike(); //全中strike
        g.roll(3);
        g.roll(4);
        rollMany(16, 0);
        Assert.AreEqual(24, g.Score());
    }

    [TestMethod]
    public void testHeartBreak()
    {
        for (int i = 0; i < 11; i++)
        {
            g.roll(10);
        }
        g.roll(9);
        Assert.AreEqual(299, g.Score());
    }

    private void rollStrike()
    {
        g.roll(10);
    }

    private void roolSpare()
    {
        g.roll(5);
        g.roll(5);
    }
    [TestMethod]
    public void TestPerfectGame()
    {
        for (int i = 0; i < 12; i++)
        {
            g.roll(10);
        }
        Assert.AreEqual(300, g.Score());
        Assert.AreEqual(11, g.CurrentFrame);



    }
    [TestMethod]
    public void TestTenthTrameSpare()
    {
        for (int i = 0; i < 9; i++)
        {
            g.roll(10);
        }
        g.roll(9);
        g.roll(1);
        g.roll(1);
        Assert.AreEqual(270, g.Score());
    }

}