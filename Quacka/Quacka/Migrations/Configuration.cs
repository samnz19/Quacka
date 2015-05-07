using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Quacka.Models;

namespace Quacka.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quacka.Models.ApplicationDbContext>
    {
        private DateTime _start = new DateTime(2005, 1, 1);
        private Random _random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private DateTime RandomDateTime()
        {
            int minutesRange = (DateTime.Now - _start).Minutes;
            int daysRange = (DateTime.Now - _start).Days;
            var quackDate = _start.AddMinutes(_random.Next(minutesRange));
            return quackDate.AddDays(_random.Next(daysRange));
        }
        
        protected override void Seed(Quacka.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!(context.Users.Any(u => u.UserName == "sam@quacka.com")))
            {
                var userToInsert = new ApplicationUser { UserName = "sam@quacka.com", Quacks = new List<Quack>
                {
                    new Quack { Body = "If you've ever been quite the picture? : re: carhenge... think I'm a washboard to say thanks... your.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Sitting here laughing at Cal's INTENSE expression in New Zealand | Gains Is killing your book is?", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Re: carhenge... think I'm a great shot of hate when people change the trip. Maria, my mighty heart is.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Blog post? Yes please! Still waiting for supporting New Zealand | Please ReTweet - See more to more!", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Thanks for us to see content on biology, it's sure to pink... Happy birthday! OMG! Glad you're all ok.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "What a lot of his kid brother. Protective instinct! : Wishing night shift didn't leave me Just wanted to!", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Thanks for Amazon to document his chapter on nitrous.io! Sign Up now watch Netflix in celebrating a wreck?", CreatedAt = RandomDateTime() },
                    new Quack { Body = "I can now and get 250MB free space: is too much for internet disconnection based on biology, it's sure to.", CreatedAt = RandomDateTime() }
                }};
                userManager.Create(userToInsert, "password");
            } 

            if (!(context.Users.Any(u => u.UserName == "sean@quacka.com")))
            {
                var userToInsert = new ApplicationUser { UserName = "sean@quacka.com", Quacks = new List<Quack>
                {
                    new Quack { Body = "I know you don't care. Beach tomorrow anyone? Why so serious", CreatedAt = RandomDateTime() },
                     new Quack { Body = "Right person, wrong time. Can't go home alone again. Me but as an owl", CreatedAt = RandomDateTime() },
                    new Quack { Body = "When the muskrat writes When the dog thrives When I'm feeling squared I simply remember my favorite things And then I don't feel so prepared", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Squat puckish premiums loved up with plaques These are a few of my favorite kickbacks", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Washouts on wardens and adjuncts on islands Stringed bumpy returns and loose leaky highlands", CreatedAt = RandomDateTime() },
                    new Quack { Body = "A good strategy for Germany is to score quickly on Brazil, then take Argentina, Peru, and Venezuela and enjoy two extra armies per turn.", CreatedAt = RandomDateTime() },
                }};
                userManager.Create(userToInsert, "password");
            }

            if (!(context.Users.Any(u => u.UserName == "olivia@quacka.com")))
            {
                var userToInsert = new ApplicationUser
                {
                    UserName = "olivia@quacka.com",
                    Quacks = new List<Quack>
                {
                    new Quack { Body = "Individual players are strictly barred from prolonged gyrations.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "And I was right then, and I was right yesterday, and I'm right today.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "I am the Benny Goodman of dangling modifiers.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "a caterpillar is a steed: brown-gray and unwitting", CreatedAt = RandomDateTime() },
                    new Quack { Body = "Nathan's Hot Dog Eating Contest? More like Nathan's Hot Blog Eating Contest, amirite?", CreatedAt = RandomDateTime() },
                }};
                userManager.Create(userToInsert, "password");
            }

            if (!(context.Users.Any(u => u.UserName == "rich@quacka.com")))
            {
                var userToInsert = new ApplicationUser
                {
                    UserName = "rich@quacka.com",
                    Quacks = new List<Quack>
                {
                    new Quack { Body = "Someone to provide for you proper grammar I love the smell of I despise. Ask your mother with morals MFA shotgunning beers", CreatedAt = RandomDateTime() },
                    new Quack { Body = "I'm a nice guy, my beard performance art other shenanigans skydiving for real though. Snapchat I'm too lazy to keep typing", CreatedAt = RandomDateTime() },
                    new Quack { Body = "The best things in life spoil the broth. A rolling stone is your oyster. When the cat’s away the mice come in small packages.", CreatedAt = RandomDateTime() },
                    new Quack { Body = "The road to hell is where the heart is.", CreatedAt = RandomDateTime() },
                }};
                userManager.Create(userToInsert, "password");
            } 
        }
    }
}
