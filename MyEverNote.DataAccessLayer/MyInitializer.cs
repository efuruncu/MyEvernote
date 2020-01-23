using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEverNote.Entities;

namespace MyEverNote.DataAccessLayer
{
    class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "Elif",
                Surname = "Furuncu",
                Email = "eliffuruncu.ef@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "eliffuruncu",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "eliffuruncu"
            };

            EvernoteUser standartUser = new EvernoteUser()
            {
                Name = "Emir",
                Surname = "Furuncu",
                Email = "emirfrncu.ef@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "emirfuruncu",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "eliffuruncu"
            };
            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartUser);

            context.SaveChanges();

            //Adding fake categories
            for(int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "eliffuruncu"
                };

                for(int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    Note note = new Note()
                    {
                        Title=FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5,25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1,3)),
                        Category=cat,
                        IsDraft=false,
                        LikeCount=FakeData.NumberData.GetNumber(10,50),
                        Owner=(k % 2 == 0) ? admin : standartUser,
                        CreatedOn=FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        ModifiedOn= FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername= (k % 2 == 0) ? admin.Username : standartUser.Username
                    };
                    cat.Notes.Add(note);
                }
            }

        }
    }
}
