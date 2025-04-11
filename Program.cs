using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Linq;

class Program
{
    static void Main()
    {

        Double[] voltage = {0,166.34,331.08,
  492.63,
  649.44,
  799.99,
  942.83,
  1076.60,
  1200.00,
  1311.84,
  1411.05,
  1496.67,
  1567.88,
  1623.98,
  1664.45,
  1688.88,
  1697.06,
  1688.88,
  1664.45,
  1623.98,
  1567.88,
  1496.67,
  1411.05,
  1311.84,
  1200.00,
  1076.60,
  942.83,
  799.99,
  649.44,
  492.63,
  331.08,
  166.34,
  0.00,
  -166.34,
  -331.08,
  -492.63,
  -649.44,
  -799.99,
  -942.83,
  -1076.60,
  -1200.00,
  -1311.84,
  -1411.05,
  -1496.67,
  -1567.88,
  -1623.98,
  -1664.45,
  -1688.88,
  -1697.06,
  -1688.88,
  -1664.45,
  -1623.98,
  -1567.88,
  -1496.67,
  -1411.05,
  -1311.84,
  -1200.00,
  -1076.60,
  -942.83,
  -799.99,
  -649.44,
  -492.63,
  -331.08,
  -166.34,
  0,
  166.34,
  331.08,
  492.63,
  649.44,
  799.99,
  942.83,
  1076.60,
  1200.00,
  1311.84,
  1411.05,
  1496.67,
  1567.88,
  1623.98,
  1664.45,
  1688.88,
  1697.06,
  1688.88,
  1664.45,
  1623.98,
  1567.88,
  1496.67,
  1411.05,
  1311.84,
  1200.00,
  1076.60,
  942.83,
  799.99,
  649.44,
  492.63,
  331.08,
  166.34,
  0.00,
  -166.34,
  -331.08,
  -492.63,
  -649.44,
  -799.99,
  -942.83,
  -1076.60,
  -1200.00,
  -1311.84,
  -1411.05,
  -1496.67,
  -1567.88,
  -1623.98,
  -1664.45,
  -1688.88,
  -1697.06,
  -1688.88,
  -1664.45,
  -1623.98,
  -1567.88,
  -1496.67,
  -1411.05,
  -1311.84,
  -1200.00,
  -1076.60,
  -942.83,
  -799.99,
  -649.44,
  -492.63,
  -331.08,
  -166.34,
  0,
  166.34,
  331.08,
  492.63,
  649.44,
  799.99,
  942.83,
  1076.60,
  1200.00,
  1311.84,
  1411.05,
  1496.67,
  1567.88,
  1623.98,
  1664.45,
  1688.88,
  1697.06,
  1688.88,
  1664.45,
  1623.98,
  1567.88,
  1496.67,
  1411.05  };

        int n = 64;
        var (list1, list2, list3, list4) = Phasor_Angle(n, voltage);

        for (int i = 0; i < list4.Count; i++)
        {
            Console.WriteLine(list4[i]);

        }
        int z=list4.Count;
        Console.WriteLine(z);


    }

