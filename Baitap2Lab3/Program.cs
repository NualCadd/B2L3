
using System;

namespace BaiTap2
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }

        public int LayTuoi
        {
            get
            {
                int tuoi = DateTime.Today.Year - NgaySinh.Year;
                if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi))
                    tuoi--;
                return tuoi;
            }
        }

        public Nguoi()
        {
            HoTen = "";
            NgaySinh = DateTime.Today;
            DiaChi = "";
        }

        public Nguoi(string hoTen, DateTime ngaySinh, string diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
        }

        public virtual void XemThongTin()
        {
            Console.WriteLine("Ho ten: " + HoTen);
            Console.WriteLine("Ngay sinh: " + NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Dia chi: " + DiaChi);
            Console.WriteLine("Tuoi: " + LayTuoi);
        }
    }

    class SinhVien : Nguoi
    {
        private string maSV;
        private string maLop;
        private string email;
        private string dienThoai;

        public string MaSV
        {
            get { return maSV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ma sinh vien khong duoc rong");
                maSV = value;
            }
        }

        public string MaLop
        {
            get { return maLop; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ma lop khong duoc rong");
                maLop = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Email khong hop le");
                email = value;
            }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Dien thoai khong hop le");
                foreach (char c in value)
                    if (c < '0' || c > '9')
                        throw new ArgumentException("Dien thoai chi duoc chua chu so");
                dienThoai = value;
            }
        }

        public SinhVien() : base()
        {
            maSV = "";
            maLop = "";
            email = "";
            dienThoai = "";
        }

        public SinhVien(string hoTen, DateTime ngaySinh, string diaChi,
                        string maSV, string maLop, string email, string dienThoai)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaSV = maSV;
            MaLop = maLop;
            Email = email;
            DienThoai = dienThoai;
        }

        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine("Ma sinh vien: " + MaSV);
            Console.WriteLine("Ma lop: " + MaLop);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Dien thoai: " + DienThoai);
        }
    }

    class NhanVien : Nguoi
    {
        private string maNhanVien;
        private string email;
        private string dienThoai;
        private DateTime ngayLamViec;
        private string maCongTy;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ma nhan vien khong duoc rong");
                maNhanVien = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Email khong hop le");
                email = value;
            }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Dien thoai khong hop le");
                foreach (char c in value)
                    if (c < '0' || c > '9')
                        throw new ArgumentException("Dien thoai chi duoc chua chu so");
                dienThoai = value;
            }
        }

        public DateTime NgayLamViec
        {
            get { return ngayLamViec; }
            set
            {
                if (value.Date > DateTime.Today)
                    throw new ArgumentException("Ngay lam viec khong hop le");
                ngayLamViec = value;
            }
        }

        public string MaCongTy
        {
            get { return maCongTy; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ma cong ty khong duoc rong");
                maCongTy = value;
            }
        }

        public NhanVien() : base()
        {
            maNhanVien = "";
            email = "";
            dienThoai = "";
            ngayLamViec = DateTime.Today;
            maCongTy = "";
        }

        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi,
                        string maNV, string email, string dienThoai,
                        DateTime ngayLamViec, string maCongTy)
            : base(hoTen, ngaySinh, diaChi)
        {
            MaNhanVien = maNV;
            Email = email;
            DienThoai = dienThoai;
            NgayLamViec = ngayLamViec;
            MaCongTy = maCongTy;
        }

        public override void XemThongTin()
        {
            base.XemThongTin();
            Console.WriteLine("Ma nhan vien: " + MaNhanVien);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Dien thoai: " + DienThoai);
            Console.WriteLine("Ngay lam viec: " + NgayLamViec.ToString("dd/MM/yyyy"));
            Console.WriteLine("Ma cong ty: " + MaCongTy);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Nguoi nguoi = new Nguoi(
                "Nguyen Van A",
                new DateTime(2000, 5, 15),
                "TP HCM"
            );

            SinhVien sv = new SinhVien(
                "Tran Van B",
                new DateTime(2004, 8, 20),
                "Ha Noi",
                "SV001",
                "CNTT01",
                "sv001@gmail.com",
                "0912345678"
            );

            NhanVien nv = new NhanVien(
                "Le Thi C",
                new DateTime(1995, 3, 10),
                "Da Nang",
                "NV001",
                "nv001@gmail.com",
                "0987654321",
                new DateTime(2020, 6, 1),
                "CT001"
            );

            Nguoi nguoi2 = new Nguoi();
            nguoi2.HoTen = "Pham Van D";
            nguoi2.NgaySinh = new DateTime(2002, 1, 12);
            nguoi2.DiaChi = "Can Tho";

            SinhVien sv2 = new SinhVien();
            sv2.HoTen = "Nguyen Thi E";
            sv2.NgaySinh = new DateTime(2005, 9, 5);
            sv2.DiaChi = "TP HCM";
            sv2.MaSV = "SV002";
            sv2.MaLop = "CNTT02";
            sv2.Email = "sv002@gmail.com";
            sv2.DienThoai = "0901234567";

            NhanVien nv2 = new NhanVien();
            nv2.HoTen = "Tran Van F";
            nv2.NgaySinh = new DateTime(1998, 4, 18);
            nv2.DiaChi = "Ha Noi";
            nv2.MaNhanVien = "NV002";
            nv2.Email = "nv002@gmail.com";
            nv2.DienThoai = "0934567890";
            nv2.NgayLamViec = new DateTime(2022, 7, 1);
            nv2.MaCongTy = "CT002";

            Nguoi[] danhSach = { nguoi, sv, nv, nguoi2, sv2, nv2 };

            foreach (Nguoi item in danhSach)
            {
                Console.WriteLine("\n----------------------");
                Console.WriteLine(item.GetType().Name.ToUpper());
                item.XemThongTin();
            }

            Console.ReadKey();
        }
    }
}
