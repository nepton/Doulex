using Doulex;

namespace UnitTest.Doulex.Extensions;

public class EnumExtensionsTester
{
    [EnumTextResource(typeof(I18n))]
    public enum Color
    {
        Red,
        [EnumText("ET_GREEN")] Green,
        Yellow,
    }

    public enum Vehicle
    {
        [EnumText("CAR")] Car,
        Truck,
    }

    [Fact]
    public void Text_WhenInvoke_ShouldReturn()
    {
        Assert.Equal("RED", Color.Red.Text());
        Assert.Equal("ET_GREEN", Color.Green.Text());
        Assert.Equal("Yellow", Color.Yellow.Text());
        
        Assert.Equal("CAR", Vehicle.Car.Text());
        Assert.Equal("Truck", Vehicle.Truck.Text());
    }
}
