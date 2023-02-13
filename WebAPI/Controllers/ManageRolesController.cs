//using Business.Abstract;
//using Entities.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebAPI.Controllers
//{
//    public class Class
//    {
//        [Route("api/[controller]")]
//        [ApiController]
//        public class ManageRolesController : Controller
//        {
//            public ActionResult View()
//            { }
//            [Aut(Roles = "Administrator,SuperAdmin")]
//            public ActionResult Create()
//            { }
//            [Authorize(Roles = "SuperAdmin")]
//            public ActionResult Delete()
//            { }
//            [Authorize(Roles = "Administrator")]
//            [Authorize(Roles = "SuperAdmin")]
//            public ActionResult SpecialFeature()
//            { }
//        }
//}
