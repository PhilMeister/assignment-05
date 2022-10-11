using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
        }

        public void UpdateItem(List<Item> items)
        {
            UpdateQuality(items);
            UpdateSellin(items);

        }

        private void UpdateQuality(List<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            if (items[i].Name == "Conjured Mana Cake")
                            {
                                items[i].Quality = items[i].Quality - 2;
                            }
                            else { items[i].Quality = items[i].Quality - 1; }
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }


            }
        }

        private void UpdateSellin(List<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != "Aged Brie")
                    {
                        if (items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}