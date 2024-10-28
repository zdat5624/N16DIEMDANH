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
    SoTinChi INT NOT NULL,
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
    MaSinhVien NVARCHAR(50),
    MaBuoiDiemDanh INT,
    TrangThai INT, -- 1: Có mặt, 0: Vắng mặt
	PRIMARY KEY (MaSinhVien, MaBuoiDiemDanh),
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


INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi) VALUES
('MH001', N'Lập trình C#', 3),
('MH002', N'Cơ sở dữ liệu', 3),
('MH003', N'Giải thuật và cấu trúc dữ liệu', 4),
('MH004', N'Mạng máy tính', 3),
('MH005', N'Hệ điều hành', 3),
('MH0066666666666666', N'Kiểm thử phần mềm', 2),
('MH007', N'Phát triển web', 4),
('MH008', N'Trí tuệ nhân tạo', 3);
GO

INSERT INTO LopHoc (MaMonHoc, TenLop, NgayBatDau, NgayKetThuc) VALUES
('MH001', N'Lớp Lập trình C# 1', '2024-09-01', '2024-12-31'),
('MH002', N'Lớp Cơ sở dữ liệu 1', '2024-09-01', '2024-12-31'),
('MH003', N'Lớp Giải thuật 1', '2024-09-01', '2024-12-31'),
('MH004', N'Lớp Mạng máy tính 1', '2024-09-01', '2024-12-31'),
('MH005', N'Lớp Hệ điều hành 1', '2024-09-01', '2024-12-31'),
('MH0066666666666666', N'Lớp Kiểm thử phần mềm 1', '2024-09-01', '2024-12-31'),
('MH007', N'Lớp Phát triển web 1', '2024-09-01', '2024-12-31'),
('MH008', N'Lớp Trí tuệ nhân tạo 1', '2024-09-01', '2024-12-31');
GO

INSERT INTO SinhVien (MaSinhVien, HoTen) VALUES
('SV001', N'Nguyễn Văn A'),
('SV002', N'Trần Thị B'),
('SV003', N'Lê Văn C'),
('SV004', N'Phạm Thị D'),
('SV005', N'Nguyễn Văn E'),
('SV006', N'Trần Văn F'),
('SV007', N'Lê Thị G'),
('SV008', N'Nguyễn Văn H'),
('SV009', N'Phạm Văn I'),
('SV010', N'Nguyễn Thị J'),
('SV011', N'Trần Văn K'),
('SV012', N'Lê Thị L'),
('SV013', N'Nguyễn Văn M'),
('SV014', N'Trần Thị N'),
('SV015', N'Lê Văn O'),
('SV016', N'Phạm Văn P'),
('SV017', N'Nguyễn Thị Q'),
('SV018', N'Trần Văn R'),
('SV019', N'Lê Thị S'),
('SV020', N'Nguyễn Văn T');
GO

INSERT INTO BuoiDiemDanh (MaLopHoc, STT) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 5),
(4, 1),
(4, 2),
(4, 3),
(4, 4),
(4, 5),
(5, 1),
(5, 2),
(5, 3),
(5, 4),
(5, 5),
(6, 1),
(6, 2),
(6, 3),
(7, 1),
(7, 2),
(7, 3),
(8, 1),
(8, 2),
(8, 3);

GO

INSERT INTO SinhVienThamGiaLopHoc (MaSinhVien, MaLopHoc) VALUES
('SV001', 1),
('SV002', 1),
('SV003', 1),
('SV004', 1),
('SV005', 2),
('SV006', 2),
('SV007', 3),
('SV008', 4),
('SV009', 5),
('SV010', 5),
('SV011', 6),
('SV012', 7),
('SV013', 8),
('SV014', 1),
('SV015', 2),
('SV016', 3),
('SV017', 4),
('SV018', 5),
('SV019', 6),
('SV020', 7);
GO

INSERT INTO DiemDanh (MaSinhVien, MaBuoiDiemDanh, TrangThai) VALUES
('SV001', 1, 1),
('SV001', 2, 0),
('SV001', 3, 1),
('SV002', 1, 1),
('SV002', 3, 1),
('SV003', 1, 1),
('SV003', 2, 1),
('SV004', 1, 0),
('SV005', 1, 1),
('SV006', 1, 1),
('SV007', 1, 0),
('SV008', 1, 1),
('SV009', 1, 1),
('SV010', 1, 0),
('SV011', 1, 1),
('SV012', 1, 1),
('SV013', 1, 1),
('SV014', 1, 0),
('SV015', 1, 1),
('SV016', 1, 1),
('SV017', 1, 0),
('SV018', 1, 1),
('SV019', 1, 1),
('SV020', 1, 0);
GO

INSERT INTO GiangVien (HoTen, SoDienThoai, Email, DiaChi) VALUES
('Nguyễn Văn TTTT', '0123456789', 't.nguyen@gmail.com', 'HỒ CHÍ MINH')
GO

DECLARE @MaLopHoc INT = 1

SELECT 
    sv.MaSinhVien, 
    sv.HoTen,
    bbd.STT,
	dd.TrangThai
FROM 
    SinhVien sv 
JOIN 
    SinhVienThamGiaLopHoc svlh ON sv.MaSinhVien = svlh.MaSinhVien 
LEFT JOIN 
    DiemDanh dd ON sv.MaSinhVien = dd.MaSinhVien 
LEFT JOIN 
    BuoiDiemDanh bbd ON dd.MaBuoiDiemDanh = bbd.MaBuoiDiemDanh 
WHERE 
    svlh.MaLopHoc = @MaLopHoc
ORDER BY 
    sv.MaSinhVien, bbd.STT;


Select * from BuoiDiemDanh where MaLopHoc = '1' ORDER BY STT;