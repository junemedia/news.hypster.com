using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_news.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/

        protected int POSTS_NUM_PAGING = 5;



        /// <summary>
        /// this is paging functionality
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.OutputCache(Duration = 160)]
        public ActionResult Index()
        {
            return RedirectPermanent("http://hypster.com/breaking");





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



        /// <summary>
        /// this is paging functionality
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.OutputCache(Duration = 160)]
        public ActionResult GetPage(int page_id)
        {
            return RedirectPermanent("http://hypster.com/breaking");





            hypster_tv.ViewModels.HomePageViewModel model = new hypster_tv.ViewModels.HomePageViewModel();



            int _start = ((page_id * POSTS_NUM_PAGING) - POSTS_NUM_PAGING);
            int _end = _start + POSTS_NUM_PAGING;

            ViewBag.CurrPage_Start = _start;
            ViewBag.CurrPage_End = _end;
            ViewBag.CurrPage = page_id;


            hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
            model.posts_list = newsManager.GetLatestNews_cache();



            model.NumOfPosts = model.posts_list.Count;
            double tmp_numPages = (double)model.NumOfPosts / (double)POSTS_NUM_PAGING;
            if ((tmp_numPages - (int)tmp_numPages) > 0)
                tmp_numPages++;
            model.NumOfPages = (int)tmp_numPages;



            return View("Index", model);
        }




        [System.Web.Mvc.OutputCache(Duration = 160)]
        public ActionResult Featured()
        {
            return RedirectPermanent("http://hypster.com/breaking");




            hypster_tv.ViewModels.HomePageViewModel model = new hypster_tv.ViewModels.HomePageViewModel();


            ViewBag.CurrPage_Start = 0;
            ViewBag.CurrPage_End = POSTS_NUM_PAGING;


            hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
            model.posts_list = newsManager.GetLatestNews_cache();


            return View(model);
        }



        public ActionResult Bad_Diver_Bill()
        {
            return RedirectPermanent("http://hypster.com/breaking");




            return View();
        }

    }
}
