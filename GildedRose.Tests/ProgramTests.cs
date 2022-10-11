namespace GildedRose.Tests;

public class ProgramTests
{
    List<Item> items = new List<Item>();


    Program app = new Program();
    public ProgramTests()
    {

        items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          };
    }

    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void UpdateItemBrieIncreasesValue()
    {
        //Arrange
        var expected = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
        var cheeseItem = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        //Act
        app.UpdateItem(cheeseItem);
        //Assert
        Assert.Equal(expected[0].Quality, cheeseItem[0].Quality);
    }

    [Fact]
    public void ConcertAfterDateHas0Quality()
    {
        //Arrange
        var expected = new List<Item> {new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 0
                } };
        var concertItem = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                }};

        //Act        
        for (int i = 0; i < 6; i++)
        {
            app.UpdateItem(concertItem);
        }

        //Assert
        Assert.Equal(expected[0].Quality, concertItem[0].Quality);

    }



    [Fact]
    public void ConsertEndsTomorrowHighQualityToday()
    {
        var bsPasslst = new List<Item>{new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                }};

        var expected = new List<Item>{new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 47
                }};

        for (int i = 0; i < 14; i++)
        {
            app.UpdateItem(bsPasslst);
        }

        Assert.Equal(expected[0].Quality, bsPasslst[0].Quality);
    }

    [Fact]
    public void CallUpdateItemOnSulfurasQualityRemainsTheSame()
    {
        //Arrange
        var SulfurasLst = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        //Act
        app.UpdateItem(SulfurasLst);
        //Assert
        Assert.Equal(80, SulfurasLst[0].Quality);
    }


    [Fact]
    public void ConjuredDecreasedbyTwo()
    {
        //Arrange
        var expected = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 4 } };
        var conLst = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };

        //Act
        app.UpdateItem(conLst);


        Assert.Equal(expected[0].Quality, conLst[0].Quality);
    }

    [Fact]
    public void ItemPassesSellByDateDegradesTwiceAsFast()
    {
        var expected = new List<Item> { new Item { Name = "Normal", SellIn = 3, Quality = 8 } };
        var conLst = new List<Item> { new Item { Name = "Normal", SellIn = 3, Quality = 15 } };

        for (int i = 0; i < 5; i++)
        {
            app.UpdateItem(conLst);
        }

        Assert.Equal(expected[0].Quality, conLst[0].Quality);
    }


    [Fact]
    public void NeverNegative()
    {
        var expected = new List<Item> { new Item { Name = "Best Item", SellIn = 4, Quality = 0 } };
        var negList = new List<Item> { new Item { Name = "Best Item", SellIn = 4, Quality = 2 } };

        app.UpdateItem(negList);
        app.UpdateItem(negList);
        app.UpdateItem(negList);
        app.UpdateItem(negList);

        Assert.Equal(expected[0].Quality, negList[0].Quality);
    }

    [Fact]
    public void NotMoreThan50()
    {
        //Arrange
        var expected = new List<Item> { new Item { Name = "Aged Brie", SellIn = 20, Quality = 50 } };
        var cheeseItem = new List<Item> { new Item { Name = "Aged Brie", SellIn = 22, Quality = 49 } };
        //Act
        app.UpdateItem(cheeseItem);
        app.UpdateItem(cheeseItem);
        //Assert
        Assert.Equal(expected[0].Quality, cheeseItem[0].Quality);
    }

    [Fact]
    public void CallUpdateItemOnSulfurasSellInRemainsTheSame()
    {
        //Arrange
        var SulfurasLst = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 80 } };
        //Act
        app.UpdateItem(SulfurasLst);
        //Assert
        Assert.Equal(3, SulfurasLst[0].SellIn);
    }

    [Fact]
    public void UpdateItemBrieDecreasesSellin()
    {
        //Arrange
        var expected = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
        var cheeseItem = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        //Act
        app.UpdateItem(cheeseItem);
        //Assert
        Assert.Equal(expected[0].SellIn, cheeseItem[0].SellIn);
    }

    [Fact]
    public void regularItemDecresedbyOne()
    {
        var expected = new List<Item> { new Item { Name = "Best Item", SellIn = 4, Quality = 3 } };
        var bestList = new List<Item> { new Item { Name = "Best Item", SellIn = 5, Quality = 4 } };

        app.UpdateItem(bestList);

        Assert.Equal(expected[0].Quality, bestList[0].Quality);
        Assert.Equal(expected[0].SellIn, bestList[0].SellIn);
    }

    [Fact]
    public void UpdateItemBrieIncreasesValueAfterSellin()
    {
        //Arrange
        var expected = new List<Item> { new Item { Name = "Aged Brie", SellIn = -8, Quality = 4 } };
        var cheeseItem = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 1 } };
        //Act
        app.UpdateItem(cheeseItem);
        app.UpdateItem(cheeseItem);
        app.UpdateItem(cheeseItem);
        //Assert
        Assert.Equal(expected[0].SellIn, cheeseItem[0].SellIn);
    }



}