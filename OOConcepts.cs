using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/***** check this namespace Automobiles in Automobiles.cs file *****/
using Automobiles;

namespace StuffWorks
{

    public class OOConcepts
    {
        /*********** BEFORE YOU BEGIN ************/
        /// EXERCISE 1. Read AND Review Automobile class 
        /// EXERCISE 2. How many classes are there in Automobile.cs?
        /// EXERCISE 3. How many public classes are there in Automobile.cs?
        /// EXERCISE 4. List out all the public, private, internal, protected classes and tell me the difference?


        ///Uncomment the commented lines // and see which ones give compile error (How to compile? press ctrl + b or ctrl + shift + b)
        ///Do not remove /* */ as they are help text for you.
        public static void TestAccessControl()
        {
            /* This line should give a compile error as it cannot find Honda Company class. Fix in next line */ 
            //HondaCar civic = HondaCompany.ManufactureCivic();

            /* Fix in next line */ 
            //Automobiles.HondaCar hondaCivic = Automobiles.HondaCompany.ManufactureCivic(); 

            /* Alternatively try adding the "using Automobiles" in the top of the program below other using statements */
            HondaCar civic = HondaCompany.ManufactureCivic();
            
            /*Try accessing Fuel property and setting it here */
            //civic.Fuel = FuelType.Diesel;
        }

        public static void CreateAHondaCar()
        {
            HondaCar hondacar = new HondaCar("tvs50", 2010); //bad.. because we are letting the user to create any model. 

            HondaCar hondaCivic = HondaCompany.ManufactureCivic();  // good way, because the user is not allowed to meddle with the properties. 
            string makeOfHondaCivic = hondaCivic.GetMake(); //this returns honda civic. there is no way you can modify it. 

            List<HondaCar> hondaCivics = HondaCompany.ManufactureCivic(1000000); /* generate a million cars */
            
        }

    }

}
