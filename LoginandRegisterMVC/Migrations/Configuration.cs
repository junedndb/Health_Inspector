namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoginandRegisterMVC.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoginandRegisterMVC.Models.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.ClinicFacilitiess.AddOrUpdate(l => l.Id,
                 new Models.ClinicFacilities() { Service = "OPD" },
                 new Models.ClinicFacilities() { Service = "Dental Facility" },
                 new Models.ClinicFacilities() { Service = "Dressing Room" },
                 new Models.ClinicFacilities() { Service = "Physiotherypy" },
                 new Models.ClinicFacilities() { Service = "Laboratory services" },
                 new Models.ClinicFacilities() { Service = "Ambulance" },
                 new Models.ClinicFacilities() { Service = "ECG services" }
);
            context.Specialities.AddOrUpdate(l => l.Id,
            new Models.Speciality() { Speciality_name = "Family Physician" },
            new Models.Speciality() { Speciality_name = "Internal Medicine Physician" },
            new Models.Speciality() { Speciality_name = "Pediatrician" },
            new Models.Speciality() { Speciality_name = "Obstetrician" },
            new Models.Speciality() { Speciality_name = "Surgeon" },
            new Models.Speciality() { Speciality_name = "Psychiatrist" },
            new Models.Speciality() { Speciality_name = "Neurologist" }
);
            context.Localities.AddOrUpdate(l => l.LocalityId,
new Models.Locality() { Locality_name = "pune" },
new Models.Locality() { Locality_name = "Mumbai" },
new Models.Locality() { Locality_name = "Nashik" },
new Models.Locality() { Locality_name = "Delhi" }
);

            context.FeedbackQuestions.AddOrUpdate(l => l.QuestionId,
           new Models.FeedbackQuestion() { FeedBackQuestion = "Are you Satisy with Treatment" },
           new Models.FeedbackQuestion() { FeedBackQuestion = "How did you find the experience of booking appointments?" },
           new Models.FeedbackQuestion() { FeedBackQuestion = "Were you satisfied with the doctor you were allocated with?" },
           new Models.FeedbackQuestion() { FeedBackQuestion = "How easy is it to navigate our facility?" }


);
        }
    }
}
