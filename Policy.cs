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

        public override bool Validate()
        {
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
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }

        public override bool Validate()
        {
            return base.Validate();
        }

        public override decimal Rate()
        {
            return base.Rate();
        }
    }

    public class HealthPolicy : Policy
    {
        public string Gender { get; set; }
        public decimal Deductible { get; set; }

        public override bool Validate()
        {
            return base.Validate();
        }

        public override decimal Rate()
        {
            return base.Rate();
        }
    }
}
