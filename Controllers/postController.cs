using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_news.Controllers
{
    public class postController : Controller
    {
        //
        // GET: /posts/
        // NEED TO APPLY CACHING (check everything before)

        [System.Web.Mvc.OutputCache(Duration = 120)]
        public ActionResult getPost(string post_guid)
        {
            return RedirectPermanent("http://hypster.com/breaking/details/" + post_guid);




            hypster_news.ViewModels.getPostViewModel viewModel = new ViewModels.getPostViewModel();

            
            hypster_tv_DAL.newsManagement newsManager = new hypster_tv_DAL.newsManagement();
            
            viewModel.post = newsManager.GetPostByGUID(post_guid);
            viewModel.comments_list = newsManager.GetPostComments_cache(viewModel.post.post_id);

            return View(viewModel);
        }


        
    }
}
