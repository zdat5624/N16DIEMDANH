CREATE DATABASE N16DIEMDANH
GO

Use N16DIEMDANH
GO


CREATE TABLE MonHoc (
    MaMonHoc NVARCHAR(50) PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL,
);
GO

CREATE TABLE LopHoc (
    MaLopHoc INT PRIMARY KEY IDENTITY(1,1),
    MaMonHoc NVARCHAR(50) NOT NULL,
	TenLop NVARCHAR(255) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
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

CREATE TABLE SinhVien (
	SinhVienID INT PRIMARY KEY IDENTITY(1,1),
    MaSinhVien NVARCHAR(50) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
	MaLopHoc INT NOT NULL,
	FOREIGN KEY (MaLopHoc) REFERENCES LopHoc(MaLopHoc)
);

GO

CREATE TABLE DiemDanh (
    SinhVienID INT NOT NULL,
    MaBuoiDiemDanh INT NOT NULL,
    TrangThai INT, -- 1: Có mặt, 0: Vắng mặt
	PRIMARY KEY (SinhVienID, MaBuoiDiemDanh),
    FOREIGN KEY (SinhVienID) REFERENCES SinhVien(SinhVienID),
	FOREIGN KEY (MaBuoiDiemDanh) REFERENCES BuoiDiemDanh(MaBuoiDiemDanh)
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

INSERT INTO SinhVien (MaSinhVien, HoTen, MaLopHoc) VALUES
('SV001', N'Nguyễn Văn A', 1),
('SV002', N'Trần Thị B', 1),
('SV003', N'Lê Văn C', 1),
('SV004', N'Phạm Thị D',  1),
('SV005', N'Nguyễn Văn E',  1),
('SV006', N'Trần Văn F', 1),
('SV007', N'Lê Thị G', 1),
('SV008', N'Nguyễn Văn H', 2),
('SV009', N'Phạm Văn I', 2),
('SV010', N'Nguyễn Thị J', 2),
('SV011', N'Trần Văn K', 3),
('SV012', N'Lê Thị L', 4),
('SV013', N'Nguyễn Văn M', 5),
('SV014', N'Trần Thị N', 6),
('SV015', N'Lê Văn O', 6),
('SV016', N'Phạm Văn P', 6),
('SV017', N'Nguyễn Thị Q', 6),
('SV018', N'Trần Văn R', 6),
('SV019', N'Lê Thị S', 7),
('SV020', N'Nguyễn Văn T', 8);
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

INSERT INTO DiemDanh (SinhVienID, MaBuoiDiemDanh, TrangThai) VALUES
(1, 1, 1),
(1, 2, 0),
(2, 1, 0),
(2, 2, 1),
(4, 1, 0),
(4, 2, 1),
(5, 8, 0),
(5, 9, 1),
(8, 11, 1),
(8, 12, 0),
(9, 13, 0),
(9, 14, 1),
(10, 11, 0),
(10, 12, 1),
(10, 13, 0),
(10, 14, 1);


GO

INSERT INTO GiangVien (HoTen, SoDienThoai, Email, DiaChi) VALUES
('Nguyễn Văn TTTT', '0123456789', 't.nguyen@gmail.com', 'HỒ CHÍ MINH')
GO



SELECT 
    SinhVien.HoTen, DiemDanh.*
FROM SinhVien, DiemDanh
Where SinhVien.MaLopHoc = 2 and SinhVien.SinhVienID=DiemDanh.SinhVienID

select * from BuoiDiemDanh where MaLopHoc = 2

select * from SinhVien where MaLopHoc=2
