using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_news.Controllers
{
    public class postActController : Controller
    {
        //
        // GET: /postAct/

        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Redirect to display Prev Post
        /// </summary>
        /// <returns></returns>
        public ActionResult prevPost()
        {
            if (Request.QueryString["PID"] != null)
            {
                int post_ID = 0;
                if(!Int32.TryParse(Request.QueryString["PID"], out post_ID))
                    post_ID = 0;

                if (post_ID != 0)
                {
                    hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
                    List<hypster_tv_DAL.newsPost> posts_list = new List<hypster_tv_DAL.newsPost>();
                    posts_list = newsManager.GetLatestNews_cache();

                    for (int i = 1; i < posts_list.Count; i++)
                    {
                        if (posts_list[i].post_id == post_ID)
                        {
                            return RedirectToAction("getPost", "post", new { post_guid = posts_list[i - 1].post_guid });
                        }
                    }
                }

            }


            //return to news home if no next post
            return RedirectToAction("Index", "home");
        }



        /// <summary>
        /// Redirect to display Next Post
        /// </summary>
        /// <returns></returns>
        public ActionResult nextPost()
        {
            if (Request.QueryString["PID"] != null)
            {
                int post_ID = 0;
                if (!Int32.TryParse(Request.QueryString["PID"], out post_ID))
                    post_ID = 0;


                if (post_ID != 0)
                {
                    hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
                    List<hypster_tv_DAL.newsPost> posts_list = new List<hypster_tv_DAL.newsPost>();
                    posts_list = newsManager.GetLatestNews_cache();

                    for (int i = 0; i < posts_list.Count - 1; i++)
                    {
                        if (posts_list[i].post_id == post_ID)
                        {
                            return RedirectToAction("getPost", "post", new { post_guid = posts_list[i + 1].post_guid });
                        }
                    }
                }

            }


            //return to news home if no next post
            return RedirectToAction("Index", "home");
        }




    }
}
