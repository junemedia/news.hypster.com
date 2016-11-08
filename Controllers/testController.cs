using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_news.Controllers
{
    public class testController : Controller
    {

        protected int POSTS_NUM_PAGING = 5;


        //
        // GET: /test/

        public ActionResult Index()
        {
            return View();
        }



        [System.Web.Mvc.OutputCache(Duration = 160)]
        public ActionResult SpecificMedia()
        {
            hypster_tv.ViewModels.HomePageViewModel model = new hypster_tv.ViewModels.HomePageViewModel();


            ViewBag.CurrPage_Start = 0;
            ViewBag.CurrPage_End = POSTS_NUM_PAGING;


            hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
            model.posts_list = newsManager.GetLatestNews_cache();



            model.NumOfPosts = model.posts_list.Count;
            double tmp_numPages = (double)model.NumOfPosts / (double)POSTS_NUM_PAGING;
            if ((tmp_numPages - (int)tmp_numPages) > 0)
                tmp_numPages++;
            model.NumOfPages = (int)tmp_numPages;


            return View(model);
        }




    }
}