    static (List<double>, List<double>, List<double>, List<double>) Phasor_Angle(int n, double[] values)
    {
        List<double> phasor_angle = Enumerable.Repeat(0.0, n).ToList();      //For phasor angle
        List<double> fundamental_magnitude = Enumerable.Repeat(0.0, n).ToList();         //For fundamental magnitude
        List<double> Thd = Enumerable.Repeat(0.0, n).ToList();      //for THD
        List<double> rms = Enumerable.Repeat(0.0, n).ToList(); //for rms
      
        List<double> second_harmonic = new List<double>();      //for second harmonic   
        List<double> third_harmonic = new List<double>();       //for third harmonic
        List<double> fifth_harmonic = new List<double>();       //for fifth harmonic
        
        List<double> cosine = new List<double>();    //for the calculation of pahsor angle
        List<double> sine = new List<double>();     //for the calculation of pahsor angle
        List<double> cosine_for_second_harmonic = new List<double>();
        List<double> sine_for_second_harmonic = new List<double>();
        List<double> cosine_for_third_harmonic = new List<double>();
        List<double> sine_for_third_harmonic = new List<double>();
        List<double> cosine_for_fifth_harmonic = new List<double>();
        List<double> sine_for_fifth_harmoinc = new List<double>();

        int s = values.Length;

        for (int i = 0; i < n; i++)
        {
            double cos = Math.Cos(2 * Math.PI * i / n);
            double sin = Math.Sin(2 * Math.PI * i / n);
            double cos_2 = Math.Cos(4 * Math.PI * i / n);
            double sin_2 = Math.Sin(4 * Math.PI * i / n);
            double cos_3 = Math.Cos(6 * Math.PI * i / n);
            double sin_3 = Math.Sin(6 * Math.PI * i / n);
            double cos_5 = Math.Cos(10 * Math.PI * i / n);
            double sin_5 = Math.Sin(10 * Math.PI * i / n);
            cosine.Add(cos);
            sine.Add(sin);
            cosine_for_second_harmonic.Add(cos_2);
            sine_for_second_harmonic.Add(sin_2);
            cosine_for_third_harmonic.Add(cos_3);
            sine_for_third_harmonic.Add(sin_3);
            cosine_for_fifth_harmonic.Add(cos_5);
            sine_for_fifth_harmoinc.Add(sin_5);
        }

        for (int i = 0; i < values.Length - n; i++)
        {
            double cossum = 0;
            double sinsum = 0;
            double cossum_2 = 0;
            double sinsum_2 = 0;
            double cossum_3 = 0;
            double sinsum_3 = 0;
            double cossum_5 = 0;
            double sinsum_5 = 0;
            double sum = 0; //for rms
            for (int j = 0; j < n; j++)
            {
                double cosresult = values[i + j] * cosine[j];
                double sinresult = values[i + j] * sine[j];
                double cosresult_2 = values[i + j] * cosine_for_second_harmonic[j];
                double sinresult_2 = values[i + j] * sine_for_second_harmonic[j];
                double cosresult_3 = values[i + j] * cosine_for_third_harmonic[j];
                double sinresult_3 = values[i + j] * sine_for_third_harmonic[j];
                double cosresult_5 = values[i + j] * cosine_for_fifth_harmonic[j];
                double sinresult_5 = values[i + j] * sine_for_fifth_harmoinc[j];
                cossum += cosresult;
                sinsum += sinresult;
                cossum_2 += cosresult_2;
                sinsum_2 += sinresult_2;
                cossum_3 += cosresult_3;
                sinsum_3 += sinresult_3;
                cossum_5 += cosresult_5;
                sinsum_5 += sinresult_5;
                sum += values[i + j] * values[i + j];

            }

            double rmsresult = Math.Sqrt(sum / n); // rms calculation
            rms.Add(rmsresult);
            double real = (cossum * Math.Sqrt(2)) / n;
            double image = (sinsum * Math.Sqrt(2)) / n;
            double real2 = (cossum_2 * Math.Sqrt(2)) / n;
            double image2 = (sinsum_2 * Math.Sqrt(2)) / n;
            double real3 = (cossum_3 * Math.Sqrt(2)) / n;
            double image3 = (sinsum_3 * Math.Sqrt(2)) / n;
            double real5 = (cossum_5 * Math.Sqrt(2)) / n;
            double image5 = (sinsum_5 * Math.Sqrt(2)) / n;
            //Console.WriteLine("Image: " + image);
            double funda_magnitude = Math.Sqrt(Math.Pow(real, 2) + Math.Pow(image, 2));
            fundamental_magnitude.Add(funda_magnitude);
          
            double second = Math.Sqrt(Math.Pow(real2, 2) + Math.Pow(image2, 2));
            second_harmonic.Add(second);
            double third = Math.Sqrt(Math.Pow(real3, 2) + Math.Pow(image3, 2));
            third_harmonic.Add(third);
            double fifth = Math.Sqrt(Math.Pow(real5, 2) + Math.Pow(image5, 2));
            fifth_harmonic.Add(fifth);
            double result = -Math.Atan2(image, real) * (180 / Math.PI);
            if (result < 0)
            {
                result = 360 + result;
            }

            phasor_angle.Add(result);


        }

        for (int i = 0; i < values.Length - n; i++)
        {
            double thd = 100 * (Math.Sqrt((Math.Pow(second_harmonic[i], 2) + Math.Pow(third_harmonic[i], 2) + Math.Pow(fifth_harmonic[i], 2))) / fundamental_magnitude[i+n]);

            Thd.Add(thd);
        }
        return (second_harmonic, phasor_angle, Thd, rms);
    }



}
