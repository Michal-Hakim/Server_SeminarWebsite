using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class ExistedLessonsDTO
    {
        public short LessonCode { get; set; }

        public short CourseCodeForTheMajor { get; set; }

        public DateTime? LessonDate { get; set; }

        public short? LessonTime { get; set; }
    }
}
