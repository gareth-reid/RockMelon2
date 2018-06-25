using System.IO;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EntityFramework.Common.Repositories;
using Rockmelon.Factory;
using Rockmelon.Repository.Entities;
using RockMelon.Site.Controllers;
using System.Linq;
using RockMelon.Site.Models;

namespace RockMelon.Site.Controllers
{
    public class SharedController : BaseController
    {
        private IGenericAuditableRepository<Feedback> _genericAuditableRepository;
        private IGenericAuditableRepository<Recipe> _genericContentRepository;
        public SharedController()
        {
            _genericAuditableRepository = Ioc.Container.Get<IGenericAuditableRepository<Feedback>>();_genericAuditableRepository = Ioc.Container.Get<IGenericAuditableRepository<Feedback>>();
            _genericContentRepository = Ioc.Container.Get<IGenericAuditableRepository<Recipe>>();
        }
        public ActionResult Feedback(int? pageId)
        {
            var feedback = new FeedbackModel()
                {
                    FeedbackItems = _genericAuditableRepository.GetAll().Where(f => f.PageId == (pageId ?? 0)),
                    PageId = pageId
                };
            return View(feedback);
        }

        public ActionResult SaveFeedBack(string text, int? pageId)
        {
            var feedback = new Feedback()
                {
                    Description = text,
                    PageId = pageId ?? 0
                };
            _genericAuditableRepository.Add(feedback);
            _genericAuditableRepository.SaveMe();
            return new JsonResult();
        }

        public ActionResult UploadFileByDragAndDrop()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FileTest(FormCollection form)
        {
            string fileName = Request.Headers["X-Filename"];
            {
                string mappedFileName = Server.MapPath(string.Format("~\\{0}", fileName));
                if (System.IO.File.Exists(mappedFileName))
                {
                    System.IO.File.Delete(mappedFileName);
                }
                using (var fs = new FileStream(mappedFileName, FileMode.CreateNew,
                                               FileAccess.ReadWrite))
                {
                    byte[] fileRequest = new byte[Request.ContentLength];
                    Request.InputStream.Read(fileRequest, 0, Request.ContentLength);
                    fs.Write(fileRequest, 0, Request.ContentLength);
                }
                return new JsonResult()
                    {
                        Data = "Empty",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = new MainModel(ArchiveMode);
            //model = MenuBuilder.BuildModel(model, AccessGranted);
            //model.SearchResults = _genericContentRepository.GetAll().Where(x => x.PageContent.Contains(search) || x.PageSearchWords.Contains(search)).ToList();
            return PartialView(model);
        }

    }
}
