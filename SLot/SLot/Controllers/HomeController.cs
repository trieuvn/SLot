using SLot.Models; // Thêm model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLot.Controllers
{
    public class HomeController : Controller
    {
        // Dữ liệu User gán cứng 
        private UserProfileViewModel GetDemoUser()
        {
            return new UserProfileViewModel
            {
                UserName = "Demo User",
                Email = "demo@slot.com",
                Balance = 500000 // Số tiền trong tài khoản 
            };
        }

        // Dữ liệu bãi đỗ xe gán cứng [cite: 6]
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
                    ImageUrl = "/Content/img/bai1.jpg", // Link ảnh demo
                    Latitude = 10.784533855868323, // Vị trí gán cứng
                    Longitude = 106.69249728774506
                },
                new ParkingSlotViewModel
                {
                    Id = 2,
                    Name = "Bãi giữ xe ô tô 76",
                    Address = "76 Trần Quốc Thảo, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh",
                    Price = 70000,
                    ImageUrl = "/Content/img/bai2.jpg", // Link ảnh demo
                    Latitude = 10.784174480006596, // Vị trí gán cứng
                    Longitude = 106.68589315581875
                },
                new ParkingSlotViewModel
                {
                    Id = 3,
                    Name = "P BÃI XE BV DA LIỄU",
                    Address = "2 Nguyễn Thông, Phường 6, Quận 3, Thành phố Hồ Chí Minh 700000",
                    Price = 60000,
                    ImageUrl = "/Content/img/bai3.jpg", // Link ảnh demo
                    Latitude = 10.77717206540885, // Vị trí gán cứng
                    Longitude = 106.68691277775554
                },
                new ParkingSlotViewModel
                {
                    Id = 4,
                    Name = "Bãi Giữ Xe 24/24",
                    Address = "62 Trần Quốc Thảo, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh",
                    Price = 65000,
                    ImageUrl = "/Content/img/bai4.jpg", // Link ảnh demo
                    Latitude = 10.78244706269457, // Vị trí gán cứng
                    Longitude = 106.68756863686946
                },
                new ParkingSlotViewModel
                {
                    Id = 5,
                    Name = "Giữ Xe Ô-Tô",
                    Address = "17 Lê Quý Đôn, Phường 6, Quận 3, Thành phố Hồ Chí Minh",
                    Price = 70000,
                    ImageUrl = "/Content/img/bai5.jpg", // Link ảnh demo
                    Latitude = 10.781119093590915, // Vị trí gán cứng
                    Longitude = 106.69119498352262
                }
            };
        }

        public ActionResult Index()
        {
            ViewBag.CurrentLocationLat = 10.780911421802788; 
            ViewBag.CurrentLocationLng = 106.68575690823123;
            return View();
        }

        // View Profile 
        public ActionResult Profile()
        {
            var user = GetDemoUser();
            return View(user);
        }

        // View Đặt chỗ trước [cite: 10]
        public ActionResult Booking()
        {
            ViewBag.ParkingSlots = GetDemoParkingSlots();
            return View();
        }

        // View Tính năng đang khóa 
        public ActionResult LockedFeature()
        {
             ViewBag.Message = "Tính năng đang được tạm khóa trong quá trình demo"; 
            return View();
        }
        // Trong HomeController.cs
        public ActionResult Wallet()
        {
            var model = new WalletViewModel
            {
                Balance = 50000,
                Transactions = new List<Transaction>
        {
            new Transaction
            {
                Type = "Nạp tiền vào Ví",
                Amount = 50000,
                DateTime = "16:24 - 15/08/2023",
            }
        }
            };
            return View(model);
        }

        // Dẫn đến view khóa 
        public ActionResult History()
        {
            return View();
        }

        // (Tính năng chuông thông báo cũng dẫn đến view khóa) 
        public ActionResult Notifications()
        {
            return RedirectToAction("LockedFeature");
        }

        // API gán cứng để JS gọi khi "Đặt ngay" [cite: 6]
        [HttpGet]
        public JsonResult GetParkingSlots()
        {
            var slots = GetDemoParkingSlots();
            return Json(slots, JsonRequestBehavior.AllowGet);
        }

        // API gán cứng để JS lấy thông tin user [cite: 7]
        [HttpGet]
        public JsonResult GetCurrentUserData()
        {
            var user = GetDemoUser();
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // Xử lý đặt chỗ trước [cite: 13]
        [HttpPost]
        public ActionResult PlaceBooking(string bookingTime)
        {
            // Chỉ cần set TempData để hiển thị thông báo
             TempData["BookingSuccess"] = "Đặt chỗ thành công!"; 
            TempData["NotificationCount"] = 1; // Hiển thị +1 ở icon thông báo [cite: 13]
            return RedirectToAction("Index");
        }

        // Các action mặc định, có thể xóa hoặc giữ
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
        
    }
}