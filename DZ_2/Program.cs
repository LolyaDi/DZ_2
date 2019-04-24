namespace DZ_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataAccessLayer = new DataAccessLayer();

            string result = dataAccessLayer.CreateGroupsTable();

            System.Console.WriteLine(result);
            System.Console.ReadLine();
        }
    }
}
