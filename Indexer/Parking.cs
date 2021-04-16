using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Parking : IEnumerable
    {
        private const int MAX_CARS = 100;
        private List<Car> Cars { get; set; } = new List<Car>();
        public int Count { get { return Cars.Count(); } }
        public string Name { get; set; }

        public Car this[string number]
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(number))
                {
                    throw new ArgumentNullException();
                }
                var car = Cars.FirstOrDefault(car => car.NumberPlate == number);
                return car;
            } 
        }

        public Car this[int position]
        {
            get
            {
                if (position > -1 && position < Cars.Count)
                {
                    return Cars[position];
                }
                return null;
            }
        }

        public int Add(Car car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car), "Car isn't exist");
            }
            if (Cars.Count < MAX_CARS)
            {
                Cars.Add(car);
                return Count - 1;
            }

            return -1;
        }
        public void GoOut(string number) 
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number), "Number is null or empty");
            }

            var car = Cars.FirstOrDefault(car => car.NumberPlate == number);
            if (car is not null)
            {
                Cars.Remove(car);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Cars.GetEnumerator();
        }

        public IEnumerable GetNames() 
        {
            foreach (var car in Cars)
            {
                yield return car.Name;
                yield return car.Name;
            }
        }
    }

    public class ParkungEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
