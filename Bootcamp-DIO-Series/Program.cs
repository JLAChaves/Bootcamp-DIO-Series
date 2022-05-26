using Bootcamp_DIO_Series.Entities;
using Bootcamp_DIO_Series.Entities.Enum;
using Bootcamp_DIO_Series.Repositories;

SeriesRepository seriesRepository = new SeriesRepository();

string userOption = GetUserOption();

while (userOption.ToUpper() != "X")
{
    switch (userOption)
    {
        case "1":
            ListSeries();
            break;
        case "2":
            InsertSeries();
            break;
        case "3":
            UpdateSeries();
            break;
        case "4":
            DeleteSeries();
            break;
        case "5":
            ReturnByIdSeries();
            break;
        case "C":
            Console.Clear();
            break;

        default:
            throw new ArgumentOutOfRangeException();
    }
    userOption = GetUserOption();
}
Console.WriteLine("Thank you for use our services");

void ReturnByIdSeries()
{
    Console.Write("Type id of Series: ");
    int idSeries = int.Parse(Console.ReadLine());

    var series = seriesRepository.ReturnById(idSeries);
    Console.WriteLine(series);
}

void DeleteSeries()
{
    Console.Write("Type id of Series: ");
    int idSeries = int.Parse(Console.ReadLine());

    seriesRepository.Delete(idSeries);
}

void UpdateSeries()
{
    Console.Write("Insert Id of Series: ");
    int idSeries = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Gener)))
    {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Gener), i)}");
    }
    Console.WriteLine();
    Console.Write("Enter the genre between the options above: ");
    int enterGener = int.Parse(Console.ReadLine());

    Console.Write("Type the Title of Series: ");
    string enterTitle = Console.ReadLine();

    Console.Write("Type the Year of creation of the Series: ");
    int enterYear = int.Parse(Console.ReadLine());

    Console.Write("Type the Description of the Series: ");
    string enterDescription = Console.ReadLine();

    Series newSeries = new Series(id: idSeries,
                                  gener: (Gener)enterGener,
                                  title: enterTitle,
                                  year: enterYear,
                                  description: enterDescription);

    seriesRepository.Update(idSeries, newSeries);
}
void ListSeries()
{
    Console.WriteLine("List Series");

    var list = seriesRepository.List();

    if (list.Count == 0)
    {
        Console.WriteLine("No Series Registered ");
        return;
    }

    foreach (var series in list)
    {
        Console.WriteLine($"#Id {series.ReturnId()}: - {series.ReturnTitle()}"); 
    }
}

void InsertSeries()
{
    Console.WriteLine("Insert New Series");

    foreach (int i in Enum.GetValues(typeof(Gener)))
    {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Gener), i)}");
    }
    Console.WriteLine();
    Console.Write("Enter the genre between the options above: ");
    int enterGener = int.Parse(Console.ReadLine());

    Console.Write("Type the Title of Series: ");
    string enterTitle = Console.ReadLine();

    Console.Write("Type the Year of creation of the Series: ");
    int enterYear = int.Parse(Console.ReadLine());

    Console.Write("Type the Description of the Series: ");
    string enterDescription = Console.ReadLine();

    Series newSeries = new Series(id: seriesRepository.NextId(),
                                  gener: (Gener)enterGener,
                                  title: enterTitle,
                                  year: enterYear,
                                  description: enterDescription);
    seriesRepository.Insert(newSeries);
}

static string GetUserOption()
{
    Console.WriteLine();
    Console.WriteLine("Inform the Option: ");
    Console.WriteLine();

    Console.WriteLine("1 - List Series");
    Console.WriteLine("2 - Insert New Series");
    Console.WriteLine("3 - Update Series");
    Console.WriteLine("4 - Delete Series");
    Console.WriteLine("5 - View Series");
    Console.WriteLine("C - Clean Screen");
    Console.WriteLine("X - Exit");

    string userOption = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return userOption;

}
