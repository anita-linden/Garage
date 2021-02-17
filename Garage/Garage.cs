using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    class Garage<T> : IEnumerable<T>
        where T : IVehicle
    {
        private T[] vehicle;

        public int Size => vehicle.Length;
        public T this[int index] => vehicle[index];

        
        public Garage(int size)
        {
            vehicle = new T[size];
        }

        public Garage(int size, T[] vehicles) : this(size)
        {
            vehicles.CopyTo(vehicle, 0);
        }

        // LINQ istället
        public List<T> ListVehicles()
        {

            //List<T> list = new List<T>();
            //foreach (T v in vehicle)
            //{
            //    list.Add(v);
            //}

            //return list;
            return vehicle.ToList();
            

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

        // LINQ
        public T FindVehicle(string registration)
        {
            //foreach (T v in vehicle)
            //{
            //    if (registration.ToLower()==v.RegistryNr.ToLower())
            //    {
            //        return v;
            //    }
            //}

            //throw new ArgumentException("Registry does not exist");
            try
            {
                return vehicle.FirstOrDefault(v => v.RegistryNr == registration);
            }
            catch (Exception)
            {
                Console.WriteLine("ajabaja");
                throw;
            }

        }

        public List<T> FindVehicles(string type = "", int nrOfWheels = -1, string color = "")
        {
            //List<T> list = new List<T>();
            //foreach (T v in vehicle)
            //{
            //    if (type == "" || v.Type.Equals(type))
            //        if (color == "" || v.Color.ToLower().Equals(color.ToLower()))
            //            if (nrOfWheels <= -1 || nrOfWheels == v.NrOfWheels)
            //                list.Add(v);
            //}

            var query = vehicle.Select(v => v);

            if(type != "") { query = query?.Where(v => v.Type == type); }
            if(nrOfWheels != -1) { query = query?.Where(v => v.NrOfWheels == nrOfWheels); }
            if(color != "") { query = query?.Where(v => v.Color == color); }

            var list = query.ToList();

            if (list.Count > 0)
                return list;
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
                        vehicle[i].Delete();
                        vehicle[i] = vehicle[i + 1];
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Nullcheck
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
