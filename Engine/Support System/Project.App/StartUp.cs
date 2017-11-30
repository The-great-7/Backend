namespace Project.App
{
    using System;

    using Project.Data;

    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ResetDatabase();
        }

        private static void ResetDatabase()
        {
            using (var context = new ProjectDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
    }
}
