using AutoMapper;
using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<AttendencePerCourseTbl, AttendencePerCourseDTO>();
            CreateMap<AttendencePerCourseDTO, AttendencePerCourseTbl>();

            CreateMap<CoursesTbl, CoursesDTO>();
            CreateMap<CoursesDTO, CoursesTbl>();

            CreateMap<ExistedLessonsTbl, ExistedLessonsDTO>();
            CreateMap<ExistedLessonsDTO, ExistedLessonsTbl>();

            CreateMap<MajorCoursesTbl, MajorCoursesDTO>();
            CreateMap<MajorCoursesDTO, MajorCoursesTbl>();

            CreateMap<MajorTbl, MajorDTO>();
            CreateMap<MajorDTO, MajorTbl>();

            CreateMap<MarkPerCourseTbl, MarkPerCourseDTO>();
            CreateMap<MarkPerCourseDTO, MarkPerCourseTbl>();

            CreateMap<SeminarTbl, SeminarDTO>();
            CreateMap<SeminarDTO, SeminarTbl>();

            CreateMap<StaffTbl, StaffDTO>();
            CreateMap<StaffDTO, StaffTbl>();

            CreateMap<StudentsTbl, StudentsDTO>();
            CreateMap<StudentsDTO, StudentsTbl>();

            CreateMap<UserTbl, UserDTO>();
            CreateMap<UserDTO, UserTbl>();
        }
    }
}
