using System;

namespace TestRating
{
    public class Policy
    {

        public PolicyType Type { get; set; }

        #region General Policy Prop
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        #endregion
        
        public virtual bool Validate()
        {
            return true;
        }

        public virtual decimal Rate()
        {
            return 0;
        }
        /*
        #region Life Insurance
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        #endregion

        #region Travel
        public string Country { get; set; }
        public int Days { get; set; }
        #endregion

        #region Health
        public string Gender { get; set; }
        public decimal Deductible { get; set; }
        #endregion
        */
    }

    public class TravelPolicy : Policy
    {
        public string Country { get; set; }
        public int Days { get; set; }

        public TravelPolicy ()
	    {
            Console.WriteLine("Rating TRAVEL policy...");
	    }

        public override bool Validate()
        {
            Console.WriteLine("Validating policy.");

            if (Days <= 0)
            {
                Console.WriteLine("Travel policy must specify Days.");
                return false;
            }
            if (Days > 180)
            {
                Console.WriteLine("Travel policy cannot be more then 180 Days.");
                return false;
            }
            if (String.IsNullOrEmpty(Country))
            {
                Console.WriteLine("Travel policy must specify country.");
                return false;
            }
            return true;
        }

        public override decimal Rate()
        {
            var rate = Days * 2.5m;
            if (Country == "Italy")
            {
                rate *= 3;
            }
            return rate;
        }
    }

    public class LifeInsurancePolicy : Policy
    {
        public LifeInsurancePolicy ()
	    {
            Console.WriteLine("Rating Life policy...");

	    }

        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }

        public override bool Validate()
        {
            Console.WriteLine("Validating policy.");

            return base.Validate();
        }

        public override decimal Rate()
        {
            return base.Rate();
        }
    }

    public class HealthPolicy : Policy
    {
        public HealthPolicy ()
	    {
            Console.WriteLine("Rating HEALTH policy...");
	    }

        public string Gender { get; set; }
        public decimal Deductible { get; set; }

        public override bool Validate()
        {
             Console.WriteLine("Validating policy.");

             if (String.IsNullOrEmpty(Gender))
             {
                Console.WriteLine("Health policy must specify Gender");
                return false;
             }
             return true;
        }

        public override decimal Rate()
        {
            var rating = 0m;
            if (Gender == "Male")
            {
                if (Deductible < 500)
                {
                    rating = 1000m;
                }
                else
                {
                    rating = 900m;
                }
            }
            else // Women
            {
                if (Deductible < 800)
                {
                    rating = 1100m;
                }
                else
                {
                    rating = 1000m;
                }
            }

            return rating;
        }
    }
}
