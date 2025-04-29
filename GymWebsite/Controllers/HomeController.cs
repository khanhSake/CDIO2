using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymWebsite.Models;

namespace GymWebsite.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

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
        /* hành động của tranner */
        public ActionResult Trainers()
        {
            var trainers = new List<Trainer>
            {
                new Trainer
                {
                    Id = 1,
                    Name = "Nguyễn Văn Thanh",
                    ImageUrl = "/Content/images/trainer1.jpg",
                    Title = "HLV Thể hình chuyên nghiệp",
                    ShortDescription = "10 năm kinh nghiệm huấn luyện thể hình.",
                    FullDescription = "HLV Nguyễn Văn Thanh đã làm việc tại nhiều trung tâm thể hình lớn, đạt nhiều chứng chỉ quốc tế.",
                    Certifications = new List<string> { "NASM", "ACE" },
                    Contact = "a.nguyen@gmail.com"
                },
                new Trainer
                {
                    Id = 2,
                    Name = "Trần Kim Bảo",
                    ImageUrl = "/Content/images/trainer2.png",
                    Title = "HLV Thể hình chuyên nghiệp",
                    ShortDescription = "3 năm kinh nghiệm huấn luyện thể hình.",
                    FullDescription = "HLV Trần Kim Bảo đã có kinh nghiệm 3 năm làm huấn luyện viên thể hình tại nhiều cơ sở uy tín.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "baotran@gmail.com"
                },
                new Trainer
                {
                    Id = 3,
                    Name = "Lê Văn Chiến",
                    ImageUrl = "/Content/images/trainer3.png",
                    Title = "HLV chuyên nghiệp",
                    ShortDescription = "Chuyên gia xây dựng cơ bắp & tăng sức mạnh.",
                    FullDescription = "HLV Lê Văn Chiến từng đào tạo cho nhiều vận động viên thể hình chuyên nghiệp.",
                    Certifications = new List<string> { "IFBB Pro", "CPT" },
                    Contact = "chienle@gmail.com"
                },
                new Trainer
                {
                    Id = 4,
                    Name = "Phạm Thị Duyên",
                    ImageUrl = "/Content/images/trainer4.png",
                    Title = "HLV có chứng chỉ quốc tế",
                    ShortDescription = "Chuyên viên dinh dưỡng & thể chất.",
                    FullDescription = "Phạm Thị Duyên đã hoàn thành nhiều khóa học quốc tế về sức khỏe và huấn luyện.",
                    Certifications = new List<string> { "ACE", "ISSA" },
                    Contact = "duenpham@gmail.com"
                },
                new Trainer
                {
                    Id = 5,
                    Name = "Ngô Văn Tiến",
                    ImageUrl = "/Content/images/trainer5.png",
                    Title = "HLV cá nhân",
                    ShortDescription = "Huấn luyện tận tâm theo yêu cầu cá nhân.",
                    FullDescription = "Ngô Văn Tiến đã đồng hành cùng hàng trăm học viên đạt mục tiêu sức khỏe cá nhân.",
                    Certifications = new List<string> { "PT Pro", "Fitness First" },
                    Contact = "tienngo@gmail.com"
                },
                new Trainer
                {
                    Id = 6,
                    Name = "Trần Thùy Trang",
                    ImageUrl = "/Content/images/trainer6.jpg",
                    Title = "Chuyên gia yoga và dinh dưỡng",
                    ShortDescription = "Truyền cảm hứng sống khỏe mạnh.",
                    FullDescription = "HLV Trần Thị B chuyên về yoga trị liệu, từng giảng dạy tại nhiều workshop lớn trong nước.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "trangtran@gmail.com"
                },
                new Trainer
                {
                    Id = 7,
                    Name = "Trần Tiến Đạt",
                    ImageUrl = "/Content/images/trainer7.jpg",
                    Title = "HLV Thể hình chuyên nghiệp",
                    ShortDescription = "7 năm kinh nghiệm huấn luyện thể hình.",
                    FullDescription = "HLV Trần Tiến Đạt có nhiều chứng chỉ quốc tế và đạt 2 huy chương vàng giải thưởng Men & Muscle.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "DAT@gmail.com"
                },
                new Trainer
                {
                    Id = 2,
                    Name = "Trần Thị Bảo",
                    ImageUrl = "/Content/images/trainer2.jpg",
                    Title = "Chuyên gia yoga và dinh dưỡng",
                    ShortDescription = "Truyền cảm hứng sống khỏe mạnh.",
                    FullDescription = "HLV Trần Thị Bảo chuyên về yoga trị liệu, từng giảng dạy tại nhiều workshop lớn trong nước.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "baotran@gmail.com"
                },
                new Trainer
                {
                    Id = 6,
                    Name = "Trần Thùy Trang",
                    ImageUrl = "/Content/images/trainer6.jpg",
                    Title = "Chuyên gia yoga và dinh dưỡng",
                    ShortDescription = "Truyền cảm hứng sống khỏe mạnh.",
                    FullDescription = "HLV Trần Thị B chuyên về yoga trị liệu, từng giảng dạy tại nhiều workshop lớn trong nước.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "trangtran@gmail.com"
                },
            };

            return View(trainers);
        }

        public ActionResult ProfessionalTrainers()
        {
            var professionalTrainers = new List<Trainer>
            {
                new Trainer
                {
                    Id = 3,
                    Name = "Lê Văn Chiến",
                    ImageUrl = "/Content/images/trainer3.png",
                    Title = "HLV chuyên nghiệp",
                    ShortDescription = "Chuyên gia xây dựng cơ bắp & tăng sức mạnh.",
                    FullDescription = "HLV Lê Văn Chiến từng đào tạo cho nhiều vận động viên thể hình chuyên nghiệp.",
                    Certifications = new List<string> { "IFBB Pro", "CPT" },
                    Contact = "chienle@gmail.com"
                },
                new Trainer
                {
                    Id = 2,
                    Name = "Trần Kim Bảo",
                    ImageUrl = "/Content/images/trainer2.png",
                    Title = "HLV Thể hình chuyên nghiệp",
                    ShortDescription = "3 năm kinh nghiệm huấn luyện thể hình.",
                    FullDescription = "HLV Trần Kim Bảo đã có kinh nghiệm 3 năm làm huấn luyện viên thể hình tại nhiều cơ sở uy tín.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "baotran@gmail.com"
                },
            };

            return View("Trainers", professionalTrainers);
        }

        public ActionResult CertifiedTrainers()
        {
            var certifiedTrainers = new List<Trainer>
            {
                new Trainer
                {
                    Id = 1,
                    Name = "Nguyễn Văn Thanh",
                    ImageUrl = "/Content/images/trainer1.jpg",
                    Title = "HLV Thể hình chuyên nghiệp",
                    ShortDescription = "10 năm kinh nghiệm huấn luyện thể hình.",
                    FullDescription = "HLV Nguyễn Văn Thanh đã làm việc tại nhiều trung tâm thể hình lớn, đạt nhiều chứng chỉ quốc tế.",
                    Certifications = new List<string> { "NASM", "ACE" },
                    Contact = "a.nguyen@gmail.com"
                },
                new Trainer
                {
                    Id = 7,
                    Name = "Trần Tiến Đạt",
                    ImageUrl = "/Content/images/trainer7.jpg",
                    Title = "HLV Thể hình chuyên nghiệp",
                    ShortDescription = "7 năm kinh nghiệm huấn luyện thể hình.",
                    FullDescription = "HLV Trần Tiến Đạt có nhiều chứng chỉ quốc tế và đạt 2 huy chương vàng giải thưởng Men & Muscle.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "DAT@gmail.com"
                },

            };

            return View("Trainers", certifiedTrainers);
        }

        public ActionResult PersonalTrainers()
        {
            var personalTrainers = new List<Trainer>
            {
                new Trainer
                {
                    Id = 5,
                    Name = "Ngô Văn Tiến",
                    ImageUrl = "/Content/images/trainer5.png",
                    Title = "HLV cá nhân",
                    ShortDescription = "Huấn luyện tận tâm theo yêu cầu cá nhân.",
                    FullDescription = "Ngô Văn Tiến đã đồng hành cùng hàng trăm học viên đạt mục tiêu sức khỏe cá nhân.",
                    Certifications = new List<string> { "PT Pro", "Fitness First" },
                    Contact = "tienngo@gmail.com"
                },
                new Trainer
                {
                    Id = 4,
                    Name = "Phạm Thị Duyên",
                    ImageUrl = "/Content/images/trainer4.png",
                    Title = "HLV có chứng chỉ quốc tế",
                    ShortDescription = "Chuyên viên dinh dưỡng & thể chất.",
                    FullDescription = "Phạm Thị Duyen đã hoàn thành nhiều khóa học quốc tế về sức khỏe và huấn luyện.",
                    Certifications = new List<string> { "ACE", "ISSA" },
                    Contact = "duenpham@gmail.com"
                },
                new Trainer
                {
                    Id = 2,
                    Name = "Trần Thị Bảo",
                    ImageUrl = "/Content/images/trainer2.png",
                    Title = "Chuyên gia yoga và dinh dưỡng",
                    ShortDescription = "Truyền cảm hứng sống khỏe mạnh.",
                    FullDescription = "HLV Trần Thị Bảo chuyên về yoga trị liệu, từng giảng dạy tại nhiều workshop lớn trong nước.",
                    Certifications = new List<string> { "RYT 200", "Nutrition Coach" },
                    Contact = "baotran@gmail.com"
                }
            };

            return View("Trainers", personalTrainers);
        }

          
    }
}
