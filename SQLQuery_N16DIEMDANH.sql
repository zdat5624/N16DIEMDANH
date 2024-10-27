CREATE DATABASE N16DIEMDANH
GO

Use N16DIEMDANH
GO

CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
);

GO

CREATE TABLE MonHoc (
    MaMonHoc NVARCHAR(50) PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL
);
GO

CREATE TABLE LopHoc (
    MaLopHoc INT PRIMARY KEY IDENTITY(1,1),
    MaMonHoc NVARCHAR(50),
	TenLop NVARCHAR(255),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc),
);
GO

CREATE TABLE BuoiDiemDanh (
    MaBuoiDiemDanh INT PRIMARY KEY IDENTITY(1,1),
    MaLopHoc INT,
	STT INT, -- Dùng để biết thứ tự buổi điểm danh hiển thị trên UI (Buổi + STT: Buổi 1, Buổi 2, ...)
    FOREIGN KEY (MaLopHoc) REFERENCES LopHoc(MaLopHoc)
);
GO

CREATE TABLE DiemDanh (
    MaDiemDanh INT PRIMARY KEY IDENTITY(1,1),
    MaSinhVien NVARCHAR(50),
    MaBuoiDiemDanh INT,
    TrangThai INT, -- 1: Có mặt, 0: Vắng mặt
    FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien),
    FOREIGN KEY (MaBuoiDiemDanh) REFERENCES BuoiDiemDanh(MaBuoiDiemDanh)
);
GO

CREATE TABLE SinhVienThamGiaLopHoc (
    MaSinhVien NVARCHAR(50),
    MaLopHoc INT,
    PRIMARY KEY (MaSinhVien, MaLopHoc),
    FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien),
    FOREIGN KEY (MaLopHoc) REFERENCES LopHoc(MaLopHoc)
);
GO

-- Chỉ lưu 1 hàng dữ liệu để phục vụ xuất excel
CREATE TABLE GiangVien (
    MaGiangVien INT IDENTITY PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(255)
);
GO