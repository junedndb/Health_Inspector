using LoginandRegisterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace LoginandRegisterMVC.Controllers
{


    public class BMIAndRecommendationsController : Controller
    {
        private UserContext context = new UserContext();



        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ADD()
        {
            BMI bMI = new BMI();
            return View(bMI);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ADD(BMI bMI)
        {


            bMI.BMIResult = bMI.Weight / ((bMI.Height * 0.3048) * (bMI.Height * 0.3048));

            bMI.UserId = (int)HttpContext.Session["Id"];

            if (ModelState.IsValid)
            {
                ViewBag.BMIResult = Math.Round(bMI.BMIResult, 2);
                context.BMIs.Add(bMI);
                context.SaveChanges();
            }
            return View(bMI);
        }


        [HttpGet]
        [Authorize]
        public ActionResult DietRecommendation()
        {
            BMI bMI = new BMI();
            return View(bMI);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DietRecommendation([Bind(Include = "Height,Weight")] BMI bMI)
        {
            DietRecommendation dietRecommendation = new DietRecommendation();
            bMI.BMIResult = bMI.Weight / ((bMI.Height * 0.3048) * (bMI.Height * 0.3048));





            if (bMI.BMIResult < 18.5)
            {
                ViewBag.Weightcategory = "Underweight";
                ViewBag.DietRecommendation = "Adding extra ingredients that are high in calories to regular diet, for example, including eggs and bananas in morning breakfast, etc., can help in increasing the weight.";
                ViewBag.ExerciseRecommendation = "Strength training keeps your muscles strong and can help you build mass. Muscle actually weighs more than fat, so if you're interested in gaining weight, strength training is a great way to do so, and it will make you look less gaunt. Try exercise machines such as a leg press or rowing machine at the gym, or lift weights daily.";
                dietRecommendation.Recommendation = ViewBag.Weightcategory + " \n" + ViewBag.DietRecommendation;

            }
            else if (bMI.BMIResult > 18.5 && bMI.BMIResult < 24.9)
            {
                ViewBag.Weightcategory = "Optimal";
                ViewBag.DietRecommendation = "Hydrate your body. Drinking enough liquids (especially water) is critical to maintaining overall health, but also may help you reach your ideal weight.";
                ViewBag.ExerciseRecommendation = "Walking is simple, yet powerful. It can help you stay trim, improve cholesterol levels, strengthen bones, keep blood pressure in check, lift your mood, and lower your risk for a number of diseases (diabetes and heart disease, for example). A number of studies have shown that walking and other physical activities can even improve memory and resist age-related memory loss.";
                dietRecommendation.Recommendation = ViewBag.Weightcategory + " \n" + ViewBag.DietRecommendation;
            }


            else if (bMI.BMIResult > 25 && bMI.BMIResult < 29.9)
            {
                ViewBag.Weightcategory = "OverWeight";
                ViewBag.DietRecommendation = "Always stick to healthy snacks, such as a hard-cooked egg, Greek yogurt, some whole grain crackers or ¼ cup of raisins. Never skip meals as that can affect your working results and maybe make you eat more next meal.";
                ViewBag.ExerciseRecommendation = "Jumping Jacks not only help  lose weight, but also increase our heart rate, so they are perfect to include in our warm-up.Jumping rope is also one of the best activities to burn calories, but it also allows  to get a flat stomach, gain strength and endurance.";
                dietRecommendation.Recommendation = ViewBag.Weightcategory + " \n" + ViewBag.DietRecommendation;
            }
            else if (bMI.BMIResult > 30)
            {
                ViewBag.Weightcategory = "Obese";
                ViewBag.DietRecommendation = "Avoid fried and oily foods. The best diet for  obese people should contain foods that have healthy fat in them. To get the right amount of healthy fats, try to include olive oil, avocado, nuts, and fatty fish.";
                ViewBag.ExerciseRecommendation = "Strength training keeps your muscles strong and can help you build mass. Muscle actually weighs more than fat, so if you're interested in gaining weight, strength training is a great way to do so, and it will make you look less gaunt. Try exercise machines such as a leg press or rowing machine at the gym, or lift weights daily.";
                dietRecommendation.Recommendation = ViewBag.Weightcategory + " \n" + ViewBag.DietRecommendation + "\n" + ViewBag.ExerciseRecommendation;
            }
           
            
            dietRecommendation.UserId = (int)HttpContext.Session["Id"];
            //(int)HttpContext.Session["Id"];

            ViewBag.bMi = Math.Round(bMI.BMIResult, 2);
            //string myVar = (int)HttpContext.Session["UserId"];
            //dietRecommendation.UserId = (int)HttpContext.Session["UserId"];

            context.DietRecommendations.Add(dietRecommendation);
            context.SaveChanges();
            return View(bMI);
        }
    }
}