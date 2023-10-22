using LinkedListImplementation;

namespace MyListTest;

public class Tests
{
    private MyList<int> numberList;
    [SetUp]
    public void Setup()
    {
        numberList = new MyList<int>();
    }

    [Test]
    public void TestAddAndCount()
    {
        Assert.That(numberList.IsEmpty, Is.True);
        numberList.Add(1);
        Assert.That(numberList, Has.Count.EqualTo(1));
        Assert.That(numberList.First, Is.EqualTo(1));
        Assert.That(numberList.Last, Is.EqualTo(1));
    }
}