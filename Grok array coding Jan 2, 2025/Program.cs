using System;
//using System.Reflection.Metadata.Ecma335;

class WeatherStation // recall that a class is a blueprint for creating objects 
{
    private string _location;
    private int[] _temperatures; // Array declaration. see below for private vs public:
    /*
     * When you declare a member (like a field or method) as private, it means this member can only be accessed within that class. 
     * No other class can see or interact with it unless through a public interface.
     * _temperatures is private because we don't want external code to directly manipulate the array of temperatures. This prevents
     * accidental or unauthorized changes to the temperature data.
     */

    // property with get and set functions
    public string Location // you need to get clear on the difference between: _location & Location 
    // Remember, in the set methods, value is a keyword used by C# to denote the value being assigned to the property
    // which is automatically provided when you set a property.
    {
        get { return _location;}
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _location = value; // SEE ABOVE COMMENTARY ON THE GETTER AND SETTER 
            }
        }
    }
    // Property for temperatures array
    public int[] Temperatures // YOU NEED TO GET CLEAR ON THE PUBLIC VS PRIVATE INSTANCES OF THIS....
    // Also the above is NOT an array - this is confusing BUT the [] only signifies an array when ALSO declaring a variable
    // In the above we are not declaring a variable actually but instead indicating the property being dealt with here
    // acceps as input an array of integers 
    { 
        get { return _temperatures;}
        set
        {
            if (value != null)
            { 
                _temperatures = new int[value.Length]; // THIS IS NEW. FIGURE IT OUT 
                Array.Copy(value, _temperatures, value.Length); // THIS IS NEW. FIGURE IT OUT 
            }
        }
    }
    //method to calculate average temperature
    public double CalculateAverageTemperature()
    {
        if (_temperatures == null || _temperatures.Length == 0)
        { 
            return 0;
        }
        double sum = 0; // Is this just an initial declaration
        foreach (int temp in _temperatures)
        { 
            sum += temp;
        }
        return sum / _temperatures.Length; // need to look into what this is doing
    }
    // method to simulate a day passing
    public void SimulateDayPassing()
    { 
        Random random = new Random();
        if (_temperatures != null && _temperatures.Length > 0)
        {
            for (int i = _temperatures.Length - 1; i > 0; i--) // I DO NOT KNOW WHAT THE -- IS AFTER THE i is that a decrement?
            {
                _temperatures[i] = _temperatures[i - 1]; // Holy shit some wild stuff is happening here
            }
            _temperatures[0] = random.Next(-10, 35);
        }
    }
    // The constructor. Find out why termed the constructor
    public WeatherStation(string location, int days)
    { 
        Location = location;
        Temperatures = new int[days]; // Check if correct? Temperatures is tied to days? ALSO IS THIS AN ARRAY??
    }
}
class Program
{
    static void Main()
    {
        WeatherStation station = new WeatherStation("Vancouver", 7); // WHAT IS THE 7 ???
        Console.WriteLine($"Weather for {station.Location}:");
        // simulate a weeks weather
        for (int i = 0; i < 7; i++)
        { 
            station.SimulateDayPassing();
            Console.WriteLine($"Day {i + 1}: {station.Temperatures[0]} C");
        }
        Console.WriteLine($"Average Temperature: {station.CalculateAverageTemperature():F2} C");
    }
}