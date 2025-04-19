using System.Collections.Generic;
using System.Linq;
using GymWebsite.Models;

namespace GymWebsite.Services
{
    public static class DataService
    {
        public static List<Gym> GetAllGyms()
        {
            return new List<Gym>
            {
                new Gym {
                    Id = "1",
                    TenPhongTap = "Fitness Center A",
                    DiaChi = "Hà Nội",
                    ImageUrl = "/Content/images/gym1.jpg",
                    SoDienThoai = "0123-456-789",
                    Email = "a@gym.vn",
                    GioMoCua = "06:00",
                    GioDongCua = "22:00",
                    TienIch = new List<string> {"Máy chạy bộ", "Huấn luyện viên", "Phòng xông hơi"}
                },
                new Gym {
                    Id = "2",
                    TenPhongTap = "Gym Pro B",
                    DiaChi = "TP. Hồ Chí Minh",
                    ImageUrl = "/Content/images/gym2.jpg",
                    SoDienThoai = "0987-654-321",
                    Email = "b@gym.vn",
                    GioMoCua = "05:30",
                    GioDongCua = "21:30",
                    TienIch = new List<string> {"Yoga", "Bơi lội", "Huấn luyện cá nhân"}
                }
            };
        }

        public static Gym GetGymById(string id)
        {
            return GetAllGyms().FirstOrDefault(g => g.Id == id);
        }
    }
}