using AutoMapper;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentManageNetCore.Application.GeneTestResults.Dto
{
    public class GeneTestResultProfile:Profile
    {
        public GeneTestResultProfile() {
            CreateMap<CreateGeneTestResultDto, TB_GeneTestResult>();
            CreateMap<TB_GeneTestResult, GeneTestResultDto>().ForMember(dto=>dto.GeneName,opt=>opt.Ignore());
            CreateMap<GeneTestResultDto, TB_GeneTestResult>();
        }
    }
}
