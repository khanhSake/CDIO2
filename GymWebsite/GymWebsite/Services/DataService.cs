using System;
using System.Collections.Generic;
using GymWebsite.Models;

namespace GymWebsite.Services
{
    public class DataService
    {
        private static List<Gym> gyms = new List<Gym>
        {
            new Gym
            {
                Id = "1",
                TenPhongTap = "Fitness Pro Đà Nẵng",
                DiaChi = "123 Lê Duẩn, Đà Nẵng",
                SoDienThoai = "0123 456 789",
                Email = "contact@fitnesspro.vn",
                GioMoCua = "06:00",
                GioDongCua = "22:00",
                ImageUrl = "/images/gym1.jpg",
                TienIch = new List<string> { "Máy chạy bộ", "Phòng xông hơi", "Huấn luyện viên riêng", "Wifi miễn phí" }
            },
            new Gym
            {
                Id = "2",
                TenPhongTap = "Gym Center HCM",
                DiaChi = "456 Nguyễn Trãi, TP.HCM",
                SoDienThoai = "0987 654 321",
                Email = "info@gymcenter.vn",
                GioMoCua = "05:00",
                GioDongCua = "23:00",
                ImageUrl = "/images/gym2.jpg",
                TienIch = new List<string> { "Bể bơi", "Yoga", "Khu vực CrossFit" }
            }
        };
        public List<Gym> GetAllGyms()
        {
            return gyms;
        }
        public Gym GetGymById(string id)
        {
            return gyms.Find(g => g.Id == id);
        }
        public void AddGym(Gym gym)
        {
            gyms.Add(gym);
        }
        public void UpdateGym(Gym updatedGym)
        {
            var index = gyms.FindIndex(g => g.Id == updatedGym.Id);
            if (index != -1)
            {
                gyms[index] = updatedGym;
            }
        }
        public void DeleteGym(string id)
        {
            gyms.RemoveAll(g => g.Id == id);
        }
    }
}
