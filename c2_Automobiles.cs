using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Note the new name space . Note the name space in other files where it is stuff works. Name space is like a bag. 
// you have to use the bag using using statement. Q: what is the other way you can use "using" keyword? 
namespace Automobiles
{
    /// <summary>
    /// What is a class? 
    ///     Class can be related to real world objects. Any object in real world (plant, animal, table, school) etc are good
    ///     candidates for class
    /// What can a class contain?
    ///     Class can contain Members. Members are also referred to as Fields
    ///     Class can contain Properties
    ///     Class can contain Methods
    ///     Class can contain Events / Delegates
    ///     Class can contain (0 or more) Constructor. This is the first method called when you create an instance of the class. 
    ///     Class can contain (0 or 1) Destructor. This is the last method called after you do your work and no longer need your class. EXERCISE: When does that occur?
    /// Members or Fields:
    ///     They are the basic components that describe more about a class. 
    /// Properties:
    ///     They are the also basic components that describe more about a class.  They are mostly wrapper for a member or field. A property must expose at least one getter get { ... } or setter set { ... }
    ///         get { ... } returns the value specified inside the get { } code. 
    ///         set { ... } assigns a value to the component inside the set { } code.
    ///         Normally, all readable AND writable properties contain a get and set
    ///         READ ONLY contains just the getter
    ///         WRITE ONLY (rarely used because methods are better suited) contains just setter
    /// Methods: 
    ///     Methods are functions that does something. 
    ///     Methods may return a value or nothing. 
    ///     Methods that returns a value
    ///         If a method returns a value, you need to specify a type of the value returned. Example:  string GetMake() returns the make of the car where make is a string type
    ///     Method that does some work but do not return anything
    ///         If a methods returns nothing, you need to specify a "void". Example: void StartMyCar() return nothing but could do a lot of things like starting the car.
    ///         
    /// 
    /// What is an Object?
    ///     This is the ultimate base class of all classes in the .NET Framework. The Object (note the upper case "O" in Object) is of type object (note the lower case "o" in object)
    ///     
    /// What is object type?
    ///     The object type is the base type for the base class Object. It is the base for all primitive type and user defined types.
    ///     
    /// What is Primitive type?
    ///     .NET language has preset types that are common. Examples are int, decimal, float, datetime, string, boolean etc. Some of them are value types. Some are reference type.
    ///     
    /// What is a value type?
    ///     value type are types whose the actual value is passed around when working with it. this means that the size is known and fixed. 
    ///    
    /// What is reference type?
    ///     reference type are types whose reference (ie., memory address) is passed around when working with it. 
    /// 
    /// What is a Type?
    ///     Type describes
    /// </summary>

    public class Car
    {
        //no access indicator (public/private) defaults to private. Good for variables and methods
        string _make;
        string _model;
        int _year;

        public string Make
        {
            get
            {
                return _make;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public int Age
        {
            get
            {
                //difference between year in today's date and the actual year of the car. 
                //EXERCISE: what happens to age when the car's year is same as this year.
                return System.DateTime.Today.Year - _year;
            }
        }

        protected FuelType fuelType;

        public Car(string make, string model, int year)
        {
            _make = make;
            _model = model;
            _year = year;
        }

        public string GetMake()
        {
            return _make;
        }

        public string GetModel()
        {
            return _model;
        }

    }

    public class HondaCar : Car
    {
        internal EngineType engineType;
        public HondaCar(string model, int year): base("Honda", model, year)
        {
            fuelType = FuelType.Gasoline;
        }

        public FuelType Fuel
        {
            get
            {
                return fuelType;
            }
        }
    }

    public static class HondaCompany
    {
        public static string GetCompanyName() { return "Honda"; }

        public static HondaCar ManufactureCivic()
        {
            HondaCar hondaCivic = new HondaCar("Civic", 2013);
            hondaCivic.engineType = EngineType.Mechanical;
            return hondaCivic;
        }

        public static List<HondaCar> ManufactureCivic(int NumberOfCars)
        {
            List<HondaCar> civics = new List<HondaCar>();
            for (int i = 0; i < NumberOfCars; i++)
            {
                HondaCar hondaCivic = new HondaCar("Civic", 2013);
                hondaCivic.engineType = EngineType.Mechanical;
                civics.Add(hondaCivic);
            }
            return civics;
        }

        public static HondaCar ManufactureCivicHybrid()
        {
            HondaCar hondaCivicHybrid = new HondaCar("Civic", 2013);
            hondaCivicHybrid.engineType = EngineType.Hybrid;
            return hondaCivicHybrid;
        }
    }

    public enum EngineType
    {
        Mechanical=0,
        Hybrid
    }

    public enum FuelType
    {
        Gasoline = 0, //If you set this to 0, all other will increment from 0
        Diesel,
        NaturalGas,
        Electricity
    }


}
