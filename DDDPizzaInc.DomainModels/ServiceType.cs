using System.Globalization;
using DDDPizzaInc.SharedKernel;

namespace DDDPizzaInc.DomainModels
{
    public class ServiceType : Enumeration
    {
        private ServiceType(int value, string displayName) : base(value, displayName){}

        public ServiceType(){}

        public static readonly ServiceType InRestaurant = new InRestaurantType();
        public static readonly ServiceType TakeOut = new TakeOutType();
        public static readonly ServiceType Delivery = new DeliveryType();

        public virtual decimal CalculateTotal(ServiceType serviceType)
        {
            return 0.00m;
        }

        public override string ToString()
        {
            return DisplayName.ToString(CultureInfo.InvariantCulture);
        }

        public sealed class InRestaurantType : ServiceType
        {
            public InRestaurantType() : base(1, "InRestaurant") { }

            public override decimal CalculateTotal(ServiceType serviceType)
            {
                return 0.00m;
            }

        }

        public sealed class TakeOutType : ServiceType
        {
            public TakeOutType() : base(2, "TakeOut") { }

            public override decimal CalculateTotal(ServiceType serviceType)
            {
                return 0.00m;
            }
          
        }

        public sealed class DeliveryType : ServiceType
        {
            public DeliveryType() : base(3, "Delivery") { }

            public override decimal CalculateTotal(ServiceType serviceType)
            {
                return 2.00m;
            }
           
        }

    }
}