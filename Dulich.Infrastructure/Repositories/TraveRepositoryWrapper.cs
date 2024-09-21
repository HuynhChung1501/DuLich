using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using Dulich.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.Infrastructure.Repositories
{
    public class TraveRepositoryWrapper : ITravelRepositoryWrapper
    {
        private readonly DASContext _repoContext;
        public TraveRepositoryWrapper(DASContext repositoryContext)
        {
            _repoContext = repositoryContext;   
        }

        private IMenuRepository _menu;
        public IMenuRepository Menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new MenuRepository(_repoContext);
                }
                return _menu;
            }
        }

        private IAccountRepository _account;
        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }
                return _account;
            }
        }

        private IThongTinPhuongTienRepository _thongTinPhuongTien;
        public IThongTinPhuongTienRepository ThongTinPhuongTien
        {
            get
            {
                if (_thongTinPhuongTien == null)
                {
                    _thongTinPhuongTien = new ThongTinPhuongTienRepository(_repoContext);
                }
                return _thongTinPhuongTien;
            }
        }

        private IThongTinChuyenDiRepository _thongTinChuyenDi;
        public IThongTinChuyenDiRepository ThongTinChuyenDi
        {
            get
            {
                if (_thongTinChuyenDi == null)
                {
                    _thongTinChuyenDi = new ThongTinChuyenDiRepository(_repoContext);
                }
                return _thongTinChuyenDi;
            }
        }

        private IDatPhongRepository _datPhongRepository;
        public IDatPhongRepository DatPhongRepository
        {
            get
            {
                if (_datPhongRepository == null)
                {
                    _datPhongRepository = new DatPhongRepository(_repoContext);
                }
                return _datPhongRepository;
            }
        }

        private IKhachSanRepository _khachSanRepository;
        public IKhachSanRepository KhachSanRepository
        {
            get
            {
                if (_khachSanRepository == null)
                {
                    _khachSanRepository = new KhachSanRepository(_repoContext);
                }
                return _khachSanRepository;
            }
        }

        private ILoaiPhongRepository _loaiPhongRepository;
        public ILoaiPhongRepository LoaiPhongRepository
        {
            get
            {
                if (_loaiPhongRepository == null)
                {
                    _loaiPhongRepository = new LoaiPhongRepository(_repoContext);
                }
                return _loaiPhongRepository;
            }
        }

        private IPhongKSRepository _phongKSRepository;
        public IPhongKSRepository PhongKSRepository
        {
            get
            {
                if (_phongKSRepository == null)
                {
                    _phongKSRepository = new PhongKSRepository(_repoContext);
                }
                return _phongKSRepository;
            }
        }

        private ITienIchPhongRepository _tienIchPhongRepository;
        public ITienIchPhongRepository TienIchPhongRepository
        {
            get
            {
                if (_tienIchPhongRepository == null)
                {
                    _tienIchPhongRepository = new TienIchPhongRepository(_repoContext);
                }
                return _tienIchPhongRepository;
            }
        }

    }
}
