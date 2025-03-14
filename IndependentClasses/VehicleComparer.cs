using Vehicles;

namespace IndependentClasses
{
    public static class VehicleComparer 
    {
        public static void SortByPrice(Vehicle[] vehicles)
        {
            bool swapped;

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < vehicles.Length - 1 - i; j++)
                {
                    if (vehicles[j].Price > vehicles[j + 1].Price)
                    {
                        Vehicle temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void SortBySpeed(Vehicle[] vehicles)
        {
            bool swapped;

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < vehicles.Length - 1 - i; j++)
                {
                    if (vehicles[j].Speed > vehicles[j + 1].Speed)
                    {
                        Vehicle temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void SortByType(Vehicle[] vehicles)
        {
            bool swapped;

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < vehicles.Length - 1 - i; j++)
                {
                    if (string.Compare(vehicles[j].VehicleType, vehicles[j + 1].VehicleType) > 0)
                    {
                        Vehicle temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}