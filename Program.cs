class Program
{
    static void Main()
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        string testData1 = "superligaen";
        ProcessLeague.ProcessTestData(testData1);
    }
}