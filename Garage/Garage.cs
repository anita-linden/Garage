using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class Garage<T> : IEnumerable<T>
        where T : IVehicle
    {
        private T[] vehicle;

        public Garage(int size)
        {
            vehicle = new T[size];
        }

        public Garage(int size, T[] vehicles) : this(size)
        {
            vehicles.CopyTo(vehicle, 0);
        }

        public IEnumerable<T> ListVehicles()
        {
            foreach (T v in vehicle)
            {
                yield return v;
            }
        }

        public string[] ListVehiclesByType()
        {
            Hashtable vehicleCount = new Hashtable();

            foreach (T v in vehicle)
            {
                string type = v.GetType().ToString();
                if (vehicleCount.ContainsKey(type))
                {
                    vehicleCount[type] = (int)vehicleCount[type]+1;
                }
                else
                {
                    vehicleCount.Add(type, 1);
                }
            }

            string[] value = new string[vehicleCount.Count];

            int i = 0;
            foreach (var key in vehicleCount.Keys)
            {
                value[i] = key + ": " + vehicleCount[key];
                i++;
            }
            return value;
        }

        public T FindVehicle(string registration)
        {
            foreach (T v in vehicle)
            {
                if (registration.ToLower()==v.RegistryNr.ToLower())
                {
                    return v;
                }
            }

            throw new ArgumentException("Registry does not exist");
        }

        public IEnumerable<T> FindVehicles(Type type = null , string color = "", int nrOfWheels = -1)
        {
            foreach (T v in vehicle)
            {
                if (type is null || v.GetType().Equals(type))
                    if (color == "" || v.Color.ToLower() == color.ToLower())
                        if (nrOfWheels > -1 || nrOfWheels == v.NrOfWheels)
                            yield return v;
            }

            throw new ArgumentException("Nothing by those parameters");
        }

        public void AddVehicle(T v)
        {
            for (int i = 0; i < vehicle.Length;i++)
            {
                if (vehicle[i] is null)
                {
                    vehicle[i] = v;
                    return;
                }
            }
        }

        public void RemoveVehicle(string registration)
        {
            for (int i = 0; i < vehicle.Length; i++)
            {
                if (vehicle[i].RegistryNr==registration)
                {
                    for (;i<vehicle.Length;i++)
                    {
                        vehicle[i] = vehicle[i + 1];
                    }
                    IVehicle.RemoveRegistry(registration);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T v in vehicle)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
