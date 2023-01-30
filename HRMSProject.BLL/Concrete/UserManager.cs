using AutoMapper;
using HRMSProject.BLL.Abstract;
using HRMSProject.DAL.Concrete.Repositories.Abstract;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using HRMSProject.ViewModels.AppUserVM.SiteManagerVM;
using Syst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository= userRepository;
            _mapper = mapper;
        }
        public ResultService<AppUserDetail> GetDetailById(Guid id)
        {
            ResultService<AppUserDetail> result = new ResultService<AppUserDetail>();
            AppUser appUser = _userRepository.Get(x => x.Id == id);
            if(appUser != null)
            {
                result.Data = _mapper.Map<AppUserDetail>(appUser);
            }
            else
            {
                result.AddError("Hata Oluştu", "Kayıt bulunamadı.");
            }
            return result;
        }

        public ResultService<AppUserSummary> GetSummaryById(Guid id)
        {
            ResultService<AppUserSummary> result = new ResultService<AppUserSummary>();
            AppUser appUser = _userRepository.Get(x => x.Id == id);
            if (appUser != null)
            {
                result.Data = _mapper.Map<AppUserSummary>(appUser);
            }
            else
            {
                result.AddError("Hata Oluştu", "Kayıt bulunamadı.");
            }
            return result;
        }

        public ResultService<AppUserUpdate> UpdateAppUser(AppUserUpdate vm)
        {
            ResultService<AppUserUpdate> result = new ResultService<AppUserUpdate>();
            try
            {
                AppUser appUser = _userRepository.Get(x => x.Id == vm.Id);
                appUser.Photo = vm.Photo;
                appUser.Address = vm.Address;
                appUser.PhoneNumber = vm.PhoneNumber;
                _userRepository.Update(appUser);
                result.Data = vm;
            }
            catch (Exception)
            {
                result.Data = vm;
                result.AddError("Güncelleme Hatası", "Güncelleme işlemi başarısız.");
            }
            return result;
        }

    }
}
