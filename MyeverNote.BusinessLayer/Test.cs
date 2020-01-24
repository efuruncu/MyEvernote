using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyeverNote.BusinessLayer
{
    public class Test
    {
        Repository<Category> repo_category = new Repository<Category>();
        Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        Repository<Comment> repo_comment = new Repository<Comment>();
        Repository<Note> repo_note = new Repository<Note>();
        public Test()
        {
            // //Eğer database veritabanında mevcut değilse oluştur.
            // MyEverNote.DataAccessLayer.DatabaseContext db = new MyEverNote.DataAccessLayer.DatabaseContext();
            ////Database ile birlikte verilerinde oluşması için select sorgusununda çalışması gerekiyor.
            // db.Categories.ToList();

            List<Category> categories = repo_category.List();
        }

        public void InsertTest()
        {

            int result = repo_user.Insert(new EvernoteUser()
            {
                Name = "Ahmet",
                Surname = "gdgkjdlkg",
                Email = "ahmetdgf@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "ahmet",
                Password = "111",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "ahmet"
            });
        }

        public void UpdateTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "ahmet");

            if (user != null)
            {
                user.Username = "ali";
                int result = repo_user.Update(user);
            }

        }

        public void DeleteTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "ali");
            if (user != null)
            {
                int result = repo_user.Delete(user);
            }

        }
        public void CommentTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Id == 1);
            Note note = repo_note.Find(x => x.Id == 3);
            Comment comment = new Comment()
            {
                Text = "Bu bir testtir.",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "eliffuruncu",
                Note = note,
                Owner = user
            };
            repo_comment.Insert(comment);
        }
    }
}
