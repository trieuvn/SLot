using SLot.Models; // Thêm model
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SLot.Controllers
{
    public class HomeController : Controller
    {
        // Dữ liệu User gán cứng (Giữ nguyên của bạn)
        private UserProfileViewModel GetDemoUser()
        {
            return new UserProfileViewModel
            {
                UserName = "Demo User",
                Email = "demo@slot.com",
                Balance = 500000 // Số tiền trong tài khoản 
            };
        }

        // --- ĐÃ CẬP NHẬT (Dựa trên file của bạn) ---
        // Dữ liệu bãi đỗ xe gán cứng
        private List<ParkingSlotViewModel> GetDemoParkingSlots()
        {
            return new List<ParkingSlotViewModel>
            {
                new ParkingSlotViewModel
                {
                    Id = 1,
                    Name = "Bãi Xe 220 Pasteur",
                    Address = "220 Pasteur, Phường 6, Quận 3, Thành phố Hồ Chí Minh",
                    Price = 50000,
                    ImageUrl = "/Content/img/bai1.jpg", // Giữ nguyên link của bạn
                    Latitude = 10.784533855868323,
                    Longitude = 106.69249728774506,
                    IsFull = false // Bãi này còn trống
                },
                new ParkingSlotViewModel
                {
                    Id = 2,
                    Name = "Bãi xe chợ Bến Thành",
                    Address = "456 Đường Phan Chu Trinh, Q.1, TP.HCM",
                    Price = 70000,
                    ImageUrl = "/Content/img/bai2.jpg", // Giữ nguyên link của bạn
                    Latitude = 10.7725,
                    Longitude = 106.6980,
                    IsFull = true // MỚI: Bãi này ĐẦY
                },
                new ParkingSlotViewModel
                {
                    Id = 3,
                    Name = "Bãi xe Dinh Độc Lập",
                    Address = "135 Nam Kỳ Khởi Nghĩa, Q.1, TP.HCM",
                    Price = 60000,
                    ImageUrl = "/Content/img/bai3.jpg", // Giữ nguyên link của bạn
                    Latitude = 10.7770,
                    Longitude = 106.6954,
                    IsFull = true // MỚI: Bãi này ĐẦY
                },
                new ParkingSlotViewModel
                {
                    Id = 4,
                    Name = "Bãi xe Diamond Plaza",
                    Address = "34 Lê Duẩn, Bến Nghé, Q.1, TP.HCM",
                    Price = 80000,
                    ImageUrl = "/Content/img/bai4.jpg", // Giữ nguyên link của bạn
                    Latitude = 10.7794,
                    Longitude = 106.6995,
                    IsFull = false // Bãi này còn trống
                }
            };
        }

        public ActionResult Index()
        {
            // Giữ nguyên vị trí Bitexco của bạn
            ViewBag.CurrentLocationLat = 10.77168173268832;
            ViewBag.CurrentLocationLng = 106.70404450613947;
            return View();
        }

        // (Các action còn lại: Profile, Booking, LockedFeature, History... giữ nguyên như file của bạn)
        public ActionResult Profile()
        {
            var user = GetDemoUser();
            return View(user);
        }

        public ActionResult Booking()
        {
            ViewBag.ParkingSlots = GetDemoParkingSlots();
            return View();
        }

        public ActionResult LockedFeature()
        {
            ViewBag.Message = "Tính năng đang được tạm khóa trong quá trình demo";
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

        public ActionResult Notifications()
        {
            return RedirectToAction("LockedFeature");
        }

        [HttpGet]
        public JsonResult GetParkingSlots()
        {
            var slots = GetDemoParkingSlots();
            return Json(slots, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCurrentUserData()
        {
            var user = GetDemoUser();
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlaceBooking(string bookingTime)
        {
            TempData["BookingSuccess"] = "Đặt chỗ thành công!";
            TempData["NotificationCount"] = 1;
            return RedirectToAction("Index");
        }

        // (About, Contact giữ nguyên)
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserProfile()
        {
            var user = GetDemoUser();
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = GetDemoUser();
                model.Balance = user.Balance;

                ViewBag.Message = "Cập nhật thông tin thành công!";
            }

            return View("UserProfile", model);
        }

    }
}