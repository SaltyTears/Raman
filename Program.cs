using System.Diagnostics;
using test;

string filename = @"C:\Users\Bob\Desktop\test\ST1_Lignin_HT_1.CSV";
StreamReader reader = new StreamReader(@filename);

string result = Path.GetFileName(filename);
System.Console.WriteLine("\n" + $" File - {result}" + "\n");

// Lists to store split Raman Intensity & Raman shift Range
List<double> D_value_shift = new List<double>();
List<double> D_value_intensity = new List<double>();
List<double> G_value_shift = new List<double>();
List<double> G_value_intensity = new List<double>();
List<double> D2_value_shift = new List<double>();
List<double> D2_value_intensity = new List<double>();

var cache_line = 1.2;
var cache_line2 = 1.2;

while(!reader.EndOfStream) {
    
    var cache_read = reader.ReadLine().Split(",");
    cache_line = Convert.ToDouble(cache_read[0]);
    cache_line2 = Convert.ToDouble(cache_read[1]);
    //D Peak Loop
    if ( cache_line > 1300 && cache_line < 1400)
    {
        D_value_shift.Add(Convert.ToDouble(cache_line));
        D_value_intensity.Add(Convert.ToDouble(cache_line2));
    }
    //G peak loop
        if ( cache_line > 1401 && cache_line < 1700)
    {
        G_value_shift.Add(Convert.ToDouble(cache_line));
        G_value_intensity.Add(Convert.ToDouble(cache_line2));
    }
    // 2D peak loop
        if ( cache_line > 2500 && cache_line < 3000)
    {
        D2_value_shift.Add(Convert.ToDouble(cache_line));
        D2_value_intensity.Add(Convert.ToDouble(cache_line2));
    }
}

System.Console.WriteLine($" D peak - {D_value_shift[D_value_intensity.IndexOf(D_value_intensity.Max())]} - {D_value_intensity.Max()}");
System.Console.WriteLine($" G peak - {G_value_shift[G_value_intensity.IndexOf(G_value_intensity.Max())]} - {G_value_intensity.Max()}");
System.Console.WriteLine($"2D peak - {D2_value_shift[D2_value_intensity.IndexOf(D2_value_intensity.Max())]} - {D2_value_intensity.Max()}");
System.Console.WriteLine($"Id / Ig - {String.Format("{0:0.00}",(D_value_intensity.Max()/G_value_intensity.Max()))}");

