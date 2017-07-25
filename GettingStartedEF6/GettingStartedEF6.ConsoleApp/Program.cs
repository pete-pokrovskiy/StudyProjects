using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GettingStartedEF6.DataModel;
using GettingStartedEF6.Domain;

namespace GettingStartedEF6.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<GettingStartedContext>());

            CreateUser();
            //GetAllUsers();
            //CreateEmailWithAttachemnts();
            //GetEmailAndUpdateOneOfTheAttachments();
        }

        private static void CreateUser()
        {
            var user = new User
            {
                Name = "first normal user",
                EmailAddress = "normal@mail.ru"
            };

            using (var context = new GettingStartedContext())
            {
                context.Database.Log = info => Console.WriteLine(info);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }


        private static void GetAllUsers()
        {

            using (var context = new GettingStartedContext())
            {
                context.Database.Log = Console.WriteLine;

                var users = context.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Id);
                }
            }
        }


        private static void GetEmailAndUpdateOneOfTheAttachments()
        {
            Email email;

            using (var context = new GettingStartedContext())
            {
                email = context.Emails.Find(new Guid("24ad2d85-5d54-e711-8716-e4a7a0350353"));
            }
            Console.WriteLine($"Got email with subject: {email.Subject}");

            var firstAttachment = email.Attachments.FirstOrDefault();

            if (firstAttachment == null)
                Console.WriteLine("first attachment is null");
            else
            {
                Console.WriteLine($"first attachment name: {firstAttachment.FileName}");
            }
        }


        static void CreateEmailWithAttachemnts()
        {

            var user = new User
            {
                Name = "Pete",
                EmailAddress = "pete@email.com"
            };


            Email email = new Email
            {
                Body = "test body",
                Subject = "test subject",
                Importance = EmailImportance.High,
                ToStr = "test@email.com",
                //Author = user,
                Attachments = new List<Attachment>
                {
                    new Attachment
                    {
                        FileName = "testfile.xml",
                        FileType = FileType.Image,
                        FileSize = 300
                    },
                    new Attachment
                    {
                        FileName = "testfile.xml",
                        FileType = FileType.Image,
                        FileSize = 300
                    },
                    new Attachment
                    {
                        FileName = "testfile.xml",
                        FileType = FileType.Image,
                        FileSize = 300
                    }
                }
            };

            using (var context = new GettingStartedContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Users.Add(user);
                context.Emails.Add(email);
                context.SaveChanges();
            }
        }

        //TODO: попробовать конструкцию: context.Entry(..).CurrentValues.SetValues(...)
    }
}
