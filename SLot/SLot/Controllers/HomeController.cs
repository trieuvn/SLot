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
                    Name = "Bãi xe trung tâm A",
                    Address = "123 Đường Lê Lợi, Q.1, TP.HCM",
                    Price = 50000,
                    ImageUrl = "https://via.placeholder.com/100", // Link ảnh demo
                    Latitude = 10.7769, // Vị trí gán cứng
                    Longitude = 106.7009
                },
                new ParkingSlotViewModel
                {
                    Id = 2,
                    Name = "Bãi xe chợ Bến Thành",
                    Address = "456 Đường Phan Chu Trinh, Q.1, TP.HCM",
                    Price = 70000,
                    ImageUrl = "https://via.placeholder.com/100", // Link ảnh demo
                    Latitude = 10.7725, // Vị trí gán cứng
                    Longitude = 106.6980
                }
            };
        }

        public ActionResult Index()
        {
            ViewBag.CurrentLocationLat = 10.7756; // Vị trí hiện tại gán cứng [cite: 4, 8]
            ViewBag.CurrentLocationLng = 106.7019;
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

        // Dẫn đến view khóa 
        public ActionResult History()
        {
            return RedirectToAction("LockedFeature");
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