using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hypster_news.Controllers
{

    [Authorize]
    public class postCommentController : Controller
    {
        //
        // GET: /postComment/


        [HttpPost]
        public ActionResult SubmitPostComment(hypster_tv_DAL.newsComment p_comment, string post_guid)
        {
            hypster_tv_DAL.Hypster_Entities hyDB = new hypster_tv_DAL.Hypster_Entities();
            hypster_tv_DAL.memberManagement memberManager = new hypster_tv_DAL.memberManagement();



            //---------------------------------------------------------------------------------------
            p_comment.comment = System.Text.RegularExpressions.Regex.Replace(p_comment.comment, @"<(.|\n)*?>", string.Empty);

            p_comment.ipAddress = IpAddress();
            p_comment.status = (int)hypster_tv_DAL.newsCommentStatus.NoActive;
            p_comment.user_ID = memberManager.getMemberByUserName(User.Identity.Name).id;
            p_comment.userName = User.Identity.Name;
            p_comment.postDate = DateTime.Now;
            
            
            hyDB.newsComments.AddObject(p_comment);
            hyDB.SaveChanges();
            //---------------------------------------------------------------------------------------




            //need to reset data cache (if exist)
            // this will allow to show new comment
            //---------------------------------------------------------------------------------------
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["NewsComment_For_Tv_" + p_comment.newsPost_ID] != null)
                i_chache.Remove("NewsComment_For_Tv_" + p_comment.newsPost_ID);
            //---------------------------------------------------------------------------------------




            return RedirectToAction("getPost", "post", new { @post_guid = post_guid });
        }






        /// <summary>
        /// Service function - gives user ip address
        /// </summary>
        /// <returns></returns>
        private string IpAddress()
        {
            string strIpAddress;
            strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null) strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            return strIpAddress;
        }


    }



}
