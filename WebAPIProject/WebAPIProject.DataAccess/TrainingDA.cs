using System;
using System.IO;
using System.Threading.Tasks;
using WebAPIProject.Entities;

namespace WebAPIProject.DataAccess
{
    public class TrainingDA
    {

        #region Public Members

        public async Task<bool> SaveTraining(Training training)
        {
            string dbName = "TrainingDatabase.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }
            using (var dbContext = new MyDbContext())
            {
                //Ensure database is created
                await dbContext.Database.EnsureCreatedAsync();
      
                    dbContext.Trainings.Add(new Training
                        {
                        TrainingName =training.TrainingName,
                        StartDate = training.StartDate,
                        EndDate = training.EndDate,
                    });
                    await dbContext.SaveChangesAsync();
               

            }
            return true;
        }

        #endregion
    }
}
