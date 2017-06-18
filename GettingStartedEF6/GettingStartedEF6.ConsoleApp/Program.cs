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
            //CreateEmailWithAttachemnts();
            GetEmailAndUpdateOneOfTheAttachments();
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
            Email email = new Email
            {
                Body = "test body",
                Subject = "test subject",
                Importance = EmailImportance.High,
                ToStr = "test@email.com",
                Author = new User
                {
                    Name = "Pete",
                    EmailAddress = "pete@email.com"
                },
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
                context.Emails.Add(email);
                context.SaveChanges();
            }
        }
    }
}
