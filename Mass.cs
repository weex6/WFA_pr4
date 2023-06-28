using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_pr4
{
    internal class Mass<T>
    {
        // создание массивов с помощью рандома
        Random randMass = new Random();
        public T[] CreateArray(T[] MassArray, int rand_a, int rand_b)
        {
            dynamic randA = rand_a;
            dynamic randB = rand_b;
            MassArray = new T[13];
            for (int i = 0; i < 13; i++)
            {
                MassArray[i] = randMass.Next(randA, randB);
            }
            return MassArray;
        }
        public T[] CreateArrayDouble(T[] MassArray, T rand_a, T rand_b)
        {
            dynamic randA = rand_a;
            dynamic randB = rand_b;
            MassArray = new T[13];
            for (int i = 0; i < 13; i++)
            {
                MassArray[i] = randMass.NextDouble()*(randA - randB) + randB;
            }
            return MassArray;
        }

        // сортировка выбором
        public void SortByChoise(T[] MassArray)
        {
            dynamic mas = MassArray;
            for (int i = 0; i < 13; i++)
            {
                int min = i;
                for (int j = i + 1; j < 13; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                T temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }

        }

        // сортировка слиянием
        public void Merge(T[] MassArray, int lowIndex, int middleIndex, int highIndex)
        {
            dynamic mas = MassArray;
            int left = lowIndex;
            int right = middleIndex + 1;
            var tempArray = new T[highIndex - lowIndex + 1];
            int index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (mas[left] < mas[right])
                {
                    tempArray[index] = mas[left];
                    left++;
                }
                else
                {
                    tempArray[index] = mas[right];
                    right++;
                }
                index++;
            }

            for (int i = left; i <= middleIndex; i++)
            {
                tempArray[index] = mas[i];
                index++;
            }
            for (int i = right; i <= highIndex; i++)
            {
                tempArray[index] = mas[i];
                index++;
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                mas[lowIndex + i] = tempArray[i];
            }
        }
        public T[] MergeSort(T[] MassArray, int lowIndex, int highIndex)
        {
            int middleIndex=(lowIndex+highIndex)/2;
            dynamic mas = MassArray;
            if (lowIndex < highIndex)
            {
                MergeSort(mas, lowIndex, middleIndex);
                MergeSort(mas, middleIndex + 1, highIndex);
                Merge(MassArray, lowIndex, middleIndex, highIndex);
            }
            return MassArray;
        }
        public T[] MergeSort(T[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
    }
}
