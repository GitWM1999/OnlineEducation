using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Education.Model;
using Education.DTO;

namespace Education.Service.DisCusses
{
    public class DisCussMapper:Profile
    {
        public DisCussMapper()
        {
            CreateMap<DisCuss, DisCussOutPut>()
                .ForMember(d => d.OutPutCommentContent, m => m.MapFrom(m => m.CommentContent))
                .ForMember(d => d.OutPutDisCussId, m => m.MapFrom(m => m.DisCussId))

                .ForMember(d => d.OutPutReleaseTime, m => m.MapFrom(m => m.ReleaseTime))
                .ForMember(d => d.OutPutReleaseTimes, m => m.MapFrom(m => m.ReleaseTimes))
                .ForMember(d => d.OutPutUserName, m => m.MapFrom(m => m.UserName))
                .ForMember(d => d.OutPutUserFace, m => m.MapFrom(m => m.UserFace));


            CreateMap<UserDisCussInPut, UserDisCuss>()
                .ForMember(d => d.CommentContent, m => m.MapFrom(m => m.InPutCommentContent))
                .ForMember(d => d.UserId, m => m.MapFrom(m => m.InPutUserId))
                .ForMember(d => d.DisCussUserId, m => m.MapFrom(m => m.InPutDisCussUserId))
                ;

        }


    }
}
